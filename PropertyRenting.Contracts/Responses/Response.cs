namespace PropertyRenting.Contracts.Responses;

public class Response<TResponse>
{
    #region CTORS :
    private Response(TResponse response)
    {
        this.Data = response;
        this.Succeded = true;
    }
    private Response(HashSet<Error> errors)
    {
        this.Errors = Errors;
        this.Succeded = false;
    }
    #endregion

    #region PROPS :
    public bool Succeded { get; private set; }
    public HashSet<Error> Errors { get; private set; }
    public TResponse Data { get; private set; }
    #endregion

    #region Methods :
    public static Response<TResponse> Success(TResponse response)
    {
        return new Response<TResponse>(response);
    }
    public static Response<TResponse> Failure(HashSet<Error> errors)
    {
        return new Response<TResponse>(errors);
    }
    #endregion
}
public class Error
{
    public string ErrorCode { get; set; }
    public string Details { get; set; }
}
