namespace oopday2
{
    public class Dog:Animal
    {
        public void Bark()=>Console.Write("Woak");

        public override void Eat()
        {
            Console.WriteLine("eat meal");
        }
    }
}