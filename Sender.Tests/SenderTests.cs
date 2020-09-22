//using System;
using System.IO;
using Xunit;
using System.Reflection;

namespace Sender.Tests
{
     public abstract class SenderTests
    {
        
        private static string GivePath(string file)
        {
            string csvFilePath = "";
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (executableLocation != null)
            {
                csvFilePath = Path.Combine(executableLocation, file);

            }

            return csvFilePath;
        }
       /*
        [Fact]
        public static void WhenFileIsPathIsGivenThenItsValidityIsChecked()
        {
            var fr = new CheckInputFileValid();
            string path = GivePath("SenderInputCsv.csv");
            Assert.True(fr.CheckFileExists(path));

        }
       */
        [Fact]
        public static void WhenFileExtensionIsNotCsv()
        {
            var ff = new CheckInputFileValid();
            string path = GivePath("SenderInputCsv.cst");
            Assert.False(ff.CheckFileExtensionIsCorrect(path));
        }
        [Fact]
        public static void WhenLocationSpecifiedOfFileIsNotCorrectThenSenderCannotRead()
        {
            var ff = new CheckInputFileValid();
            string path = GivePath("SenderCsv.csv");
            Assert.False(ff.CheckIfFileExistsAtSpecifiedLocation(path));
        }
        [Fact]
        public static void WhenWrongFileIsInputThenSenderCannotRead()
        {
            var ff = new CheckInputFileValid();
            string path = GivePath("SenderCsv.cst");
            Assert.False(ff.CheckFileExists(path));
        }
    }
}
