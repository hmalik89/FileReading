
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateFile_ShouldCreateFile()
        {
            //Arrange
            string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";
            // Act
            FileReadingProgram.CreateFile();

            // Assert
            Assert.IsTrue(File.Exists(outFileName));
        }

        [TestMethod]
        public void FirstLineChar_ShouldReturnCorrectOutput()
        {
            // Arrange
            string[] inputLines = { "my First line test", "my Second line", "my Third line 153" };

            // Act
            string result = FileReadingProgram.FirstLineChar(inputLines, inputLines[0], inputLines[^1]);

            // Assert
            Assert.AreEqual("my Third line 15m", result);
        }

        [TestMethod]
        public void SecondLastLineLastChar_ShouldReturnCorrectOutput()
        {
            // Arrange
            string[] inputLines = { "Test line 1", "Test second line 165", "Third line Test" };

            // Act
            string result = FileReadingProgram.SecondLastLineLastChar(inputLines, inputLines[^2], inputLines[1]);

            // Assert
            Assert.AreEqual("5est second line 165", result);
        }

        [TestMethod]
        public void LastLineChar_ShouldReturnCorrectOutput()
        {
            // Arrange
            string[] inputLines = { "First line", "Second line", "Third line" };

            // Act
            string result = FileReadingProgram.LastLineChar(inputLines, inputLines[0], inputLines[^1]);

            // Assert
            Assert.AreEqual("eirst line", result);
        }

        [TestMethod]
        public void WriteInFile_ShouldWriteToFile()
        {
            string fileResponse = "";

            string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";
            // Arrange
            string expectedResult = "Hello, test to write in file!";
            if (File.Exists(outFileName))
            {
                File.Delete(outFileName);
            }

            // Act
            FileReadingProgram.WriteInFile(expectedResult);

            using (StreamReader sr = File.OpenText(outFileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    fileResponse += s;
                }
            }

            // Assert
            Assert.AreEqual(expectedResult, fileResponse);

        }
    }
}