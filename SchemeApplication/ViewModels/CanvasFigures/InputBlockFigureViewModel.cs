using SchemeApplication.Infrastructure.BlockLogics;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class InputBlockFigureViewModel : BlockFigureViewModel
    {
        #region Fields

        private InputBlockLogic _inputBlockLogic;

        #endregion

        #region Properties

        #region InputValue

        private bool _inputValue;

        public bool InputValue
        {
            get { return _inputValue; }
            set 
            { 
                Set(ref _inputValue, value);
                _inputBlockLogic.Value = _inputValue;
            }
        }

        #endregion

        #endregion

        #region Constructors

        public InputBlockFigureViewModel(int inputCount, int outputCount, InputBlockLogic inputBlockLogic)
            : base(inputCount, outputCount, inputBlockLogic)
        {
            _inputBlockLogic = inputBlockLogic;
        }

        #endregion
    }
}
