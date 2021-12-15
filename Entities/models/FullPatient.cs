using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.models
{
    class FullPatient: TblUser
    {
        public FullPatient():base()
        {
            TblLessons = new HashSet<TblLesson>();
            TblMessages = new HashSet<TblMessage>();
        }

      //  public int Id { get; set; }
       // public int UserId { get; set; }
        public int SpeechTherapistId { get; set; }
        public DateTime DateOfBirth { get; set; } 
        [JsonIgnore]
        public virtual TblSpeechTherapist SpeechTherapist { get; set; }
        [JsonIgnore]
        public virtual TblUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblLesson> TblLessons { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblMessage> TblMessages { get; set; }
    }
}
