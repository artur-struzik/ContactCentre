using ContactManager.Handlers;
using ContactManager.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContactManager.IntegrationTests
{
    [TestClass]
    public class RouteRequestTests
    {
        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenAgentHandlesVoiceCall()
        {
            //Arrange
            var handler = new AgentHandler();
            var requests = new IRequest[1] { new Request(1,RequestType.VoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        } 

        [TestMethod]
        
        public void DispatchRequest_ReturnsTrue_WhenSupervisorHandlesSecondVoiceCall()
        {
            //Arrange
            var handler = new AgentHandler();
            var supervisor = new SupervisorHandler();
            handler.SetNext(supervisor);

            var requests = new IRequest[2] { 
                new Request(1, RequestType.VoiceCall), 
                new Request(2, RequestType.VoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenAgentHandlesSecondNonVoiceCall()
        {
            //Arrange
            var handler = new AgentHandler();
            var requests = new IRequest[2] { 
                new Request(1, RequestType.NonVoiceCall), 
                new Request(2, RequestType.NonVoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenSupervisorHandlesTwoNonVoiceCalls()
        {
            //Arrange
            var handler = new AgentHandler();
            var supervisor = new SupervisorHandler();
            handler.SetNext(supervisor);

            var requests = new IRequest[3] { 
                new Request(1, RequestType.VoiceCall), 
                new Request(2, RequestType.NonVoiceCall), 
                new Request(3, RequestType.NonVoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenManagerHandlesNonVoiceCall()
        {
            //Arrange
            var handler = new AgentHandler();
            var supervisor = new SupervisorHandler();
            var manager = new GeneralManagerTransient();
            handler.SetNext(supervisor);
            supervisor.SetNext(manager);

            var requests = new IRequest[4] { 
                new Request(1, RequestType.VoiceCall),
                new Request(2, RequestType.NonVoiceCall), 
                new Request(3, RequestType.NonVoiceCall), 
                new Request(4, RequestType.NonVoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsFalse_WhenAllHandlesAreBusy()
        {
            //Arrange
            var handler = new AgentHandler();
            var supervisor = new SupervisorHandler();
            var manager = new GeneralManagerTransient();
            handler.SetNext(supervisor);
            supervisor.SetNext(manager);

            var requests = new IRequest[5] { 
                new Request(1, RequestType.VoiceCall), 
                new Request(2, RequestType.NonVoiceCall), 
                new Request(3, RequestType.VoiceCall), 
                new Request(4, RequestType.NonVoiceCall), 
                new Request(5, RequestType.NonVoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenAllHandlersHaveOpenRequestButOneStillCanHandleTheNewOne()
        {
            //Arrange
            var handler = new AgentHandler();
            var supervisor = new SupervisorHandler();
            var manager = new GeneralManagerTransient();
            handler.SetNext(supervisor);
            supervisor.SetNext(manager);

            var requests = new IRequest[4] { 
                new Request(1, RequestType.VoiceCall), 
                new Request(2, RequestType.NonVoiceCall), 
                new Request(3, RequestType.VoiceCall), 
                new Request(4, RequestType.NonVoiceCall) };

            //Act
            bool actual = DispatchAllRequests(handler, requests);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DispatchRequest_ReturnsTrue_WhenHandlerIsBusyAndEndRequestBeforeTheNewOne()
        {
            //Arrange
            var handler = new AgentHandler();

            var routeRequest = new RouteRequest(handler, new HandlerValidator());

            var request1 = new Request(1, RequestType.VoiceCall);
            var request2 = new Request(2, RequestType.VoiceCall);

            //Act
            routeRequest.DispatchRequest(request1);
            handler.EndRequest(request1.Id);

            bool actual = routeRequest.DispatchRequest(request2);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void RouteRequest_ThrowsArgumentException_WhenHandlerIsNotValid()
        {
            //Arrange
            var handler = new AgentHandler();
            var handler2 = new SupervisorHandler();
            var handler3 = new SupervisorHandler();

            handler.SetNext(handler2);
            handler2.SetNext(handler3);

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new RouteRequest(handler, new HandlerValidator()));
        }

        private static bool DispatchAllRequests(IHandler handler, IRequest[] requests)
        {
            var routeRequest = new RouteRequest(handler, new HandlerValidator());

            foreach (var request in requests)
            {
                if (!routeRequest.DispatchRequest(request))
                    return false;
            }

            return true;
        }
    }
}