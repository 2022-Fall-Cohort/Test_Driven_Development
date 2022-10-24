namespace TestProject1
{
    using ConsoleApp1;

    public class UnitTest1
    {
        [Fact] // "Decorator"
        public void Should_Add_Two_Numbers()
        {
            // Arrange

            int addNum1 = 5;
            int addNum2 = 10;
            var sum = new Calculator();

            // Act

            int result = sum.Add(addNum1, addNum2);

            // Assert

            Assert.Equal(15, result);

            //Console.WriteLine($"(Add)result is {result}");
        }

        [Fact] // "Decorator"
        public void Should_Divide_Two_Numbers()
        {
            // Arrange

            double divNum1 = 5;
            double divNum2 = 10;
            var division = new Calculator();

            // Act

            double result = division.Divide(divNum1, divNum2);

            // Assert

            Assert.Equal(.5, result);

            //Console.WriteLine($"(Div)result is {result}");
        }
    }
}