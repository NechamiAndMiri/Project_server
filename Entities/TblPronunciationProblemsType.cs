using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblPronunciationProblemsType
    {
        public TblPronunciationProblemsType()
        {
            TblDifficultyLevels = new HashSet<TblDifficultyLevel>();
        }

        public int Id { get; set; }
        public string ProblemName { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblDifficultyLevel> TblDifficultyLevels { get; set; }
    }
}
