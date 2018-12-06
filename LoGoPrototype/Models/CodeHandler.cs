using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoGoPrototype.Models
{
    public class CodeHandler
    {
        private int index;
        private  string code;
        public  string Code 
        { 
            get
            {
                return code;
            }
            set
            {
                code = value;
                Console.WriteLine("...code in codehandler...");
                Console.WriteLine(code);
                //Console.WriteLine(Parse());
            }
        }

        public CodeHandler(string code)
        {
            Code = code;
            index = 0;
        }

        public List<Command> Parse()
        {
            List<Command> commands = new List<Command>();
            Regex movement = new Regex(@"^([fb]d|[lr]t)$");
            Regex pen = new Regex(@"^p");
            Regex repeat = new Regex(@"^repeat$");
            while (RemainingTokens())
            {
                string token = NextToken();
                if (movement.Match(token).Success)
                {
                    Command cmd = new Command(token, NextToken());
                    commands.Add(cmd);
                } else if (pen.Match(token).Success)
                {
                    Command cmd = new Command(token);
                    commands.Add(cmd);
                } else if (repeat.Match(token).Success)
                {
                    Command cmd = new Command(token, NextToken());
                    string toRepeat = GetRepeat();
                    CodeHandler codeHandler = new CodeHandler(toRepeat);
                    cmd.Commands = codeHandler.Parse();
                    commands.Add(cmd);
                }
            }
            foreach (Command cmd in commands)
            {
                Console.WriteLine(cmd.Action + " " + cmd.Amount);
            }
            return commands;
        }

        public string NextToken()
        {
            string token = "";
            char c = code[index];

            // If space, ignore
            if (c.Equals(' ') && RemainingTokens())
            {
                index++;
                return NextToken();
            }

            // If bracket, send back
            if (c.Equals('[') || c.Equals(']'))
            {
                index++;
                return c.ToString();
            }

            // Otherwise, accumulate until a space
            while ((!c.Equals(' ')) && RemainingTokens())
            {
                token += c;
                c = code[++index];
            }
            return token;
        }

        public string GetRepeat()
        {
            index--;
            while ((!Code[index++].Equals('[')) && RemainingTokens()) { }
            int start = index;

            int bracketCount = 1;
            while ((bracketCount > 0) && RemainingTokens())
            {
                char c = Code[index++];
                if (c.Equals('['))
                {
                    bracketCount++;
                } else if (c.Equals(']'))
                {
                    bracketCount--;
                }
            }
            int end = index;
            int length = end - start;
            return Code.Substring(start, length);
        }

        private bool RemainingTokens()
        {
            return (!code.Equals(null)) && index < code.Length - 1;
        }
    }
}
