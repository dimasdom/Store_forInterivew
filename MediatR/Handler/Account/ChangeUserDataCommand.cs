using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.MediatR.Command.Account;
using Store.Models.Context;
using Store.Models.DTOs;

namespace Store.MediatR.Handler.Account
{
    public class ChangeUserDataHandler : IRequestHandler<ChangeUserDataCommand>
    {
        private readonly StoreContext _context;

        public ChangeUserDataHandler(StoreContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ChangeUserDataCommand request, CancellationToken cancellationToken)
        {
            var userForChange = await _context.Users.FindAsync(request.UserId);
            
            userForChange.Address = request.userRegisterDTOs.Address != null ? request.userRegisterDTOs.Address : userForChange.Address;
            userForChange.Email = request.userRegisterDTOs.Email != null ? request.userRegisterDTOs.Email : userForChange.Email;
            userForChange.First_name = request.userRegisterDTOs.First_name != null ? request.userRegisterDTOs.First_name : userForChange.First_name;
            userForChange.Second_name = request.userRegisterDTOs.Second_name != null ? request.userRegisterDTOs.Second_name : userForChange.Second_name;
            await _context.SaveChangesAsync();
            return new Unit() ;
        }
        
    }
}
