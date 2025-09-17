using Microsoft.EntityFrameworkCore;
using Sportiki.DB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Sportiki.DB;
namespace SportsApp
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Sportiki1135Context db;
        private Athlete insertAthlete = new Athlete();
        private List<Athlete> athletes;

        public event PropertyChangedEventHandler PropertyChanged;

        void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public List<Athlete> Athletes
        {
            get => athletes;
            set
            {
                athletes = value;
                Signal();
            }
        }

        public Athlete InsertAthlete
        {
            get => insertAthlete;
            set
            {
                insertAthlete = value;
                Signal();
            }
        }

        public List<Category> Categories { get; set; }
        public List<Level> Levels { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            db = new Sportiki1135Context();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            // Загружаем справочники
            Categories = db.Categories.ToList();
            Levels = db.Levels.ToList();

            // Загружаем спортсменов с связанными данными
            Athletes = db.Athletes
                .Include(a => a.Category)
                .Include(a => a.Level)
                .ToList();

            // Инициализируем нового спортсмена
            InsertAthlete = new Athlete();
        }

        private void InsertAthleteMethod(object sender, RoutedEventArgs e)
        {
            // Проверка заполнения полей
            if (string.IsNullOrWhiteSpace(InsertAthlete.FirstName) ||
                string.IsNullOrWhiteSpace(InsertAthlete.LastName) ||
                InsertAthlete.Birthday == null ||
                InsertAthlete.Category == null ||
                InsertAthlete.Level == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            // Устанавливаем ID для связанных сущностей
            InsertAthlete.CategoryId = InsertAthlete.Category.Id;
            InsertAthlete.LevelId = InsertAthlete.Level.Id;

            // Добавляем в базу
            db.Athletes.Add(InsertAthlete);
            db.SaveChanges();

            MessageBox.Show("Спортсмен добавлен!");

            // Обновляем данные
            LoadData();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            db?.Dispose();
            base.OnClosing(e);
        }
    }
}