using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using AutoMapper;

/// <summary>
/// using the tables:
///     1. Message
/// </summary>
namespace Project_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMapper mapper;
        IMessageBL messageBL;

        public MessageController(IMessageBL messageBL, IMapper mapper)
        {
            this.messageBL = messageBL;
            this.mapper = mapper;
        }

        /// screens:
        /// 1. SpeechTherapist->msg
        // GET: api/<MessageController>

        [HttpGet("{SpeechTherapistID}")]
         public async Task<List<MessageDTO>> Get(int SpeechTherapistID)
        {
          //return all the msgs
            var messages= await messageBL.getMessage(SpeechTherapistID);
            return mapper.Map<List<TblMessage>, List<MessageDTO>>(messages);
           

        }
        /// screens:
        /// 1. SpeechTherapist->msg
        /// 2.patient
        // POST api/<MessageController>
        [HttpPost]
        public async Task Post([FromBody] TblMessage message)
        {
            await messageBL.postMessage(message);//mapper.Map<MessageDTO, TblMessage>(message));
        }
        /// screens:
        /// 1. SpeechTherapist->msg
        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            // update col read?
            await messageBL.putMessage(id);
        }
        /// screens:
        /// 1. SpeechTherapist->msg
        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        async public Task Delete(int id)
        {
            //Delete msg
            await messageBL.deleteMessage(id);
        }
    }
}
