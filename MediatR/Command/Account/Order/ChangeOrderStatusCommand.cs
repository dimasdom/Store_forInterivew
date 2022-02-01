using MediatR;
using System;

namespace Store.MediatR.Command
{
    public class ChangeOrderStatusCommand : IRequest<bool>
    {
        public ChangeOrderStatusCommand(Guid orderId, string newStatus)
        {
            OrderId = orderId;
            NewStatus = newStatus;
        }

        public Guid OrderId { get; set; }
        public string NewStatus { get; set; }
    }
}
