using MediatR;

namespace Store.MediatR.Command
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
