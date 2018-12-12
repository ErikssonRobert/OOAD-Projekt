using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LoGoPrototype.Models;
using LoGoPrototype.Validation;
using Xamarin.Forms;

namespace LoGoPrototype.ViewModels
{
    public class CodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IsNotNullOrEmptyRule<string> rule;
        private CodeHandler codeHandler;
        private int amountString;
        public int AmountString
        {
            get
            {
                return amountString;
            }
            set
            {
                if (amountString != value)
                {
                    SetProperty(ref amountString, value);
                }
            }
        }
        public bool IsValid
        {
            get
            {
                return ValidateCodeString(CodeString);
            }
            set
            {
                IsValid = value;
            }
        }
        private string codeString;
        public string CodeString
        {
            get => codeString;
            set
            {
                if (codeString != value && ValidateCodeString(value))
                {
                    SetProperty(ref codeString, value.ToLower());
                    codeHandler = new CodeHandler(CodeString);
                    Turtle.commands = codeHandler.Parse();
                }
                else if (value == "")
                    SetProperty(ref codeString, value.ToLower());
            }
        }

        // Constructor
        public CodeViewModel()
        {
            AddValidationRule();
            CodeString = "";

            MovementCommand = new Command<string>(
                AddMovementToCode,
                obj => { return true; }
            );
        }

        // Validation
        private bool ValidateCodeString(string s)
        {
            return rule.Check(s);
        }

        private void AddValidationRule()
        {
            rule = new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "Please add LoGo code."
            };
        }

        // Commands
        public ICommand MovementCommand { private set; get; }

        public void AddMovementToCode(string s)
        {
            switch (s)
            {
                case "fd":
                    CodeString += string.Format("fd {0} ", AmountString);
                    break;
                case "bd":
                    CodeString += string.Format("bd {0} ", AmountString);
                    break;
                case "lt":
                    CodeString += string.Format("lt {0} ", AmountString);
                    break;
                case "rt":
                    CodeString += string.Format("rt {0} ", AmountString);
                    break;
                case "repeat":
                    CodeString += string.Format("repeat {0} [ ", AmountString);
                    break;
                case "endrepeat":
                    CodeString += string.Format("] ");
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
