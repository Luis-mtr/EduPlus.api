using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using EduPlus.api.Dtos.Production;
using EduPlus.api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using api.Repository;

namespace EduPlus.api.Repository
{
    public class QuestionPhraseRepository : IQuestionPhraseRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionPhraseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionPhraseDto> GetQuestionPhraseAsync(string userId, int selectedLanguageId)
        {   
            var userPhraseIds = await GetOrderedPhraseIdsAsync(userId, selectedLanguageId);

            if (userPhraseIds != null)
            {
                Random random = new Random();
                //Cut the list after a random index
                int randomIndex = random.Next(userPhraseIds.Count);
                userPhraseIds = userPhraseIds.Take(randomIndex + 1).ToList();

                //Select a random index of the remaining list and get a random PhraseId
                randomIndex = random.Next(userPhraseIds.Count);
                var userPhraseId = userPhraseIds[randomIndex];


                //Check if all the words in the phrase are known by the user
                var unknownWord = await GetRandomWordFromPhrase(userId, selectedLanguageId, userPhraseId);
                if (unknownWord  == -1)
                {
                    //build the QuestionPhraseDto and return it
                    return await GetSpecificPhraseAsync(userId, selectedLanguageId, userPhraseId);
                }
                else
                {   
                    return await GetSpecificWordAsync(userId, selectedLanguageId, unknownWord);
                }
            
            }

            else
            {
                return null;
            }

        }
// eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6IkFkbWluMUBnbWFpbC5jb20iLCJnaXZlbl9uYW1lIjoiQWRtaW4xIiwibmFtZWlkIjoiZjY4OTA5MWEtM2Y1Zi00MTc3LWJiMjUtYzY3NTYxNjM0ZmMxIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNzE2NDgyMzY3LCJleHAiOjE3MTcwODcxNjcsImlhdCI6MTcxNjQ4MjM2NywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MjQ2In0.MvYJVYvY0014AzLYBO3ziV8e-4guAezOetn_4sIU7wUyon3lBT9DGzDF3zY7KtjAmZ0vWODytuKO7uqqfm3i7Q

        public async Task<QuestionPhraseDto> GetSpecificPhraseAsync(string userId, int selectedLanguageId, int phraseId)
        {
            // Retrieve the user's native language
            var user = await _context.Users
                .Include(u => u.NativeLanguage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Retrieve the phrase
            var phrase = await _context.Phrases
                .Include(p => p.PhraseLanguages)
                .ThenInclude(pl => pl.Language)
                .FirstOrDefaultAsync(p => p.PhraseId == phraseId);

            if (phrase == null)
            {
                throw new ArgumentException("Phrase not found");
            }

            // // Retrieve the native language text and the selected language text
            // var nativeLanguageText = phrase.PhraseLanguages
            //     .FirstOrDefault(pl => pl.LanguageId == user.NativeLanguageId)?.PhraseInLanguage;

            // var selectedLanguageText = phrase.PhraseLanguages
            //     .FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage;

            // Retrieve other phrases in the selected language
            var otherPhrases = await _context.Phrases
                .Include(p => p.PhraseLanguages)
                .ThenInclude(pl => pl.Language)
                .Where(p => p.PhraseLanguages.Any(pl => pl.LanguageId == selectedLanguageId) && p.PhraseId != phraseId)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ToListAsync();

            // Map to DTO
            var questionPhraseDto = new QuestionPhraseDto
            {
                PhraseId = phrase.PhraseId,
                NativeLanguageText = phrase.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == user.NativeLanguageId)?.PhraseInLanguage,
                SelectedLanguageText = phrase.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage,
                OtherPhrases = otherPhrases.Select(op => op.PhraseLanguages.FirstOrDefault(pl => pl.LanguageId == selectedLanguageId)?.PhraseInLanguage).ToList(),
                IsPhrase = true
            };

            return questionPhraseDto;
        }

        public async Task<List<int>> GetOrderedPhraseIdsAsync(string userId, int selectedLanguageId)
        {
            // Retrieve the user's native language
            var user = await _context.Users
                .Include(u => u.NativeLanguage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var nativeLanguageId = user.NativeLanguageId;

            // Retrieve PhraseIds present in the PhraseLanguageUser for the specified userId and selectedLanguageId, ordered by Score
            var userPhraseIds = await _context.PhraseLanguageUsers
                .Where(plu => plu.AppUserId == userId && plu.LanguageId == selectedLanguageId && plu.Date <= DateTime.UtcNow )
                .OrderBy(plu => plu.Score)
                .Select(plu => plu.PhraseId)
                .ToListAsync();
            if (userPhraseIds.Count == 0) //If there are no Phrases within the time limit set by Date, then ignore the time
            {
                userPhraseIds = await _context.PhraseLanguageUsers
                    .Where(plu => plu.AppUserId == userId && plu.LanguageId == selectedLanguageId)
                    .OrderBy(plu => plu.Score)
                    .Select(plu => plu.PhraseId)
                    .ToListAsync();
            }

            // Retrieve PhraseIds that have texts in both the user's native language and the selected language
            var phrasesWithBothLanguages = await _context.Phrases
                .Where(p => p.PhraseLanguages.Any(pl => pl.LanguageId == nativeLanguageId) &&
                            p.PhraseLanguages.Any(pl => pl.LanguageId == selectedLanguageId))
                .Select(p => p.PhraseId)
                .ToListAsync();

            // Filter out the PhraseIds that are already in the userPhraseIds list
            var otherPhraseIds = phrasesWithBothLanguages
                .Where(phraseId => !userPhraseIds.Contains(phraseId))
                .ToList();

            // Determine the insertion point to place otherPhraseIds in the middle of the userPhraseIds list
            int insertionIndex = userPhraseIds.Count / 2;

            // Insert otherPhraseIds into the middle of userPhraseIds
            userPhraseIds.InsertRange(insertionIndex, otherPhraseIds);

            return userPhraseIds;
        }

        public async Task<int> GetRandomWordFromPhrase(string userId, int selectedLanguageId, int phraseId)
        {
            // Get all words in the phrase
            var phraseWords = await _context.WordsPhrases
                .Where(wp => wp.PhraseId == phraseId)
                .Select(wp => wp.WordId)
                .ToListAsync();

            // Initialize a list to store valid wordIds
            var validWordIds = new List<int>();

            // Check each word in the phrase
            foreach (var wordId in phraseWords)
            {
                // Check if the word has a score less than or equal to 70 for the user and language
                var wordLanguageUser = await _context.WordLanguageUsers
                    .OrderBy(wlu => wlu.Date) //Sort words by date of next occurence
                    .FirstOrDefaultAsync(wlu => wlu.AppUserId == userId && wlu.LanguageId == selectedLanguageId && wlu.WordId == wordId && wlu.Score > 70);

                // If the word is valid, add its id to the list
                if (wordLanguageUser == null)
                {
                    validWordIds.Add(wordId);
                }
            }

            // If no valid wordIds found, return -1
            if (validWordIds.Count == 0)
            {
                return -1;
            }

            // Get the first word in the list
            return validWordIds[0];
        }

        public async Task<QuestionPhraseDto> GetSpecificWordAsync(string userId, int selectedLanguageId, int wordId)
        {
            // Retrieve the user's native language
            var user = await _context.Users
                .Include(u => u.NativeLanguage)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var word = await _context.Words
                .Include(p => p.WordLanguages)
                .ThenInclude(pl => pl.Language)
                .FirstOrDefaultAsync(p => p.WordId == wordId);

            if (word == null)
            {
                throw new ArgumentException("Word not found");
            }

            // Retrieve other words in the selected language
            var otherWords = await _context.Words
                .Include(w => w.WordLanguages)
                .ThenInclude(wl => wl.Language)
                .Where(w => w.WordLanguages.Any(wl => wl.LanguageId == selectedLanguageId) && w.WordId != wordId)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ToListAsync();

            // Map to DTO
            var questionWordDto = new QuestionPhraseDto
            {
                PhraseId = word.WordId,
                NativeLanguageText = word.WordLanguages.FirstOrDefault(wl => wl.LanguageId == user.NativeLanguageId)?.WordInLanguage,
                SelectedLanguageText = word.WordLanguages.FirstOrDefault(wl => wl.LanguageId == selectedLanguageId)?.WordInLanguage,
                OtherPhrases = otherWords.Select(ow => ow.WordLanguages.FirstOrDefault(wl => wl.LanguageId == selectedLanguageId)?.WordInLanguage).ToList(),
                IsPhrase = false
            };

            return questionWordDto;
        }
    }
}