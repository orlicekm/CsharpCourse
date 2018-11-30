namespace Example
{
    public abstract class UnknownCat: Animal
    {
        public string Name { get; set; } = "Default Name";

        protected UnknownCat(string name)
        {
            Name = name;
        }
    }
}