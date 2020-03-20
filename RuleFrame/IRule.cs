namespace Rule
{
    public interface IRule<T>
    {
        bool Pass(T input);
    }
}
