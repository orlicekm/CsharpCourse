namespace Tests
{
    public class Cat: Animal
    {
        public string Name { get; set; }
        public int LivesLeft { get; set; } = 9;

        public Cat(string name)
        {
            Name = name;
        }
        public Cat(string name, int livesLeft) : this(name)
        {
            LivesLeft = livesLeft;
        }

        public override string Cry()
        {
            return "Meow!";
        }
    }
}