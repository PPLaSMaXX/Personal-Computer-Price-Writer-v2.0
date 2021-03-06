namespace PCPW2
{
    class ParsedProduct
    {
        public ParsedProduct(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; }
        public int Price { get; }
    }
}
