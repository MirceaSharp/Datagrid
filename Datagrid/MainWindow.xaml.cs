using System.Windows;

namespace Complexe_Contol_Datagrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnProducten_Click(object sender, RoutedEventArgs e)
        {
            FrmProducten frm = new FrmProducten();
            frm.Show();
        }

        private void btnLineitems_Click(object sender, RoutedEventArgs e)
        {
            FrmLineItems frm = new FrmLineItems();
            frm.Show();
        }
    }
}
