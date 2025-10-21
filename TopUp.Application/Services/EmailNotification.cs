
using TopUp.Application.Interfaces;

namespace TopUp.Application.Services
{
    public class EmailNotification : INotification
    {
        public Task<bool> Send()
        {
            //send mail
            //configure mail server, etc.
            return Task.FromResult(true);
        }
    }
}
