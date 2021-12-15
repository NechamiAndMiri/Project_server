using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class TblPermissionLevel
    {
        public TblPermissionLevel()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int Id { get; set; }
        public int PermissionLevel { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
