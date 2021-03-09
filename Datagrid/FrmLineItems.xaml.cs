using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Complexe_Contol_Datagrid
{
    /// <summary>
    /// Interaction logic for FrmLineItems.xaml
    /// </summary>
    public partial class FrmLineItems : Window
    {
        public FrmLineItems()
        {
            InitializeComponent();
        }

        private ObservableCollection<Product> LijstProducten { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LijstProducten = DataManager.GetProducts();
            cmbProducten.ItemsSource = LijstProducten;
            dgLineItem.ItemsSource = DataManager.GetLineItems();
        }

        private void dgLineItem_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                LineItem li = (LineItem)e.Row.DataContext;
                if (e.Row.IsNewItem)
                {
                    MessageBox.Show("Insert van het lineitem: " + li.ToString());
                }
                else
                {
                    MessageBox.Show("Update van het lineitem: " + li.ToString());
                }
            }
        }


    }
}
