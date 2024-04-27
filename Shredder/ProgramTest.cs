using NUnit.Framework;
using System.IO;

namespace Shredder.Tests
{
    public class ProgramTests
    {
        [Test]
        public void ReadFile_ContainsStringsOnEachLine_ReturnsTrue()
        {
            // Arrange
            string filePath = "testFile.txt";
            string[] lines = { "Hello", "World", "GitHub Copilot" };
            File.WriteAllLines(filePath, lines);

            // Act
            bool containsStrings = Program.ReadFile(filePath);

            // Assert
            Assert.IsTrue(containsStrings);

            // Clean up
            File.Delete(filePath);
        }

        [Test]
        public void ReadFile_EmptyFile_ReturnsFalse()
        {
            // Arrange
            string filePath = "testFile.txt";
            File.WriteAllText(filePath, "");

            // Act
            bool containsStrings = Program.ReadFile(filePath);

            // Assert
            Assert.IsFalse(containsStrings);

            // Clean up
            File.Delete(filePath);
        }

        [Test]
        public void ReadFile_FileDoesNotExist_ReturnsFalse()
        {
            // Arrange
            string filePath = "nonExistentFile.txt";

            // Act
            bool containsStrings = Program.ReadFile(filePath);

            // Assert
            Assert.IsFalse(containsStrings);
        }
    }
}