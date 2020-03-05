using NUnit.Framework;

namespace SubtitleFixer.UnitTests
{
	public class Tests
	{
		private Calculator calculator = new Calculator();
		
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Add_two_numbers()
		{
			// Arrange
			var a = 2;
			var b = 3;

			// Act
			var result = calculator.Add(a, b);

			calculator.FirstNumber = 7;
			calculator.SecondNumber = 8;
			var result1 = calculator.Add();

			// Assert
			Assert.AreEqual(5,result);
			Assert.AreEqual(15,result1);
		}

		[Test]
		public void Subtract()
		{
			// Arrange
			var a = 5;
			var b = 4;

			// Act 
			var result = calculator.Subtract(a, b);

			// Assert
			Assert.AreEqual(1,result);
		}

		[Test]
		public void SimpleTest()
		{
			var instance = new Calculator();
			var instance2 = instance;
			instance=new Calculator();

			Assert.AreNotSame(instance,instance2);
		}
	}
}