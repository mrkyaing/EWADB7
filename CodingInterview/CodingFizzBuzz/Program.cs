using System.Text;
class Program
{
    static void Main()
    {
        int limit = 15;
        StringBuilder sb = new StringBuilder(capacity: limit * 5);

        for (int i = 1; i <= limit; i++)
        {
            bool divisibleBy3 = (i % 3 == 0);
            bool divisibleBy5 = (i % 5 == 0);

            if (divisibleBy3 && divisibleBy5)
            {
                sb.AppendLine("FizzBuzz");
            }
            else if (divisibleBy3)
            {
                sb.AppendLine("Fizz");
            }
            else if (divisibleBy5)
            {
                sb.AppendLine("Buzz");
            }
            else
            {
                sb.AppendLine(i.ToString());
            }
            if (i % 10000 == 0)
            {
                Console.Write(sb.ToString());
                sb.Clear();
            }
        }
        if (sb.Length > 0)
        {
            Console.Write(sb.ToString());
        }
    }
}
