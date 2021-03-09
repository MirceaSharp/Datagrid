namespace Complexe_Contol_Datagrid
{
    class Software : Product
    {
        //auto-implemented property
        public string Version { get; set; }

        /*public override string GetDisplayText(string sep)
       {
           return  Code + sep + GetFormattedPrice() + sep + Description + 
               "("+ Version + ")"+ Environment.NewLine; 
       }*/

        public override string ToString()
        {
            return base.ToString() + " Version: " + this.Version;
        }

        public Software(string code, string description, decimal price, string version) :
            base(code, description, price)
        {
            this.Version = version;
        }


    }
}
