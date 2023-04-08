using System.Reflection;

namespace PropertyRenting.Domain.Primitives;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
{
    #region Fields :
    private static readonly Dictionary<int, TEnum> _enumerations = CreateEnumerations();
    #endregion

    #region CTORS :
    protected Enumeration(int value, string name, string description = "")
    {
        Value = value;
        Name = name;
        Description = description;
    }
    #endregion

    #region PROPS :
    public int Value { get; protected init; }
    public string Name { get; protected init; } = string.Empty;
    public string Description { get; protected init; } = string.Empty;

    public IReadOnlyCollection<TEnum> Records => _enumerations.Values.ToList().AsReadOnly();
    #endregion

    #region Methods :
    public static TEnum FromValue(int value)
    {
        return _enumerations.TryGetValue(value, out TEnum enumeration) ? enumeration : default;
    }
    public static TEnum FromName(string name)
    {
        return _enumerations.Values.SingleOrDefault(e => e.Name == name);
    }
    public bool Equals(Enumeration<TEnum> other)
    {
        if (other is null)
            return false;
        return GetType() == other.GetType() && Value == other.Value;
    }
    public override bool Equals(object obj)
    {
        return obj is Enumeration<TEnum> other && Equals(other);
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    public override string ToString()
    {
        return Name;
    }
    #endregion

    #region Helpers :
    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);
        var fieldsForType = enumerationType.GetFields(BindingFlags.Public
            | BindingFlags.Static
            | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

        return fieldsForType.ToDictionary(x => x.Value);
    }
    #endregion
}
