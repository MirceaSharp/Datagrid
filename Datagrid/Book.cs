namespace Complexe_Contol_Datagrid
{
    class Book : Product
    {
        public string Author { get; set; }

        public Book(string code, string description, decimal price, string author) :
            base(code, description, price)
        {
            this.Author = author;
        }


        /* public override string GetDisplayText(string sep)
         {
             return Code + sep + GetFormattedPrice() + sep + Description + 
                 "("+ Author + ")"+ Environment.NewLine;
         }*/

        public override string ToString()
        {
            return base.ToString() + " (" + this.Author + ")";
        }
    }
}
