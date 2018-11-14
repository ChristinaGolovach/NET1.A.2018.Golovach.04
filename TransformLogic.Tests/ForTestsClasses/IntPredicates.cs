namespace TransformLogic.Tests.ForTestsClasses
{
    public class IntEvenPredicate : IPredicate<int>
    {
        public bool IsMatch(int source)
        {
            return IntPredicates.IsEven(source);
        }
    }

    public class IntHasThreePredicate : IPredicate<int>
    {
        public bool IsMatch(int source)
        {
            return IntPredicates.IsHasThreeDigit(source);
        }
    }

    public static class IntPredicates
    {
        public static bool IsHasThreeDigit(int number)
        {
            string numberInStringView = number.ToString();
            int index = numberInStringView.IndexOf("3");
            return index != -1 ? true : false;
        }

        public static bool IsEven(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 2 == 0 ? true : false;
        }
    }
}
