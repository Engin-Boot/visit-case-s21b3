//using System;
using System.IO;

namespace Sender
{
    public class CheckInputFileValid
    {
        bool _fileValid = true;

        public bool CheckFileExtensionIsCorrect(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Extension.Equals(".csv"))
            {
                return true;
            }
            _fileValid = false;
            return false;
        }

        public bool CheckIfFileExistsAtSpecifiedLocation(string path)
        {
            if (File.Exists(path))
            {

                return true;
            }
            _fileValid = false;
            return false;
        }

        public bool CheckFileExists(string path)
        {
            CheckFileExtensionIsCorrect(path);
            CheckIfFileExistsAtSpecifiedLocation(path);
            if (_fileValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
