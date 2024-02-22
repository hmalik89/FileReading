using System.Reflection;

namespace FileReadingReverseContent
{
    public class FileWritingTests
    {
        [Test]
        public void WriteInFile_ShouldWriteToFile()
        {
            // Arrange
            string expectedResult = "Hello, test to write in file!";

            Type type = typeof(fileReading);
            MethodInfo method = type.GetMethod("WriteInFile", BindingFlags.NonPublic | BindingFlags.Static);

            // Act
            string result = (string)method.Invoke(null, new object[] { "T" });

            // Assert
            Assert.AreEqual(expectedResult, result);

        }

        [Test]
        public void CreateFile_ShouldCreateFile()
        {
            // Arrange
            string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";

            // Act
            CreateFile();

            // Assert
            Assert.IsTrue(File.Exists(outFileName));
        }
    }
}