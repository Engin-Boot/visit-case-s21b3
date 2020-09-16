using System;

namespace Sender
{
    public class sender
    {
        public bool SendingMessage(String input)
         {
            if (input.Length != 0)
            {
                String output = input;
                Console.WriteLine(output);
                return true;
            }
            else
            {
                return false;
            }
         }
    }
}
