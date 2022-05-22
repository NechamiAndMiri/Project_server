using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WordsGivenToPracticeDTO
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int WordId { get; set; }
        public string PatientRecording { get; set; }
        public int? Score { get; set; }
        public bool? IsValid { get; set; }
        public string WordText { get; set; }
        public string WordRecording { get; set; }
    }
}
