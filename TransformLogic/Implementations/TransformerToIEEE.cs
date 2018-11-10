using DoubleExtensionLogic;

namespace TransformLogic
{
    public class TransformerToIEEE : ITransformer<double, string>
    {
        public string TransformTo(double number)
        {
            return number.DoubleToIEEE754();
        }
    }
}
