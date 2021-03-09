using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Complexe_Contol_Datagrid
{
    /// <summary>
    /// Interaction logic for FrmProducten.xaml
    /// </summary>
    public partial class FrmProducten : Window
    {
        public FrmProducten()
        {
            InitializeComponent();
        }

        public ObservableCollection<Product> LijstProducten { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LijstProducten = DataManager.GetProducts();
            dgProducten.ItemsSource = LijstProducten;

            LijstProducten.CollectionChanged += LijstProducten_CollectionChanged;
        }


        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product p = LijstProducten[2];
                p.Description = "Is dit zichtbaar?"; //zonder de INotifyPropertyChanged is dit niet zichtbaar!

                Product newP = new Product(txtCode.Text, txtDescription.Text, decimal.Parse(txtPrice.Text));
                LijstProducten.Add(newP);
                MessageBox.Show("Insert van het Product: " + newP.ToString());
                Product newPManueel = new Product("code", "beschrijving", 100);
                LijstProducten.Add(newPManueel);
                MessageBox.Show("Insert van het Product: " + newPManueel.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK);
            }

        }


        private void LijstProducten_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Product i in e.OldItems)
                {
                    MessageBox.Show("Delete van het Product: " + i.ToString());
                }

            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Product i in e.NewItems)
                {
                    MessageBox.Show("manuele insert van het Product: " + i.ToString());
                }

            }
        }


        private void dgProducten_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Product p = (Product)e.Row.DataContext;
                if (e.Row.IsNewItem)
                {
                    MessageBox.Show("Insert van het Product: " + p.ToString());
                    //DataManager.AddProduct(p);
                }
                else
                {
                    MessageBox.Show("Update van het Product: " + p.ToString());
                    //DataManager.UpdateProduct(p);
                }
            }
        }


    }
}
