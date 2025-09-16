using Sportiki.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sportiki.DB;

namespace Sportiki.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly SportsContext _context;
        private ObservableCollection<Athlete> _athletes;
        private ObservableCollection<Training> _trainings;

        public ObservableCollection<Athlete> Athletes
        {
            get => _athletes;
            set
            {
                _athletes = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Training> Trainings
        {
            get => _trainings;
            set
            {
                _trainings = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            _context = new SportsContext();
            LoadData();
        }

        public void LoadData()
        {
            _context.Athletes.Load();
            _context.Trainings.Load();

            Athletes = _context.Athletes.Local.ToObservableCollection();
            Trainings = _context.Trainings.Local.ToObservableCollection();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

