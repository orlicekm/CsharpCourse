namespace Exercise_3.MathExercise
{
    internal class MultiplicationMathOperation : IMathOperation
    {
        public char Operand => '*';
        public string OperationName => "násobení";

        public int GetCorrectResult(int leftOperand, int rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}