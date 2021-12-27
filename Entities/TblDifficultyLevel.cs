using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblDifficultyLevel
    {
        public TblDifficultyLevel()
        {
            TblExercises = new HashSet<TblExercise>();
            TblLessons = new HashSet<TblLesson>();
            TblWords = new HashSet<TblWord>();
        }

        public int Id { get; set; }
        public int PronunciationProblemId { get; set; }
        public int DifficultyLevel { get; set; }
        public int SpeechTherapistId { get; set; }

        [JsonIgnore]
        public virtual TblPronunciationProblemsType PronunciationProblem { get; set; }
        [JsonIgnore]
        public virtual TblSpeechTherapist SpeechTherapist { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblExercise> TblExercises { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblLesson> TblLessons { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblWord> TblWords { get; set; }
    }
}
