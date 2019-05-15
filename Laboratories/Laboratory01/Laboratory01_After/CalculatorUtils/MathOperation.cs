using System.ComponentModel;

namespace CalculatorUtils
{
    public enum MathOperation
    {
        [Description("+")] Addition,
        [Description("-")] Subtraction,
        [Description("*")] Multiplication,
        [Description("/")] Division
    }
}