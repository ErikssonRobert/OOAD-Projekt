using System;
using System.Collections.Generic;
using SkiaSharp;

namespace LoGoPrototype.Models
{
    public class Command
    {
        private List<Command> commands = new List<Command>();
        public List<Command> Commands
        {
            get
            {
                return commands;
            }
            set
            {
                commands = value;
            }
        }
        private string action;

        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
        public string Amount { get; set; }

        public Command(string action)
        {
            this.action = action;
        }

        public Command(string action, string amount)
        {
            this.action = action;
            this.Amount = amount;
        }

    }
}
