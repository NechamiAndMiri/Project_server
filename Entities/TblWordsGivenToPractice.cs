using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblWordsGivenToPractice
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int WordId { get; set; }
        public string PatientRecording { get; set; }
        public int? Score { get; set; }
        public bool? IsValid { get; set; }

        [JsonIgnore]
        public virtual TblLesson Lesson { get; set; }
        [JsonIgnore]
        public virtual TblWord Word { get; set; }

    
    }
}
