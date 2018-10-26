namespace TransformLogic
{
    /// <summary>
    /// Contract to transform double number to string
    /// </summary>
    public interface ITransformer
    {
        string TransformTo(double number);
    }
}
