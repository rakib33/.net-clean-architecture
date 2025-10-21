namespace TopUp.Application.Interfaces
{
    public interface ISlotService
    {
        Task<bool> AddSlotAsync(int doctorId, DateTime startTime, DateTime endTime);

    }
}
