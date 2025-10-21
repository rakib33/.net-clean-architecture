namespace TopUp.Application.Common.CustomMediator
{
    /// <summary>
    /// use reflection + DI to resolve the handler dynamically.
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _provider;

        public Mediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = _provider.GetService(handlerType)!;

            if (handler == null)
                throw new Exception($"Handler for {request.GetType().Name} not found.");

            // Pass the cancellation token
            return await handler.Handle((dynamic)request, cancellationToken);
        }
    }
}
