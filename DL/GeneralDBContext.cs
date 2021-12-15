using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;

#nullable disable

namespace DL
{
    public partial class GeneralDBContext : DbContext
    {
        public GeneralDBContext()
        {
        }

        public GeneralDBContext(DbContextOptions<GeneralDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDifficultyLevel> TblDifficultyLevels { get; set; }
        public virtual DbSet<TblExercise> TblExercises { get; set; }
        public virtual DbSet<TblLesson> TblLessons { get; set; }
        public virtual DbSet<TblMessage> TblMessages { get; set; }
        public virtual DbSet<TblPatient> TblPatients { get; set; }
        public virtual DbSet<TblPermissionLevel> TblPermissionLevels { get; set; }
        public virtual DbSet<TblPronunciationProblemsType> TblPronunciationProblemsTypes { get; set; }
        public virtual DbSet<TblSpeechTherapist> TblSpeechTherapists { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblWord> TblWords { get; set; }
        public virtual DbSet<TblWordsGivenToPractice> TblWordsGivenToPractices { get; set; }
        public virtual DbSet<TblWordsPerExercise> TblWordsPerExercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=GeneralDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<TblDifficultyLevel>(entity =>
            {
                entity.ToTable("tbl_Difficulty_levels");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DifficultyLevel).HasColumnName("difficulty_level");

                entity.Property(e => e.PronunciationProblemId).HasColumnName("pronunciation_problem_ID");

                entity.HasOne(d => d.PronunciationProblem)
                    .WithMany(p => p.TblDifficultyLevels)
                    .HasForeignKey(d => d.PronunciationProblemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Difficulty_levels_tbl_Pronunciation_problems_types");
            });

            modelBuilder.Entity<TblExercise>(entity =>
            {
                entity.ToTable("tbl_Exercises");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DifficultyLevelId).HasColumnName("difficulty_level_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.DifficultyLevel)
                    .WithMany(p => p.TblExercises)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Exercises_tbl_Difficulty_levels");
            });

            modelBuilder.Entity<TblLesson>(entity =>
            {
                entity.ToTable("tbl_Lessons");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.DifficultyLevelId).HasColumnName("difficulty_level_ID");

                entity.Property(e => e.IsChecked).HasColumnName("is_checked");

                entity.Property(e => e.LessonDescription).HasColumnName("lesson_description");

                entity.Property(e => e.PatientId).HasColumnName("patient_ID");

                entity.HasOne(d => d.DifficultyLevel)
                    .WithMany(p => p.TblLessons)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Lessons_tbl_Difficulty_levels");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblLessons)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Lessons_tbl_Patients");
            });

            modelBuilder.Entity<TblMessage>(entity =>
            {
                entity.ToTable("tbl_Messages");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfWriting)
                    .HasColumnType("datetime")
                    .HasColumnName("date_of_writing");

                entity.Property(e => e.IsAnswered).HasColumnName("is_answered");

                entity.Property(e => e.IsRead).HasColumnName("is_read");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasColumnName("message_text");

                entity.Property(e => e.PatientId).HasColumnName("patient_ID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblMessages)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Messages_tbl_Patients");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.ToTable("tbl_Patients");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.SpeechTherapistId).HasColumnName("speech_therapist_ID");

                entity.Property(e => e.UserId).HasColumnName("user_ID");

                entity.HasOne(d => d.SpeechTherapist)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.SpeechTherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Patients_tbl_Speech_therapists");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPatients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Patients_tbl_Users");
            });

            modelBuilder.Entity<TblPermissionLevel>(entity =>
            {
                entity.ToTable("tbl_Permission_level");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PermissionLevel).HasColumnName("permission_level");
            });

            modelBuilder.Entity<TblPronunciationProblemsType>(entity =>
            {
                entity.ToTable("tbl_Pronunciation_problems_types");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProblemName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("problem_name");
            });

            modelBuilder.Entity<TblSpeechTherapist>(entity =>
            {
                entity.ToTable("tbl_Speech_therapists");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Logo)
                    .HasColumnType("image")
                    .HasColumnName("logo");

                entity.Property(e => e.Prospectus)
                    .HasColumnType("image")
                    .HasColumnName("prospectus");

                entity.Property(e => e.UserId).HasColumnName("user_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblSpeechTherapists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Speech_therapists_tbl_Users");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_Users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("identity_number");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.PermissionLevelId).HasColumnName("permission_level_ID");

                entity.HasOne(d => d.PermissionLevel)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.PermissionLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Users_tbl_Permission_level");
            });

            modelBuilder.Entity<TblWord>(entity =>
            {
                entity.ToTable("tbl_Words");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DifficultyLevelId).HasColumnName("difficulty_level_ID");

                entity.Property(e => e.WordRecording).HasColumnName("word_recording");

                entity.Property(e => e.WordText)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("word_text");

                entity.HasOne(d => d.DifficultyLevel)
                    .WithMany(p => p.TblWords)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .HasConstraintName("FK_tbl_Words_tbl_Difficulty_levels");
            });

            modelBuilder.Entity<TblWordsGivenToPractice>(entity =>
            {
                entity.ToTable("tbl_Words_given_to_practice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsValid).HasColumnName("is_valid");

                entity.Property(e => e.LessonId).HasColumnName("lesson_ID");

                entity.Property(e => e.PatientRecording)
                    .IsRequired()
                    .HasColumnName("patient_recording");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.WordId).HasColumnName("word_ID");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.TblWordsGivenToPractices)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Words_given_to_practice_tbl_Lessons");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.TblWordsGivenToPractices)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Words_given_to_practice_tbl_Words");
            });

            modelBuilder.Entity<TblWordsPerExercise>(entity =>
            {
                entity.ToTable("tbl_Words_per_exercise");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ExerciseId).HasColumnName("exercise_ID");

                entity.Property(e => e.WordId).HasColumnName("word_ID");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.TblWordsPerExercises)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Words_per_exercise_tbl_Exercises");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.TblWordsPerExercises)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Words_per_exercise_tbl_Words");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
