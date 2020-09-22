//using System;
using System.IO;

namespace Sender
{
    public class CheckInputFileValid
    {
        

        public bool CheckFileExtensionIsCorrect(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Extension.Equals(".csv"))
            {
                return true;
            }
            
            return false;
        }

        public bool CheckIfFileExistsAtSpecifiedLocation(string path)
        {
            if (File.Exists(path))
            {

                return true;
            }
            
            return false;
        }

        public bool CheckFileExists(string path)
        {
            bool isExtensionCorrect =CheckFileExtensionIsCorrect(path);
            bool isLocationValid =CheckIfFileExistsAtSpecifiedLocation(path);
            if (isExtensionCorrect && isLocationValid)
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
