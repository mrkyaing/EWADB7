namespace oopday3
{
    public class JapanesePeople : SayHello
    {
        public override void AboutMe()
        {
            Console.WriteLine("私は日本国籍です。");
        }
        public override void GreetingMessage()
        {
            Console.WriteLine("こんにちは、お会いできて嬉しいです");
        }

        public override void WhereAreYouNow()
        {
            Console.WriteLine("I am living in TOKAYO.");
        }
    }
}