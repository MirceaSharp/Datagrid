using System.ComponentModel;

namespace Complexe_Contol_Datagrid
{
    class LineItem : INotifyPropertyChanged
    {
        private int _quantity;
        private Product _product;

        public int LineItemID { get; set; }


        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged("FormattedSubTotal");
            }
        }
        public int Quantity
        {

            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("FormattedSubTotal");
            }
        }

        public LineItem() : this(0, null, 0) { }

        public LineItem(int lineItemid, Product product, int quantity)
        {
            this.LineItemID = lineItemid;
            this.Product = product;
            this.Quantity = quantity;
        }


        public decimal SubTotal()
        {
            if (Product != null)
            {
                return Product.Price * Quantity;
            }
            else
            {
                return 0;
            }
        }

        public string FormattedSubTotal
        {
            get { return SubTotal().ToString("c"); }
        }


        public override string ToString()
        {
            if (Product != null)
            {
                return this.Quantity.ToString().PadLeft(3) + string.Empty.PadLeft(5)
                    + this.Product.Description.PadRight(20) + FormattedSubTotal.PadLeft(10);
            }
            else
            {
                return "geen product gekend!";
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
