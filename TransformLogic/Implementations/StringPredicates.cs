namespace TransformLogic.Implementations
{
    public class StringStartWithAPredicate : IPredicate<string>
    {
        public bool IsMatch(string source)
        {
            return StringPredicates.IsStartWithA(source);
        }
    }

    public class StringLenghtMoreThreePredicate : IPredicate<string>
    {
        public bool IsMatch(string source)
        {
            return StringPredicates.IsLengthMoreThree(source);
        }
    }


    public static class StringPredicates
    {
        public static bool IsStartWithA(string source)
        {
            return source.StartsWith("A");
        }

        public static bool IsLengthMoreThree(string source)
        {
            return source.Length > 3;
        }
    }
}
