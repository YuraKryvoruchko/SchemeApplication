using SchemeApplication.Services.Interfaces;
using SchemeApplication.Views;

namespace SchemeApplication.Services
{
    /// <summary>
    /// Сервіс, який відповідає за контрольоване відкриття вікна допомоги HelpWindow.xaml
    /// </summary>
    internal class HelpWindowService : IHelpWindowService
    {
        #region Fields

        private HelpWindow? _window;

        #endregion

        #region Public Methods

        public void OpenOrActivateHelpWindow()
        {
            if(_window == null)
            {
                _window = new HelpWindow();
                _window.Closed += HandleWindowClosedEvent;
                _window.Show();
            }

            _window.Focus();
            _window.Activate();
        }

        #endregion

        #region Private Methods

        private void HandleWindowClosedEvent(object? sender, EventArgs e)
        {
            if (_window == null) return;

            _window.Closed -= HandleWindowClosedEvent;
            _window = null;
        }

        #endregion
    }
}
