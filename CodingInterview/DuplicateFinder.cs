namespace CodingInterview
{
    public static class DuplicateFinder
    {
        public static void Finder()
        {
            int[] numbers = { 1, 2, 4, 5, 1, 6, 5 };
            var duplicates = numbers.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            Console.WriteLine("Duplicate numbers: " + string.Join(", ", duplicates));
        }
    }
}