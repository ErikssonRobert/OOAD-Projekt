using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LoGoPrototype.Models;
using LoGoPrototype.Validation;
using SkiaSharp;
using Xamarin.Forms;

namespace LoGoPrototype.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public ICommand ChangeColorCommand { get; private set; }
        private Color currentColor;
        public Color CurrentColor
        {
            get
            {
                return currentColor;
            }
            set
            {
                SetProperty(ref currentColor, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsViewModel()
        {
            ChangeColorCommand = new Command<string>(ChangeColor, obj => { return true; } );
        }

        void ChangeColor(string color)
        {
            switch (color)
            {
                case "red":
                    Turtle.StrokePaint(SKColors.Red);
                    Console.WriteLine("Red");
                    CurrentColor = Color.Red;
                    break;
                case "blue":
                    Turtle.StrokePaint(SKColors.Blue);
                    Console.WriteLine("Blue");
                    CurrentColor = Color.Blue;
                    break;
                case "green":
                    Turtle.StrokePaint(SKColors.Green);
                    Console.WriteLine("Green");
                    CurrentColor = Color.Green;
                    break;
                case "yellow":
                    Turtle.StrokePaint(SKColors.Yellow);
                    Console.WriteLine("Yellow");
                    CurrentColor = Color.Yellow;
                    break;
                case "white":
                    Turtle.StrokePaint(SKColors.White);
                    Console.WriteLine("White");
                    CurrentColor = Color.White;
                    break;
                case "black":
                    Turtle.StrokePaint(SKColors.Black);
                    Console.WriteLine("Black");
                    CurrentColor = Color.Black;
                    break;
            }
        }

        // Default copy/pasted code
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
