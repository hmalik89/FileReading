using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FileReadingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateFile_ShouldCreateFile()
        {
            // Arrange
            string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";

            // Act
            CreateFile();

            // Assert
            Assert.IsTrue(File.Exists(outFileName));
        }

        [TestMethod]
        public void WriteInFile_ShouldWriteToFile()
        {
            // Arrange
            string expectedResult = "Hello, test to write in file!";

            // Assert
            Assert.AreEqual(expectedResult, "");

        }
    }
}
