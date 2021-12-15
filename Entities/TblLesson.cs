using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblLesson
    {
        public TblLesson()
        {
            TblWordsGivenToPractices = new HashSet<TblWordsGivenToPractice>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public bool IsChecked { get; set; }
        public int DifficultyLevelId { get; set; }
        public string LessonDescription { get; set; }
        [JsonIgnore]
        public virtual TblDifficultyLevel DifficultyLevel { get; set; }
        [JsonIgnore]
        public virtual TblPatient Patient { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblWordsGivenToPractice> TblWordsGivenToPractices { get; set; }
    }
}
