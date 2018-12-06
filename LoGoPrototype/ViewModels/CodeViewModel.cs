using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LoGoPrototype.Models;

namespace LoGoPrototype.ViewModels
{
    public class CodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CodeHandler codeHandler;
        //private Turtle turtle;
        private string codeString;
        public string CodeString
        {
            get
            {
                return codeString;
            }
            set
            {
                if (codeString != value)
                {
                    SetProperty(ref codeString, value.ToLower());
                    codeHandler = new CodeHandler(CodeString);
                    Turtle.commands = codeHandler.Parse();
                }
            }
        }

        // Constructor
        public CodeViewModel()
        {
            CodeString = "fd 100 rt 90 fd 150 rt 90 fd 50 lt 90 fd 150 rt 90 fd 50";
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
