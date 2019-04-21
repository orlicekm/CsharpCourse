namespace Exercise_3.MathExercise
{
    internal class SubtractionMathOperation : IMathOperation
    {
        public char Operand => '-';
        public string OperationName => "subtraction";

        public int GetCorrectResult(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}