using MediatR;
using System;
using Store.Models.DTOs;

namespace Store.MediatR.Query
{
    public class GetOrderDetailsQuery : IRequest<OrderDetailsModel>
    {
        public GetOrderDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
