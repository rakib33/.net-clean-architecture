using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TopUp.API.Controllers;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.DTOs.Request;
using TopUp.Application.DTOs.Response;
using TopUp.Application.Features.Topup.Queries;

namespace TopUp.UnitTest.API.Controller;
public class AgentBalanceControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly AgentBalanceController _controller;

    public AgentBalanceControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new AgentBalanceController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetTopUpRequest_ReturnsOkResult()
    {
        var dto = new GetTopUpRequest();
        var fakeResponse = new StandardApiResponseModel();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetTopUpRequestQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(fakeResponse);

        // Act
        var result = await _controller.GetTopUpRequests(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        okResult.Value.Should().BeEquivalentTo(fakeResponse);

        // Optional: Verify mediator was called exactly once
        _mediatorMock.Verify(m => m.Send(It.IsAny<GetTopUpRequestQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
