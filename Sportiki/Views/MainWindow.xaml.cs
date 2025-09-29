using Microsoft.EntityFrameworkCore;
using Sportiki;
using Sportiki.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Sportiki.Converters;
using Sportiki.Views;
namespace SportsApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Sportiki1135Context _context;
        private List<Athlete> _athletes;
        private List<Training> _trainings;
        private List<Participation> _participations;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Athlete> Athletes
        {
            get => _athletes;
            set { _athletes = value;
                OnPropertyChanged(); }
        }

        public List<Training> Trainings
        {
            get => _trainings;
            set { _trainings = value;
                OnPropertyChanged(); }
        }

        public List<Participation> Participations
        {
            get => _participations;
            set { _participations = value;
                OnPropertyChanged(); }
        }

        public MainWindow() 
        {
            InitializeComponent();
            _context = new Sportiki1135Context();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            Athletes = _context.Athletes
                .Include(a => a.Category)
                .Include(a => a.Level)
                .ToList();
            OnPropertyChanged();

            Trainings = _context.Trainings.ToList();

            Participations = _context.Participations
                .Include(p => p.Athlete)
                .Include(p => p.Training)
                .ToList();
            OnPropertyChanged();
        }

        private void AddAthlete_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddAthleteWindow(_context);
            if (window.ShowDialog() == true)
            {
                _context.Athletes.Add(window.CurrentAthlete);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void AddTraining_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddTrainingWindow(_context);
            if (window.ShowDialog() == true)
            {
                _context.Trainings.Add(window.NewTraining);
                _context.SaveChanges();

                LoadData();
            }
        }

        private void AddParticipation_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddParticipationWindow(_context);
            if (window.ShowDialog() == true)
            {
                _context.Participations.Add(window.NewParticipation);
                _context.SaveChanges();
                LoadData();
                MessageBox.Show("Спортсмен записан на тренировку");
            }
        }

        private void DeleteTraining_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingsGrid.SelectedItem is Training selectedTraining)
            {
                var result = MessageBox.Show("Удалить тренировку и все записи участия?",
                    "Подтверждение", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var participations = _context.Participations
                        .Where(p => p.TrainingId == selectedTraining.Id);
                    _context.Participations.RemoveRange(participations);

                    _context.Trainings.Remove(selectedTraining);
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _context?.Dispose();
            base.OnClosing(e);
        }

        private void DeleteSport_Click(object sender, RoutedEventArgs e)
        {
            if (AthletesGrid.SelectedItem is Athlete selectedAthlete)
            {
                var result = MessageBox.Show("Удалить спортсмена?",
                    "Подтверждение", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var participations = _context.Participations
                        .Where(p => p.AthleteId == selectedAthlete.Id);
                    _context.Participations.RemoveRange(participations);

                    _context.Athletes.Remove(selectedAthlete);
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}