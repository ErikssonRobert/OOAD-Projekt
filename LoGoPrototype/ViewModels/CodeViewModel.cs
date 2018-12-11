using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LoGoPrototype.Models;
using LoGoPrototype.Validation;

namespace LoGoPrototype.ViewModels
{
    public class CodeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IsNotNullOrEmptyRule<string> rule;
        private CodeHandler codeHandler;
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
            }
        }

        // Constructor
        public CodeViewModel()
        {
            AddValidationRule();
            CodeString = "repeat 36 [ lt 10 fd 1 repeat 120 [ fd 2 rt 3 ] ]";
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
