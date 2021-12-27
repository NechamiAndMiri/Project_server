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
            TblDifficultyLevels = new HashSet<TblDifficultyLevel>();
            TblPatients = new HashSet<TblPatient>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Prospectus { get; set; }
        public string Logo { get; set; }

        public virtual TblUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblDifficultyLevel> TblDifficultyLevels { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPatient> TblPatients { get; set; }
    }
}
