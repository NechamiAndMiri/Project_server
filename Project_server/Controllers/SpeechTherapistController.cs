using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;

/// <summary>
/// using the tables:
///     1. users
///     2. Speech_therapists
/// </summary>

namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeechTherapistController : ControllerBase
    {

        ISpeechTherapistBL speechTherapistBL;

        public SpeechTherapistController(ISpeechTherapistBL speechTherapistBL)
        {
            this.speechTherapistBL = speechTherapistBL;
        }


        // GET: api/<SpeechTherapistController>
        [HttpGet("{param}/{searchType}")]
        /// screens:
        /// 1. admin
         // בשביל מסך המנהל- מקבל פרמטר של סוג הסינון, ומחזיר רשימה של כל הקלינאיות המותאמות לתנאי 
        public IEnumerable<TblSpeechTherapist> Get(string param = null, int searchType = 0)
        {
            //return TblSpeechTherapist list
            return null;
        }


        // GET api/<SpeechTherapistController>/5 
        /// screens:
        /// 1. SpeechTherapist
        [HttpGet("{id}")]
        public string Get(string id)
        {
            // return the current SpeechTherapist
            return null;
        }

        // POST api/<SpeechTherapistController>
        /// screens:
        /// 1. admin
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // add new SpeechTherapist
        }

        // PUT api/<SpeechTherapistController>/5
        /// screens:
        /// 1. admin
        /// 2. SpeechTherapist
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SpeechTherapistController>/5
        /// screens:
        /// 1. admin
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
