using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Store.MediatR.Query
{
    public class GetRolesQuery : IRequest<List<IdentityRole>>
    {
    }
}
