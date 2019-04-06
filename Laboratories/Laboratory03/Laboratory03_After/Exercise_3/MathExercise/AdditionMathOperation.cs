namespace Exercise_3.MathExercise
{
    internal class AdditionMathOperation : IMathOperation
    {
        public char Operand => '+';
        public string OperationName => "sčítání";

        public int GetCorrectResult(int leftOperand, int rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}