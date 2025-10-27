using FluentAssertions;
using Moq;
using TopUp.API.Controllers;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Topup.Handlers;
using TopUp.Application.Features.Topup.Queries;
using TopUp.Domain.Entities;
using TopUp.Domain.Entities.TopUp;
using TopUp.Domain.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TopUp.UnitTest.Application.Topup;

public class GetAllTopupRequestHandlerTest
{
    private readonly Mock<IBaseUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRepository<TopUpRequest>> _repositoryMock;
    private readonly GetAllTopupRequestHandler _handler;

    public GetAllTopupRequestHandlerTest()
    {
        _unitOfWorkMock = new Mock<IBaseUnitOfWork>();
        _repositoryMock = new Mock<IRepository<TopUpRequest>>();

        _unitOfWorkMock.Setup(u => u.Repository<TopUpRequest>())
                       .Returns(_repositoryMock.Object);

        _handler = new GetAllTopupRequestHandler(_unitOfWorkMock.Object);
    }

    //Should return ordered list
    [Fact]
    public async Task Handle_ShouldReturnOrderedList_WhenDataExists()
    {
        // Arrange
        var expectedData = new List<TopUpRequest> {
                new TopUpRequest
                {
                    Id = 1,
                    AgentId = 2001,
                    SysTransId = "TNX0638965607937184172",
                    AdminOrAgentRemarks = "First Topup",
                    AgentTnxNumber = "AGT123456",
                    FOPTypeId = 2,
                    CreatedDate = DateTime.Now.AddDays(-1)
                },
                new TopUpRequest
                {
                    Id = 2,
                    AgentId = 2002,
                    SysTransId = "TNX0638965607937184173",
                    AdminOrAgentRemarks = "Second Topup",
                    AgentTnxNumber = "AGT654321",
                    FOPTypeId = 1,
                    CreatedDate = DateTime.Now
                }
            }.AsQueryable();

        // mock async IQureryable to IEnumerable
        var asyncData = new TestAsyncEnumerable<TopUpRequest>(expectedData);

        //return IEnumerable data
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(asyncData);
       

        var query = new GetAllTopupRequestQuery(CancellationToken.None);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().HaveCount(2);
        result.First().Id.Should().Be(2); // Ordered descending by date
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    //Should return empty list if repository returns empty
    [Fact]
    public async Task Handle_ShouldReturnEmptyList_WhenRepositoryEmpty()
    {

        // mock async IQureryable to IEnumerable
        var asyncData = new TestAsyncEnumerable<TopUpRequest>(new List<TopUpRequest>().AsQueryable());
        _repositoryMock.Setup(r => r.GetAllAsync())
                       .ReturnsAsync(asyncData);

        var result = await _handler.Handle(new GetAllTopupRequestQuery(CancellationToken.None), CancellationToken.None);

        result.Should().BeEmpty();
    }

    //Should handle null result gracefully
    [Fact]
    public async Task Handle_ShouldThrow_WhenRepositoryReturnsNull()
    {
        _repositoryMock.Setup(r => r.GetAllAsync())
                       .ReturnsAsync((IQueryable<TopUpRequest>?)null);
        //Linq extension method OrderByDescending from GetAllTopupRequestQuery
        //throw ArgumentNullException not NullReferenceException
        Func<Task> act = async () => await _handler.Handle(new GetAllTopupRequestQuery(CancellationToken.None), CancellationToken.None);

        await act.Should().ThrowAsync<ArgumentNullException>().WithMessage("*source*");
    }

    //Should propagate exception
    [Fact]
    public async Task Handle_ShouldThrow_WhenRepositoryThrows()
    {
        _repositoryMock.Setup(r => r.GetAllAsync())
                       .ThrowsAsync(new Exception("Database error"));

        var act = async () => await _handler.Handle(new GetAllTopupRequestQuery(CancellationToken.None), CancellationToken.None);

        await act.Should().ThrowAsync<Exception>().WithMessage("Database error");
    }

    //Should call repository once
    [Fact]
    public async Task Handle_ShouldCallRepositoryOnce()
    {
        // mock async IQureryable to IEnumerable
        var asyncData = new TestAsyncEnumerable<TopUpRequest>(new List<TopUpRequest>().AsQueryable());
        _repositoryMock.Setup(r => r.GetAllAsync())
                       .ReturnsAsync(asyncData);

        await _handler.Handle(new GetAllTopupRequestQuery(CancellationToken.None), CancellationToken.None);

        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }
    
}