using ContactManager.Requests;
using Xunit;

namespace ContactManager.UnitTests
{
    public class GenManagerHandlerUnitTests
    {
        [Fact]
        public void CanHandleVoiceCall_ReturnsTrue_WhenHandlerHaveNoRequests()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request = new Request(1, RequestType.VoiceCall);

            //Act
            var actual = handler.Handle(request);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void CanHandleNonVoiceCall_ReturnsTrue_WhenHandlerHaveNoRequests()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request = new Request(1, RequestType.NonVoiceCall);

            //Act
            var actual = handler.Handle(request);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void CanHandleNonVoiceCall_ReturnsFalse_WhenHandlerHaveNonVoiceCallRequest()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request1 = new Request(1, RequestType.NonVoiceCall);
            var request2 = new Request(2, RequestType.NonVoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanHandleNonVoiceCall_ReturnsFalse_WhenHandlerHaveVoiceCallRequest()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request1 = new Request(1, RequestType.VoiceCall);
            var request2 = new Request(2, RequestType.NonVoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanHandleVoiceCall_ReturnsFalse_WhenHandlerHaveNonVoiceCallRequest()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request1 = new Request(1, RequestType.NonVoiceCall);
            var request2 = new Request(2, RequestType.VoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanHandleVoiceCall_ReturnsFalse_WhenHandlerHaveVoiceCallRequest()
        {
            //Arrange
            var handler = new GeneralManagerTransient();
            var request1 = new Request(1, RequestType.VoiceCall);
            var request2 = new Request(2, RequestType.VoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.False(actual);
        }
    }
}
