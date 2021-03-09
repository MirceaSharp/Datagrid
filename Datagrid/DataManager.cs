using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Complexe_Contol_Datagrid
{
    class DataManager
    {

        public static ObservableCollection<Product> GetProducts()
        {
            ObservableCollection<Product> lijst = new ObservableCollection<Product>();
            Product p = null;
            String[] geg = null;
            using (StreamReader reader = new StreamReader("Products.txt"))
            {
                while (!reader.EndOfStream)
                {
                    geg = reader.ReadLine().Split(';');

                    p = new Product(geg[1], geg[2], decimal.Parse(geg[3]));
                    lijst.Add(p);
                }
            }

            return lijst;

        }


        public static ObservableCollection<LineItem> GetLineItems()
        {
            ObservableCollection<LineItem> lijst = new ObservableCollection<LineItem>();
            lijst.Add(new LineItem(1, new Book("JSE14", "Patrick Niemeyer", 49.50m, "Niemeyer"), 2));
            lijst.Add(new LineItem(2, new Book("b1", "book1", 10m, "Hans Van Soom"), 1));
            lijst.Add(new LineItem(3, new Software("S1", "software1", 20m, "1.0"), 2));
            lijst.Add(new LineItem(4, new Product("P1", "Product1", 15m), 1));

            return lijst;

        }



        public static ObservableCollection<Order> GetOrders()
        {
            ObservableCollection<Order> lijst = new ObservableCollection<Order>();

            Order o = new Order()
            {
                Ordernumber = "1",
                Orderdatum = DateTime.Now
            };


            o.AddLineItem(new LineItem(1, new Product("JSE14", "Patrick Niemeyer", 49.50m), 2));
            o.AddLineItem(new LineItem(2, new Product("b1", "book1", 10m), 1));
            lijst.Add(o);


            o = new Order()
            {
                Ordernumber = "2",
                Orderdatum = DateTime.Now.AddDays(-1)
            };


            o.AddLineItem(new LineItem(1, new Product("S1", "software1", 20m), 2));
            o.AddLineItem(new LineItem(2, new Product("b1", "book1", 10m), 1));
            lijst.Add(o);

            return lijst;

        }
        public static void AddProduct(Product p)
        {
            using (StreamWriter writer = new StreamWriter("Products.txt", true))
            {

                if (p is Book)
                {
                    Book b = (Book)p;
                    writer.WriteLine(b.GetType().Name.ToString() + ";" + b.Code + ";" + b.Description + ";" + b.Price + ";" + b.Author);
                }
                else if (p is Software)
                {
                    Software s = (Software)p;
                    writer.WriteLine(s.GetType().Name.ToString() + ";" + s.Code + ";" + s.Description + ";" + s.Price + ";" + s.Version);
                }
                else if (p is Product)
                {
                    writer.WriteLine(p.GetType().Name.ToString() + ";" + p.Code + ";" + p.Description + ";" + p.Price + ";");
                }
            }


        }

        public static void SaveOrder(Order o)
        {
            using (StreamWriter writer = new StreamWriter(o.Ordernumber + ".txt"))
            {
                writer.WriteLine("Order: " + o.Ordernumber);
                foreach (LineItem li in o.LineItems)
                {
                    writer.WriteLine(li.ToString());
                }
                writer.WriteLine("Totaal: " + o.FormattedTotal);
                writer.Close();

            }
        }


        public static void UpdateProduct(Product p)
        {
            MessageBox.Show("hier komt een update naar een database toe");
        }
    }
}
