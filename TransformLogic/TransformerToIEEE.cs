using DoubleExtensionLogic;

namespace TransformLogic
{
    public class TransformerToIEEE : ITransformer
    {
        public string TransformTo(double number)
        {
            return number.DoubleToIEEE754();
        }
    }
}
