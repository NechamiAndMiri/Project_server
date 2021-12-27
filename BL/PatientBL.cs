using DL;
using DTO;
using Entities;
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

        public Task deletePatient(int id)
        {
            return patientDL.deletePatient(id);
        }

        public async Task<IEnumerable<PatientDTO>> GetPatient(int speechTherapistId)
        {
            return await patientDL.GetPatient(speechTherapistId);
        }

        //for the login
        public async Task<TblPatient> GetSinglePatient(int userId)
        {
            return await patientDL.GetSinglePatient(userId);
        }

        public async Task PostPatient(TblPatient tblPatient)
        {
            await patientDL.PostPatient(tblPatient);
        }

        public async Task PutPatient(int id, TblPatient tblPatient)
        {
            await patientDL.PutPatient(id, tblPatient);
        }
    }
}
