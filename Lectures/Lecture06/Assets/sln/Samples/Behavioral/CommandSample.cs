using System;
using System.Collections.Generic;

namespace Samples.Behavioral
{
    public class CommandSample
    {
        public static void Main()
        {
            // Create user and let her compute
            var user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);
        }
    }

    internal abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    internal class CalculatorCommand : Command
    {
        private readonly Calculator calculator;
        private char _operator;
        private int operand;

        public CalculatorCommand(Calculator calculator,
            char @operator, int operand)
        {
            this.calculator = calculator;
            _operator = @operator;
            this.operand = operand;
        }

        public char Operator
        {
            set => _operator = value;
        }

        public int Operand
        {
            set => operand = value;
        }

        public override void Execute()
        {
            calculator.Operation(_operator, operand);
        }

        public override void UnExecute()
        {
            calculator.Operation(Undo(_operator), operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';
                default:
                    throw new
                        ArgumentException("@_operator");
            }
        }
    }

    internal class Calculator
    {
        private int curr;

        public void Operation(char _operator, int operand)
        {
            switch (_operator)
            {
                case '+':
                    curr += operand;
                    break;
                case '-':
                    curr -= operand;
                    break;
                case '*':
                    curr *= operand;
                    break;
                case '/':
                    curr /= operand;
                    break;
            }

            Console.WriteLine(
                $"Current value = {curr,3} (following {_operator} {operand})");
        }
    }

    internal class User
    {
        private readonly Calculator calculator = new Calculator();
        private readonly List<Command> commands = new List<Command>();
        private int current;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            for (var i = 0; i < levels; i++)
                if (current < commands.Count - 1)
                {
                    var command = commands[current++];
                    command.Execute();
                }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            for (var i = 0; i < levels; i++)
                if (current > 0)
                {
                    var command = commands[--current];
                    command.UnExecute();
                }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(
                calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            commands.Add(command);
            current++;
        }
    }
}