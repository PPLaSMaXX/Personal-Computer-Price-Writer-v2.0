using System;
using System.Windows.Forms.VisualStyles;

namespace PCPW2
{
    class ParsedProduct
    {
        public ParsedProduct(string name, string price, string ID)
        {
            this.ID = Int32.Parse(ID);
            this.Name = name;
            this.Price = Int32.Parse(price);
        }
        public int ID { get; }
        public string Name { get; }
        public int Price { get; }
    }
}
