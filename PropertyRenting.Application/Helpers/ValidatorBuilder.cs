using PropertyRenting.Domain.Primitives;

namespace PropertyRenting.Application.Helpers;

public class ValidatorBuilder
{
    #region CTORS :
    private ValidatorBuilder() => _errors.Clear();
    #endregion

    #region Fields :
    private readonly HashSet<Error> _errors = new();
    #endregion

    #region Methods :
    public static ValidatorBuilder Init() => new();
    public ValidatorBuilder Append<TType>(ErrorOr<TType> value)
    {
        if (value.IsError)
            _errors.Add(value.FirstError);
        return this;
    }
    public ValidatorBuilder Append<TEnum>(TEnum value, Error error) where TEnum : Enumeration<TEnum>
    {
        if (value is null)
            _errors.Add(error);
        return this;
    }
    public ValidatorBuilder Append(params ErrorOr<object>[] values)
    {
        foreach (var value in values)
        {
            Append(value);
        }
        return this;
    }
    public bool IsInValid(out List<Error> errors)
    {
        errors = _errors?.ToList();
        return _errors.Any();
    }
    #endregion
}