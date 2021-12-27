using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblMessage
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string MessageText { get; set; }
        public bool IsAnswer { get; set; }
        public DateTime DateOfWriting { get; set; }
        public bool IsRead { get; set; }
        [JsonIgnore]
        public virtual TblPatient Patient { get; set; }
    }
}
