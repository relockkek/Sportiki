using Sportiki.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sportiki.DB;
namespace Sportiki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadData();
        }

        private void Update_click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveChanges();
            MessageBox.Show("Сохранено");
        }
    }
}