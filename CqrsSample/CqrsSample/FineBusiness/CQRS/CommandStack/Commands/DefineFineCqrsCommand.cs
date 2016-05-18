using CqrsSample.CQRS.CommandStack.Commands;

namespace CqrsSample.FineBusiness.CQRS.CommandStack.Commands
{
    public class DefineFineCqrsCommand:CqrsCommand
    {
        public string Name { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
        public int DefaultCost { get; set; }
    }
}