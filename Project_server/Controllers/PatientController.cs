using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// using the tables:
///     1. users
///     2.Patients
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        IPatientBL patientBL;

        public PatientController(IPatientBL patientBL)
        {
            this.patientBL = patientBL;
        }

        /// note: יתכן שאפשר לאחד את 2 GET -להלן ה
        ///

        // GET: api/<PatientController>
        /// screens:
        /// 1. admin
        [HttpGet("{param}/{searchType}")]
        // בשביל מסך המנהל- מקבל פרמטר של סוג הסינון, ומחזיר רשימה של כל המטופלים המותאמות לתנאי 

        public IEnumerable<TblPatient> Get(string param = null, int searchType = 0)
        {
            // return all patient list
            return null;
        }

        /// screens:
        /// 1. SpeechTherapist -> patients
        [HttpGet("{SpeechTherapistID}/{param}/{searchType}")]
        public IEnumerable<TblPatient> Get(int SpeechTherapistID, string param = null, int searchType = 0)//הפרמטרים הנוספים עבור הסינון
        {
            // return all patient list for the SpeechTherapist
            return null;
        }


        /// screens:
        /// 1. SpeechTherapist -> patients->add
        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        /// screens:
        /// 1. SpeechTherapist -> patients->edit
        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        /// screens:
        /// 1. SpeechTherapist -> patients->delete
        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
