using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    ///  add user -> UserDL
    /// </summary>
    public class PatientBL : IPatientBL
    {
        IPatientDL patientDL;

        public PatientBL(IPatientDL patientDL)
        {
            this.patientDL = patientDL;
        }    

    }
}
