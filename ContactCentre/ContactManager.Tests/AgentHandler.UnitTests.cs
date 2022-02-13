using ContactManager.Handlers;
using ContactManager.Requests;
using Xunit;

namespace ContactManager.UnitTests
{
    public class AgentHandlerUnitTests
    {
        [Fact]
        public void HandleVoiceCall_ReturnsTrue_WhenHandlerHaveNoRequests()
        {
            //Arrange
            var handler = new AgentHandler();
            var request = new Request(1, RequestType.VoiceCall);

            //Act
            var actual = handler.Handle(request);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void HandleNonVoiceCall_ReturnsTrue_WhenHandlerHaveNoRequests()
        {
            //Arrange
            var handler = new AgentHandler();
            var request = new Request(1, RequestType.NonVoiceCall);

            //Act
            var actual = handler.Handle(request);

            //Assert
            Assert.True(actual);
        }

        [Fact]
        public void CanHandleVoiceCallRequest_ReturnsFalse_WhenHandlerAlreadyHaveRequest()
        {
            //Arrange
            var handler = new AgentHandler();
            var request1 = new Request(1, RequestType.NonVoiceCall);
            var request2 = new Request(2, RequestType.VoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanHandleNonVoiceCallRequest_ReturnsTrue_WhenHandlerAlreadyHaveNonVoiceCall()
        {
            //Arrange
            var handler = new AgentHandler();
            var request1 = new Request(1, RequestType.NonVoiceCall);
            var request2 = new Request(2, RequestType.NonVoiceCall);

            //Act
            handler.Handle(request1);
            var actual = handler.Handle(request2);

            //Assert
            Assert.True(actual);
        }
    }
}
