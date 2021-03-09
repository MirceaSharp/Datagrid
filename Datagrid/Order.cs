using System;
using System.Collections.ObjectModel;

namespace Complexe_Contol_Datagrid
{
    class Order
    {
        //auto-implemented property
        public string Ordernumber { get; set; }
        public DateTime Orderdatum { get; set; }
        private ObservableCollection<LineItem> _lineItems;


        public Order()
        {
            this.LineItems = new ObservableCollection<LineItem>();
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (LineItem li in LineItems)
            {
                total += li.SubTotal();
            }
            return total;
        }

        public void AddLineItem(LineItem li)
        {
            if (LineItems == null)
            {
                LineItems = new ObservableCollection<LineItem>();
            }
            LineItems.Add(li);
        }

        public void RemoveLineItem(LineItem li)
        {
            if (LineItems != null)
            {
                LineItems.Remove(li);
            }
        }



        public ObservableCollection<LineItem> LineItems
        {
            get { return _lineItems; }
            private set
            {
                _lineItems = value;
            }
        }

        public string FormattedOrderDate
        {
            get { return Orderdatum.ToShortDateString(); }
        }

        public string FormattedTotal
        {
            get { return Total().ToString("c"); }
        }

        public string DetailsLineItems
        {
            get
            {
                string tekst = "";
                foreach (LineItem l in LineItems)
                {
                    tekst += l.ToString() + Environment.NewLine;
                }
                return tekst;

            }
        }


        public override string ToString()
        {
            string tekst = "Ordernummer: " + Ordernumber + Environment.NewLine;
            tekst += "Orderdatum: " + FormattedOrderDate + Environment.NewLine;
            tekst += "Totaal: " + FormattedTotal + Environment.NewLine;
            foreach (LineItem l in LineItems)
            {
                tekst += l.ToString() + Environment.NewLine;
            }
            return tekst;
        }
    }
}
