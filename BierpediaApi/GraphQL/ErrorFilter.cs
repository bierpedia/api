using HotChocolate;
using Microsoft.Extensions.Logging;

public class ErrorFilter : IErrorFilter {
	private readonly ILogger<ErrorFilter> _logger;
	public ErrorFilter(ILogger<ErrorFilter> logger) {
		_logger = logger;
	}
	public IError OnError(IError error) {
		_logger.LogError($"{error.Code}: {error.Message}\n{error.Exception}");
		return error;
	}
}
