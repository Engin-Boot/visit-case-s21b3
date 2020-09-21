//using System;
using System.IO;
using Xunit;

namespace Sender.Tests
{
    public class SenderTests
    {
        private readonly GetInputFilePath _senderObj = new GetInputFilePath();

        [Fact]
        public void WhenPathOfSenderInputFileIsNullOrEmptyThenFileCannotBeRead()
        {
            string csvFilePath = _senderObj.InputFilePath();
            bool ans = string.IsNullOrEmpty(csvFilePath);
            Assert.False(ans, "input file path is null/empty");
        }

        [Fact]
        public void WhenFileExtensionIsCsvThenSenderWillReadFile()
        {
            string filePath = _senderObj.InputFilePath();
            FileInfo infoOfInputFile = new FileInfo(filePath);
            //bool isFileExtensionCorrect = false;
            bool isFileExtensionCorrect = infoOfInputFile.Extension.Equals(".csv");
            Assert.True(isFileExtensionCorrect, "correct file extension");
        }
        

        [Fact]
        public void WhenFileExistsAtTheSpecifiedLocationThenSenderWillReadTheFile()
        {
            bool isFilePresent = false;
            isFilePresent = File.Exists("SenderInputCsv.csv");
            Assert.True(isFilePresent, filePath);
        }
        
    }
}
