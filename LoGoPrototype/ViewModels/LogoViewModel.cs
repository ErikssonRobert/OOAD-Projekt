using System;
using System.ComponentModel;

namespace LoGoPrototype.ViewModels
{
    public class LogoViewModel : INotifyPropertyChanged
    {
        int x;
        int y;

        private

        private void Constructor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
