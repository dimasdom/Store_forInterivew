using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models.DTOs;

namespace Store.MediatR.Command.Account
{
    public class ChangeUserDataCommand:IRequest<Unit>
    {
        public ChangeUserDataCommand(string userId, UserRegisterDTOs userRegisterDTOs)
        {
            UserId = userId;
            this.userRegisterDTOs = userRegisterDTOs;
        }

        public string UserId { get; set; }
        public UserRegisterDTOs userRegisterDTOs { get; set; }

    }
}
