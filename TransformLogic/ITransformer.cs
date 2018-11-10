namespace TransformLogic
{
    /// <summary>
    /// Contract for transform TInput value to TOutput value
    /// </summary>
    public interface ITransformer<in TInput, out TOutput>
    {
        TOutput TransformTo(TInput number);
    }
}
