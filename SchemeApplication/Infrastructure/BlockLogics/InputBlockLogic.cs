using SchemeApplication.Infrastructure.BlockLogics.Base;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    internal class InputBlockLogic : BlockLogic
    {
        public bool Value { get; set; }

        public override bool Execute()
        {
            return Value;
        }
    }
}
