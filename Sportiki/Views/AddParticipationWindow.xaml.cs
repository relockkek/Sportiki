using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sportiki.DB;
using Sportiki.Converters;
namespace Sportiki
{
    /// <summary>
    /// Логика взаимодействия для AddParticipationWindow.xaml
    /// </summary>
    public partial class AddParticipationWindow : Window
    {
        public AddParticipationWindow(Sportiki1135Context context)
        {
            InitializeComponent();

        }

        private void AddParticipation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
