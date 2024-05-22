using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Phrase> Phrases { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<PhraseLanguage> PhraseLanguages { get; set; }
        public DbSet<WordLanguage> WordLanguages { get; set; }
        public DbSet<WordPhrase> WordsPhrases { get; set; }
        public DbSet<PhraseLanguageUser> PhraseLanguageUsers { get; set; }
        public DbSet<WordLanguageUser> WordLanguageUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure PhraseLanguageUser
            builder.Entity<PhraseLanguageUser>(x => x.HasKey(p => new { p.AppUserId, p.PhraseId, p.LanguageId }));
            builder.Entity<PhraseLanguageUser>()
                .HasOne(plu => plu.AppUser)
                .WithMany(u => u.PhraseLanguageUser)
                .HasForeignKey(plu => plu.AppUserId);
            builder.Entity<PhraseLanguageUser>()
                .HasOne(plu => plu.Phrase)
                .WithMany(p => p.PhraseLanguageUser)
                .HasForeignKey(plu => plu.PhraseId);
            builder.Entity<PhraseLanguageUser>()
                .HasOne(plu => plu.Language)
                .WithMany(l => l.PhraseLanguageUser)
                .HasForeignKey(plu => plu.LanguageId);

            // Configure WordLanguageUser
            builder.Entity<WordLanguageUser>(x => x.HasKey(wlu => new { wlu.AppUserId, wlu.WordId, wlu.LanguageId }));
            builder.Entity<WordLanguageUser>()
                .HasOne(wlu => wlu.AppUser)
                .WithMany(u => u.WordLanguageUser)
                .HasForeignKey(wlu => wlu.AppUserId);
            builder.Entity<WordLanguageUser>()
                .HasOne(wlu => wlu.Word)
                .WithMany(w => w.WordLanguageUser)
                .HasForeignKey(wlu => wlu.WordId);
            builder.Entity<WordLanguageUser>()
                .HasOne(wlu => wlu.Language)
                .WithMany(l => l.WordLanguageUser)
                .HasForeignKey(wlu => wlu.LanguageId);

            // PhraseLanguage configuration
            builder.Entity<PhraseLanguage>()
                .HasKey(pl => new { pl.LanguageId, pl.PhraseId });
            builder.Entity<PhraseLanguage>()
                .HasOne(pl => pl.Phrase)
                .WithMany(p => p.PhraseLanguages)
                .HasForeignKey(pl => pl.PhraseId);
            builder.Entity<PhraseLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(l => l.PhraseLanguages)
                .HasForeignKey(pl => pl.LanguageId);
            builder.Entity<PhraseLanguage>()
                .ToTable("PhrasesLanguages");

            // WordLanguage configuration
            builder.Entity<WordLanguage>()
                .HasKey(wl => new { wl.LanguageId, wl.WordId });
            builder.Entity<WordLanguage>()
                .HasOne(wl => wl.Word)
                .WithMany(w => w.WordLanguages)
                .HasForeignKey(wl => wl.WordId);
            builder.Entity<WordLanguage>()
                .HasOne(wl => wl.Language)
                .WithMany(l => l.WordLanguages)
                .HasForeignKey(wl => wl.LanguageId);
            builder.Entity<WordLanguage>()
                .ToTable("WordsLanguages");

            // Configure WordPhrase
            builder.Entity<WordPhrase>()
                .HasKey(wp => new { wp.WordId, wp.PhraseId });
            builder.Entity<WordPhrase>()
                .HasOne(wp => wp.Word)
                .WithMany(w => w.WordPhrases)
                .HasForeignKey(wp => wp.WordId);
            builder.Entity<WordPhrase>()
                .HasOne(wp => wp.Phrase)
                .WithMany(p => p.WordPhrases)
                .HasForeignKey(wp => wp.PhraseId);

            // Configure AppUser and NativeLanguage relationship
            builder.Entity<AppUser>()
                .HasOne(u => u.NativeLanguage)
                .WithMany()
                .HasForeignKey(u => u.NativeLanguageId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}