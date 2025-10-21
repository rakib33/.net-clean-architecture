namespace TopUp.Application.Interfaces
{
    public interface INotification
    {
        Task<bool> Send();
    }
}
