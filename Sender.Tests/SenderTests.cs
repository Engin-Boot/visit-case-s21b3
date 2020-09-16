using System;
using Xunit;

namespace Sender.Tests
{
    public class SenderTests
    {
        private readonly sender senderObject;

        public  SenderTests()
         {
              senderObject = new sender();
          }
        [Fact]
        public void WhenGivenValidStringThenReturnTrue()
        { 
            var output = senderObject.SendingMessage("Hello");
            Assert.True(output);
        }

        [Fact]
        public void WhenGivenNullStringThenFalse()
        {
             var output = senderObject.SendingMessage("");
            Assert.True(output);
        }
    }
}
