using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Reflection;

namespace FileReading.UnitTest
{
    [TestClass]
    public class FileReadingTests
    {
        [TestMethod]
        public void CreateFile_ShouldCreateFile()
        {
            //Arrange
            string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";

            // Act
            FileReadingProgram.CreateFile();

            var response = File.Exists(outFileName);

            // Assert
            //Assert.Equals(true, response);
        }

        [TestMethod]
        public void WriteInFile_ShouldWriteToFile()
        {
            // Arrange
            string expectedResult = "Hello, test to write in file!";

            // Assert
            //Assert.AreEqual(expectedResult, "");

        }

        [TestMethod]
        public void MultiplyTwoNumbersTest()
        {
            // Arrange 
            TypeInfo program = typeof(FileReadingProgram).GetTypeInfo();
            var multiplyToNumbersMethod = program.DeclaredMethods.Single(m => m.Name.Contains("MultiplyTwoNumbers"));

            // Act
            int result = (int)multiplyToNumbersMethod.Invoke(null, new object[] { 3, 4 });

            // Assert 
            //Assert.Equals(12, result);
        }
    }
}