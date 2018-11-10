namespace TransformLogic
{
    public interface IPredicate<TSource>
    {
        bool IsMatch(TSource source);
    }
}
