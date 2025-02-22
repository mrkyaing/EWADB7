using CodingInterview;

int[] numbers = { 1, 2, 4, 5, 1, 6, 5 };
HashSet<int> seen = new HashSet<int>();
HashSet<int> duplicates = new HashSet<int>();

foreach (var num in numbers)
{
    if (!seen.Add(num))
    {
        duplicates.Add(num);
    }
}

Console.WriteLine("Duplicate numbers: " + string.Join(", ", duplicates));
Console.WriteLine("linq examples");
DuplicateFinder.Finder();