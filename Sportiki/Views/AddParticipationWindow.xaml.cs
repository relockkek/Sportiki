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
        private Sportiki1135Context _context;
        public Participation NewParticipation { get; private set; }

        public AddParticipationWindow(Sportiki1135Context context)
        {
            InitializeComponent();
            _context = context;
            NewParticipation = new Participation();
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            AthleteCombo.ItemsSource = _context.Athletes.ToList();

            TrainingCombo.ItemsSource = _context.Trainings.ToList();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (AthleteCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите спортсмена");
                return;
            }
            if (TrainingCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите тренировку");
                return;
            }
            if (GradeCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите оценку");
                return;
            }

            NewParticipation.AthleteId = ((Athlete)AthleteCombo.SelectedItem).Id;
            NewParticipation.TrainingId = ((Training)TrainingCombo.SelectedItem).Id;
            DialogResult = true;
            Close();
        }
    }
}

