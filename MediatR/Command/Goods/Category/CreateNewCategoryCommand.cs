using MediatR;

namespace Store.MediatR.Command
{
    public class CreateNewCategoryCommand : IRequest<bool>
    {
        public CreateNewCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
