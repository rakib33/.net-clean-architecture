using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TopUp.API.Controllers;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Topup.Queries;
using TopUp.Domain.Entities.TopUp;

namespace TopUp.UnitTest.API
{
    public class AgentBalanceControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AgentBalanceController _controller;

        public AgentBalanceControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AgentBalanceController(_mediatorMock.Object);
        }

        //Should return OK with valid data
        [Fact]
        public async Task GetAllTopupRequestMediatorAsync_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var expectedData = new List<TopUpRequest> {
            new TopUpRequest
            {
                Id = 1,
                AgentId = 2001,
                SysTransId = "TNX0638965607937184172",
                AdminOrAgentRemarks = "First Topup",
                AgentTnxNumber = "AGT123456",
                FOPTypeId = 2
            },
            new TopUpRequest
            {
                Id = 2,
                AgentId = 2002,
                SysTransId = "TNX0638965607937184173",
                AdminOrAgentRemarks = "Second Topup",
                AgentTnxNumber = "AGT654321",
                FOPTypeId = 1
            }
        };
            // Mock the Mediator
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), cancellationToken))
                         .ReturnsAsync(expectedData);
            // Act
            var result = await _controller.GetAllTopupRequestMediatorAsync(cancellationToken);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualData = Assert.IsAssignableFrom<IEnumerable<TopUpRequest>>(okResult.Value);
            Assert.Equal(expectedData, actualData);

            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), cancellationToken), Times.Once);
        }

        //Should return OK with empty list
        [Fact]
        public async Task GetAllTopupRequestMediatorAsync_ReturnsOkResult_EvenIfEmpty()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;
            var expectedData = new List<TopUpRequest>();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), cancellationToken))
                .ReturnsAsync(expectedData);

            // Act
            var result = await _controller.GetAllTopupRequestMediatorAsync(cancellationToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualData = Assert.IsAssignableFrom<IEnumerable<TopUpRequest>>(okResult.Value);
            Assert.Empty(actualData);

            _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), cancellationToken), Times.Once);
        }


        //Should handle TaskCanceledToken work gracefully
        [Fact]
        public async Task GetAllTopupRequestMediatorAsync_ShouldThrow_WhenCancellationRequested()
        {
            // Arrange
            var cts = new CancellationTokenSource();
            cts.Cancel();

            // Act
            await _controller.GetAllTopupRequestMediatorAsync(cts.Token);

            // Assert
            // Verify mediator received the correct token
            _mediatorMock.Verify(m => m.Send(
                It.IsAny<GetAllTopupRequestQuery>(),
                It.Is<CancellationToken>(t => t == cts.Token)
            ), Times.Once);
        }

        //Should propagate exception from Mediator
        [Fact]
        public async Task GetAllTopupRequestMediatorAsync_ShouldThrow_WhenMediatorThrows()
        {
            // Arrange
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new System.Exception("Mediator failed"));

            // Act
            var action = async () => await _controller.GetAllTopupRequestMediatorAsync(CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<System.Exception>()
                .WithMessage("Mediator failed");

            _mediatorMock.Verify(
                m => m.Send(It.IsAny<GetAllTopupRequestQuery>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

       

    }

}
