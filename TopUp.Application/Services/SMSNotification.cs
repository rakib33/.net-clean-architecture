

using TopUp.Application.Interfaces;

namespace TopUp.Application.Services
{
    public class SMSNotification : INotification
    {
        public Task<bool> Send()
        {
            //send sms
            //configure sms gateway, etc.
            return Task.FromResult(true);
        }
    }  
}
