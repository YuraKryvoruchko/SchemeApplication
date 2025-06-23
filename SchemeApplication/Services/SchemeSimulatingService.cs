using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.Views;

namespace SchemeApplication.Services
{
    /// <summary>
    /// Сервіс, який контролює вікно симуляції та повідомляє підписників про закінчення роботи вікна
    /// </summary>
    internal class SchemeSimulatingService : ISchemeSimulatingService
    {
        #region Fields

        private SimulationWindow? _window;

        #endregion

        #region Properties

        public bool IsSimulating { get => _window != null; }

        #endregion

        #region Events

        public event Action? OnFinishSimulating;

        #endregion

        public void StartSimulate(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks)
        {
            _window = new SimulationWindow();
            _window.Closed += HandleWindowClosedEvent;
            _window.DataContext = new SimulationWindowViewModel(inputBlocks, outputBlocks);
            _window.Show();
            _window.Focus();
        }

        #region Private Methods

        private void HandleWindowClosedEvent(object? sender, EventArgs e)
        {
            if (_window == null) return;

            _window.Closed -= HandleWindowClosedEvent;
            _window = null;
            OnFinishSimulating?.Invoke();
        }

        #endregion
    }
}
