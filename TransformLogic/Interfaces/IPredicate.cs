namespace TransformLogic
{
    public interface IPredicate<in TSource>
    {
        bool IsMatch(TSource source);
    }
}
