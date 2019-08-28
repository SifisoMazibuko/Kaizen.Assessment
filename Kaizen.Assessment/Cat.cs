namespace Kaizen.Assessment
{
    public class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Food { get; set; }

        public string GetDetails()
        {
            return "Name: " + Name + "\tAge: " + Age;
        }
    }
}