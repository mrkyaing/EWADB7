namespace oopday3
{
    public class MyanmarPeople : SayHello
    {
        public override void AboutMe()
        {
           Console.WriteLine("ကျနော်က မြန်မာလူမျိုးတစ်ယောက်ပါဗျာ။");
        }

        public override void GreetingMessage()
        {
           Console.WriteLine("ဟုတ်ကဲ့၊မင်္ဂလာပါခင်ဗျာ။");
        }

        public override void WhereAreYouNow()
        {
            Console.WriteLine("I am living in YGN.");
        }
    }
}