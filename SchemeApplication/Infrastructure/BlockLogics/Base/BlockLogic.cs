using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics.Base
{
    /// <summary>
    /// Базовий клас для усіх логічних операцій, які надають інтерфейс виконання операції 
    /// та перевіркою можливості виконання операції
    /// </summary>
    internal abstract class BlockLogic
    {
        public BlockFigureViewModel? Block { get; set; }

        public abstract bool Execute();
        public abstract bool CanExecute();
    }
}
