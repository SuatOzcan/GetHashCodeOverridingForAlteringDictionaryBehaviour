// See https://aka.ms/new-console-template for more information

Dictionary <Give,int> ace = new Dictionary <Give,int> ();

Give give = new(1.2m ,3);
ace.Add(give, 1);

try
{
    Give give2 = new(1.2m, 3);
    ace[give2] = 5;
    Console.WriteLine("The try block worked.");
}
catch
{
    ace[give] = 4;
}

Console.WriteLine(ace[give]);
// Since we are overriding GetHashCode(), it returns the same hash code for
// ace[new Give(1.2m, 3)] = 5 and ace[give], so it can locate the key and returns the value.
// If we comment out GetHashCode(), then give and give2 will have different hash codes,
// therefore the dictionary will treat them as different keys.
// Console.WriteLine(ace[give]); will print 1, untouched.
public class Give : IEquatable<Give?>
{
    public decimal? Value { get; set; }
    public int? Tarik { get; set; }
    public Give(decimal? value, int? tarik)
    {
        Value = value;
        Tarik = tarik;
    }
    public override bool Equals(object? obj)
    {
        return Equals(obj as Give);
    }

    public bool Equals(Give? other)
    {
        return other is not null &&
               Value == other.Value &&
               Tarik == other.Tarik;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Tarik);
    }

    public static bool operator ==(Give? left, Give? right)
    {
        return EqualityComparer<Give>.Default.Equals(left, right);
    }

    public static bool operator !=(Give? left, Give? right)
    {
        return !(left == right);
    }
}
