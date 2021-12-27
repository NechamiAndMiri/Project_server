
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public TblUser User { get; set; }

        public static implicit operator UserDTO(TblUser v)
        {
            throw new NotImplementedException();
        }

        //בקונטרולור

        //private IMapper _mapper;

        //public User(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string IdentityNumber { get; set; }
        //public string Email { get; set; }
        //public int PermissionLevelId { get; set; }
        //public string Password { get; set; }
    }
}
