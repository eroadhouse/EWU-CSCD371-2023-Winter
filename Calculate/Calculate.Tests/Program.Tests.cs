namespace Calculate.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_CreateProgram_Success()
        {
            Program program = new();
            StringWriter writer = new StringWriter();
            StringReader reader = new StringReader("Test input");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            program.WriteLine("Test string");

            Assert.AreEqual<string>("Test string", writer.ToString().Trim());
            Assert.AreEqual<string>("Test input", program.ReadLine()!.Trim());
        }

        [TestMethod]
        public void Program_GiveExpression_CalculateResult()
        {
            Program program = new();
            StringWriter writer = new StringWriter();
            StringReader reader = new StringReader("1 + 2");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            string? input = program.ReadLine();
            bool success = program.Calc.TryCalculate(input!, out int result);
            program.WriteLine(result.ToString());

            Assert.IsTrue( success );
            Assert.AreEqual<string>("3", writer.ToString().Trim());
        }

        [TestMethod]
        public void Program_GiveInvalidExpression_CalculateResult()
        {
            Program program = new();
            StringWriter writer = new StringWriter();
            StringReader reader = new StringReader("1 ) 2");
            System.Console.SetOut(writer);
            System.Console.SetIn(reader);

            string? input = program.ReadLine();
            bool success = program.Calc.TryCalculate(input!, out int result);
            program.WriteLine(result.ToString());

            Assert.IsFalse(success);
            Assert.AreEqual<string>("0", writer.ToString().Trim());
        }
    }
}