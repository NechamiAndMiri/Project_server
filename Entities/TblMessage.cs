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
        public bool IsAnswered { get; set; }
        public DateTime DateOfWriting { get; set; }
        public bool IsRead { get; set; }
        
        public virtual TblPatient Patient { get; set; }
    }
}
