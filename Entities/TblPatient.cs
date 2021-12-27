using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblLessons = new HashSet<TblLesson>();
            TblMessages = new HashSet<TblMessage>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int SpeechTherapistId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PronunciationProblemId { get; set; }
        [JsonIgnore]
        public virtual TblPronunciationProblemsType PronunciationProblem { get; set; }
        [JsonIgnore]
        public virtual TblSpeechTherapist SpeechTherapist { get; set; }

        public virtual TblUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblLesson> TblLessons { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblMessage> TblMessages { get; set; }
    }
}
