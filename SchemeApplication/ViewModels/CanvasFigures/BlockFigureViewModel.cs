using SchemeApplication.ViewModels.CanvasFigures.Base;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class BlockFigureViewModel : FigureBaseViewModel
    {
        #region Properties

        #region Name

        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        #endregion

        #region ImagePath

        private string? _imagePath;

        public string? ImagePath
        {
            get { return _imagePath; }
            set { Set(ref _imagePath, value); }
        }

        #endregion

        #region InputCount

        private int _inputCount;

        public int InputCount
        {
            get { return _inputCount; }
            set { Set(ref _inputCount, value); }
        }

        #endregion

        #region OutputCount

        private int _outputCount;

        public int OutputCount
        {
            get { return _outputCount; }
            set { Set(ref _outputCount, value); }
        }

        #endregion

        #endregion
    }
}
