using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPatients = new HashSet<TblPatient>();
            TblSpeechTherapists = new HashSet<TblSpeechTherapist>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public int PermissionLevelId { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public virtual TblPermissionLevel PermissionLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPatient> TblPatients { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblSpeechTherapist> TblSpeechTherapists { get; set; }
    }
}
