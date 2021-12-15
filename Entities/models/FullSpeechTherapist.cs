using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.models
{
    class FullSpeechTherapist:TblUser
    {
        public FullSpeechTherapist():base()
        {
            TblPatients = new HashSet<TblPatient>();
        }

   //     public int Id { get; set; }
     //   public int UserId { get; set; }
        public byte[] Prospectus { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public virtual TblUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
