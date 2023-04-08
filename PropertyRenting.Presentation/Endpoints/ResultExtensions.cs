using ErrorOr;

namespace PropertyRenting.Presentation.Endpoints;

public static class ResultExtensions
{
    public static IResult Failed(List<ErrorOr.Error> errors)
    {
        var firstError = errors[0];
        return firstError.Type switch
        {
            ErrorType.Conflict => Results.Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Code, detail: firstError.Description),
            ErrorType.Validation => Results.ValidationProblem(statusCode: StatusCodes.Status400BadRequest, errors: errors.ToDictionary(x => x.Code, x => new[] { x.Description })),
            ErrorType.NotFound => Results.Problem(statusCode: StatusCodes.Status404NotFound, title: firstError.Code, detail: firstError.Description),
            _ => Results.Problem(statusCode: StatusCodes.Status500InternalServerError, title: firstError.Code, detail: firstError.Description),
        };
    }
}
