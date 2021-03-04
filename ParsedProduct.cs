namespace PCPW2
{
    class ParsedProduct
    {
        public ParsedProduct(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string name { get; }
        public int price { get; }
    }
}
