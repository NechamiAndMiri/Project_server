using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPatientBL
    {
        Task<List<PatientDTO>> GetPatient(int speechTherapistId);
        Task deletePatient(int id);
        Task PostPatient(TblPatient tblPatient);
        Task PutPatient(int id, TblPatient tblPatient);


        Task<TblPatient> GetSinglePatient(int userId);
        
    }
}