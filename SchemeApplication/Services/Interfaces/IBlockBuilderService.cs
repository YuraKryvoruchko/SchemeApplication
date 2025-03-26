using System.Windows;
using SchemeApplication.Models;

namespace SchemeApplication.Services.Interfaces
{
    internal interface IBlockBuilderService
    {
        void CreateBlock(Point point);
        void DeleteBlock();
        void MoveBlock();
        void GetFrom(Block block, int fromOutputNumber);
        void InputTo(Block block, int toInputNumber);
        void RejectCurrentConnection();
        void RejectConnection();
    }
}
