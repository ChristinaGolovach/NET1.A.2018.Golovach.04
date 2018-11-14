using DoubleExtensionLogic;

namespace TransformLogic.Tests.ForTestsClasses
{
    public class TransformerToIEEE : ITransformer<double, string>
    {
        public string Transform(double number)
        {
            return number.DoubleToIEEE754();
        }
    }
}
