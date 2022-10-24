using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LessonDTO
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public bool IsChecked { get; set; }
        public int DifficultyLevelId { get; set; }

        public string LessonDescription { get; set; }
        public int? WeightedScore { get; set; }
        public bool IsDone { get; set; }
        public string PronunciationProblemName { get;set;}
        public int DifficultyLevelName { get; set; }
    }
}
