using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblWord
    {
        public TblWord()
        {
            TblWordsGivenToPractices = new HashSet<TblWordsGivenToPractice>();
            TblWordsPerExercises = new HashSet<TblWordsPerExercise>();
        }

        public int Id { get; set; }
        public string WordText { get; set; }
        public string WordRecording { get; set; }
        public int DifficultyLevelId { get; set; }
        public virtual TblDifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<TblWordsGivenToPractice> TblWordsGivenToPractices { get; set; }
        public virtual ICollection<TblWordsPerExercise> TblWordsPerExercises { get; set; }
    }
}


