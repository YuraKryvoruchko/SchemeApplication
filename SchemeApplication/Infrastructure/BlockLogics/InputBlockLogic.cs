using SchemeApplication.Infrastructure.BlockLogics.Base;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    /// <summary>
    /// Операція для блоку входу схеми з можливістю задати вхідне значення
    /// </summary>
    internal class InputBlockLogic : BlockLogic
    {
        public bool Value { get; set; }

        public override bool Execute()
        {
            return Value;
        }
        public override bool CanExecute()
        {
            return true;
        }
    }
}
