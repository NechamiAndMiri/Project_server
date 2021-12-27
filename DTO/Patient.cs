using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
   public class PatientDTO:UserDTO
    {
        //public TblUser User { get; set; }
        public TblPatient Patient { get; set; }
    }
}
