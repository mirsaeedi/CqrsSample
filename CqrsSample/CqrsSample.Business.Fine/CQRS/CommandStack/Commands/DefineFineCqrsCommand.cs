using CqrsSample.Core.CQRS.CommandStack.Commands;

namespace CqrsSample.Business.Fine.CQRS.CommandStack.Commands
{
    public class DefineFineCqrsCommand:CqrsCommand
    {
        public string Name { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
        public int DefaultCost { get; set; }
    }
}