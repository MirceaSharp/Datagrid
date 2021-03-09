using System.ComponentModel;
using System.Text;

namespace Complexe_Contol_Datagrid
{
    //De INotifyPropertyChanged is toegevoegd om bij elke wijziging van 
    //    de eigenschappen een event te gooien naar het formulier. Op 
    //    deze manier blijft ten alle tijden het formulier up-to-date.

    public class Product//: INotifyPropertyChanged
    {
        private string _code;
        private string _description;
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
        }


        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChanged("Code");
            }
        }


        public Product() : this("", "", 0) { }

        public Product(string code, string description, decimal price)
        {
            this.Code = code;
            this.Description = description;
            this.Price = price;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.Append(this.Code.PadRight(8) + this.GetFormattedPrice().PadLeft(10)
                + string.Empty.PadLeft(5) + this.Description);
            return message.ToString();
        }


        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Product))
            {
                return false;
            }

            Product p = (Product)obj;
            return this.Code.Equals(p.Code);

        }

        public string GetFormattedPrice()
        {
            return Price.ToString("c");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


    }
}
