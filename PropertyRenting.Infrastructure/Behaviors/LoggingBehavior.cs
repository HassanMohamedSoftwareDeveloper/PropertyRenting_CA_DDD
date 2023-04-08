using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace PropertyRenting.Infrastructure.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        Stopwatch stopwatch = new();
        stopwatch.Start();
        _logger.LogInformation("Start processing ({name}) with parameters ({@params}).", requestName, request.ToString());

        var response = await next();
        stopwatch.Stop();
        _logger.LogInformation("Finish processing ({name}) at ({elapsed}) ms.", requestName, stopwatch.ElapsedMilliseconds);
        return response;
    }
}