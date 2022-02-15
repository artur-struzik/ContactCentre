using ContactManager.Handlers;
using System;
using Xunit;

namespace ContactManager.UnitTests
{
    public class HandlerValidatorUnitTests
    {
        [Fact]
        public void Validate_IsOk_WhenNoMoreThanOneManagerAndSupervisorsIsNoMoreThanAgents()
        {
            //Arrange
            var handler = new AgentHandler();
            var handler2 = new SupervisorHandler();
            var handler3 = GenManagerHandler.Get();

            handler.SetNext(handler2);
            handler2.SetNext(handler3);
            
            var validator = new HandlerValidator();

            //Act
            //Assert
            validator.Validate(handler);
        }

        [Fact]
        public void Validate_ThrowsArgumentException_WhenMoreSupervisorsThanAgents()
        {
            //Arrange
            var handler = new AgentHandler();
            var handler2 = new SupervisorHandler();
            var handler3 = new SupervisorHandler();

            handler.SetNext(handler2);
            handler2.SetNext(handler3);

            var validator = new HandlerValidator();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => validator.Validate(handler));
        }
    }
}
