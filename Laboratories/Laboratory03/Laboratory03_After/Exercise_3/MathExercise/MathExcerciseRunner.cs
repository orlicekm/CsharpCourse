namespace Exercise_3.MathExercise
{
    internal class MathExerciseRunner
    {
        private readonly INumberReader numberReader;
        private readonly ITextWriter textWriter;

        public MathExerciseRunner(INumberReader numberReader, ITextWriter textWriter)
        {
            this.numberReader = numberReader;
            this.textWriter = textWriter;
        }

        public void Test(IMathOperation mathExercise)
        {
            var leftOperand = numberReader.ReadNumber($"Write 1. number for {mathExercise.OperationName}: ");
            var rightOperand = numberReader.ReadNumber($"Write 1. number for {mathExercise.OperationName}: ");

            var askForSolution = $"{leftOperand} {mathExercise.Operand} {rightOperand} = ";
            var userAnswer = numberReader.ReadNumber(askForSolution);

            var correctResult = mathExercise.GetCorrectResult(leftOperand, rightOperand);
            WriteResultMessage(correctResult, userAnswer);
        }

        private void WriteResultMessage(int correctResult, int userAnswer)
        {
            var wasUserAnswerCorrect = correctResult == userAnswer;
            var wasAnswerCorrectMessage = GetWasAnswerCorrectMessage(wasUserAnswerCorrect);
            var messageType = GetMessageType(wasUserAnswerCorrect);

            var message = $"Your answer \"{userAnswer}\" {wasAnswerCorrectMessage}";
            textWriter.Write(message, messageType);
        }

        private static MessageType GetMessageType(bool wasUserAnswerCorrect)
        {
            return wasUserAnswerCorrect ? MessageType.Success : MessageType.Fail;
        }

        private static string GetWasAnswerCorrectMessage(bool wasUserAnswerCorrect)
        {
            return wasUserAnswerCorrect ? "is wrong" : "is right";
        }
    }
}