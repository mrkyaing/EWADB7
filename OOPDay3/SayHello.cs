namespace oopday3
{
    public abstract class SayHello
    {
        public string Name { get; set; }

        public abstract void GreetingMessage();

        public abstract void AboutMe();

        public abstract void WhereAreYouNow();
        
        public void DetailOnMe(){
            Console.WriteLine($"I am {Name}");
        }

    }
}