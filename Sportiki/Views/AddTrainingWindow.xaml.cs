using Sportiki.Converters;
using Sportiki.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
namespace Sportiki.Views
{
    public partial class AddTrainingWindow : Window, INotifyPropertyChanged
    {
        private string _trainingTitle;
        private string _trainingDateTime;
        private string _selectedDuration;
        private string _selectedType;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Training NewTraining { get; private set; }

        public string TrainingTitle
        {
            get => _trainingTitle;
            set
            {
                _trainingTitle = value;
                OnPropertyChanged();
            }
        }
        public string TrainingDateTime
        {
            get => _trainingDateTime;
            set
            {
                _trainingDateTime = value;
                OnPropertyChanged();
            }
        }
        public string SelectedDuration
        {
            get => _selectedDuration;
            set
            {
                _selectedDuration = value;
                OnPropertyChanged();
            }
        }
        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public AddTrainingWindow(Sportiki1135Context context)
        {
            InitializeComponent();
            NewTraining = new Training();
            DataContext = this;
        }
        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TrainingTitle) ||
                string.IsNullOrWhiteSpace(TrainingDateTime) ||
                SelectedDuration == null ||
                SelectedType == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (DurationCombo.SelectedItem is ComboBoxItem durationitem) 
                NewTraining.Duration = durationitem.Content.ToString();

            if (TypeCombo.SelectedItem is ComboBoxItem typeitem)
                NewTraining.Type = typeitem.Content.ToString();

            DialogResult = true;
            Close();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
