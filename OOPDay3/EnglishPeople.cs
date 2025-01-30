namespace oopday3
{
    public class EnglishPeople : SayHello
    {
        public override void AboutMe()
        {
            Console.WriteLine("I am English Nationality.");
        }

        public override void GreetingMessage()
        {
            Console.WriteLine("Hello,Nice to see you");
        }

        public override void WhereAreYouNow()
        {
            Console.WriteLine("I am living in USA");
        }
    }
}