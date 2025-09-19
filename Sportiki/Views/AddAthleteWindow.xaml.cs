using Microsoft.EntityFrameworkCore;
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
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace Sportiki.Views
{
    public partial class AddAthleteWindow : Window, INotifyPropertyChanged
    {
        private Sportiki1135Context _context;
        private Athlete _currentAthlete = new Athlete();


        public System.Collections.IEnumerable Categories { get; set; }
        public System.Collections.IEnumerable Levels { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public Athlete CurrentAthlete
        {
            get =>
                _currentAthlete;
            set
            {
                _currentAthlete = value;
                OnPropertyChanged();
            }
        }
        public AddAthleteWindow(Sportiki1135Context context)
        {
            InitializeComponent();
            _context = context;
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            Categories = _context.Categories.ToList();
            Levels = _context.Levels.ToList();
            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(Levels));
        }


        private void AddAthlete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentAthlete.FirstName) ||
                string.IsNullOrWhiteSpace(CurrentAthlete.LastName) ||
                CurrentAthlete.Birthday == null ||
                CurrentAthlete.Category == null ||
                CurrentAthlete.Level == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            DialogResult = true;
            Close();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}