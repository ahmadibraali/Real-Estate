namespace Real_Estate.Application.Helpers
{
    public static class CodeGenerator
    {
        public static string PropertyCodeGenerator()
        {
            Random randomNumber = new Random();
            int number = randomNumber.Next(1, 1000000);
            string generatedCode = number.ToString("000000");
            return generatedCode;
        }
    }
}
