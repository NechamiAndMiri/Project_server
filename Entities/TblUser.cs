using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int PermissionLevelId { get; set; }
        [Required]
        public string Password { get; set; }
        [Phone]
        public string Phone { get; set; }
        [JsonIgnore]
        public virtual TblPermissionLevel PermissionLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPatient> TblPatients { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblSpeechTherapist> TblSpeechTherapists { get; set; }
    }
}
