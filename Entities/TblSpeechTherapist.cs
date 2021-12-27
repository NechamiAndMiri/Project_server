using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblSpeechTherapist
    {
        public TblSpeechTherapist()
        {
            TblPatients = new HashSet<TblPatient>();
        }
                         
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Prospectus { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
        
        public virtual TblUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
