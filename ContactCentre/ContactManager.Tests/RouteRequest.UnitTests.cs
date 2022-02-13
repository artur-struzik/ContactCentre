using ContactManager.Handlers;
using ContactManager.Requests;
using Xunit;
using Moq;

namespace ContactManager.UnitTests
{
    public class RoutRequestUnitTests
    {
        [Fact]
        public void DispatchCall_ReturnsTrue_WhenHandlerHandledRequest()
        {
            //Arrange
            var requestMock = new Mock<IRequest>();
            var handlerMock = new Mock<IHandler>();
            handlerMock.Setup(x => x.Handle(It.IsAny<IRequest>())).Returns(true);
            var handlerValidatorMock = new Mock<IHandlerValidator>();

            var routeRequest = new RouteRequest(handlerMock.Object, handlerValidatorMock.Object);

            //Act
            var result = routeRequest.DispatchRequest(requestMock.Object);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DispatchCall_ReturnsFalse_WhenHandlerNotHandledRequest()
        {
            //Arrange
            var requestMock = new Mock<IRequest>();
            var handlerMock = new Mock<IHandler>();
            handlerMock.Setup(x => x.Handle(It.IsAny<IRequest>())).Returns(false);
            var handlerValidatorMock = new Mock<IHandlerValidator>();

            var routeRequest = new RouteRequest(handlerMock.Object, handlerValidatorMock.Object);

            //Act
            var result = routeRequest.DispatchRequest(requestMock.Object);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void EndRequest_Executes_WhenHandlerEndRequestIsOk()
        {
            //Arrange
            var handlerMock = new Mock<IHandler>();
            var handlerValidatorMock = new Mock<IHandlerValidator>();

            var routeRequest = new RouteRequest(handlerMock.Object, handlerValidatorMock.Object);

            //Act
            //Assert
            routeRequest.EndRequest(1);
        }

        [Fact]
        public void EndRequest_Throws_WhenHandlerEndRequestThrows()
        {
            //Arrange
            var handlerMock = new Mock<IHandler>();
            handlerMock.Setup(x => x.EndRequest(It.IsAny<int>())).Throws(new System.ArgumentException());
            var handlerValidatorMock = new Mock<IHandlerValidator>();

            var routeRequest = new RouteRequest(handlerMock.Object, handlerValidatorMock.Object);

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => routeRequest.EndRequest(1));
        }
    }
}