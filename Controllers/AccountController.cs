using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EduPlus.api.Dtos.Account;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid username and/or password!");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user, roles);

            return Ok(new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
                LanguageId = user.NativeLanguageId,
                Role = roles.FirstOrDefault() // Since each user has only one role
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var language = await _context.Languages.FindAsync(registerDto.LanguageId);
                if (language == null)
                    return BadRequest("Invalid Language ID");

                var user = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    NativeLanguageId = registerDto.LanguageId
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var token = _tokenService.CreateToken(user, roles);

                        return Ok(new NewUserDto
                        {
                            UserName = user.UserName,
                            Email = user.Email,
                            Token = token,
                            LanguageId = user.NativeLanguageId,
                            Role = roles.FirstOrDefault() // Since each user has only one role
                        });
                    }
                }

                return StatusCode(500, result.Errors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: api/account
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<IEnumerable<NewUserDto>>> GetAccounts()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<GetUsersDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userDtos.Add(new GetUsersDto
                {   
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    LanguageId = user.NativeLanguageId,
                    Role = roles.FirstOrDefault()
                });
            }

            return Ok(userDtos);
        }

        // PUT: api/account/update/{id}
        [HttpPut("update/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateAccount(string id, [FromBody] UpdateAccountDto updateAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            user.UserName = updateAccountDto.Username;
            user.Email = updateAccountDto.Email;
            user.NativeLanguageId = updateAccountDto.LanguageId;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            var currentRoles = await _userManager.GetRolesAsync(user);
            var currentRole = currentRoles.FirstOrDefault();
            if (currentRole != updateAccountDto.Role)
            {
                if (!string.IsNullOrEmpty(currentRole))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, currentRole);
                    if (!removeRoleResult.Succeeded)
                        return StatusCode(500, removeRoleResult.Errors);
                }

                var addRoleResult = await _userManager.AddToRoleAsync(user, updateAccountDto.Role);
                if (!addRoleResult.Succeeded)
                    return StatusCode(500, addRoleResult.Errors);
            }

            return NoContent();
        }

        // DELETE: api/account/delete/{id}
        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("User not found");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return NoContent();
        }
    }
}