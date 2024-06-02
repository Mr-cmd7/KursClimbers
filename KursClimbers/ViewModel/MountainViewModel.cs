using KursClimbers.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KursClimbers.ViewModel
{
    public class MountainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Mountain> mountains;
        public ObservableCollection<Mountain> Mountains
        {
            get { return mountains; }
            set
            {
                mountains = value;
                OnPropertyChanged();
            }
        }

        private Mountain selectedMountain;
        public Mountain SelectedMountain
        {
            get { return selectedMountain; }
            set
            {
                selectedMountain = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddMountainCommand { get; set; }
        public ICommand UpdateMountainCommand { get; set; }
        public ICommand DeleteMountainCommand { get; set; }

        private ModelContext db;

        public MountainViewModel()
        {
            db = new ModelContext();
            Mountains = new ObservableCollection<Mountain>(db.Mountains.Where(m => m != null).ToList());

            AddMountainCommand = new RelayCommand(AddMountain);
            UpdateMountainCommand = new RelayCommand(UpdateMountain, CanUpdateOrDelete);
            DeleteMountainCommand = new RelayCommand(DeleteMountain, CanUpdateOrDelete);
        }


        private void AddMountain(object obj)
        {
            try
            {
                Mountain newMountain = new Mountain();
                Mountains.Add(newMountain);
                db.Mountains.Add(newMountain);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Произошла ошибка при сохранении изменений, обработаем её
                // Выведем сообщение об ошибке
                MessageBox.Show($"Ошибка при сохранении изменений в базе данных: {ex.Message}");

                // Выведем более подробную информацию об исключении во внутреннем исключении (Inner Exception)
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Подробности: {ex.InnerException.Message}");
                }
            }
        }

        private void UpdateMountain(object obj)
        {
            db.SaveChanges();
        }

        private void DeleteMountain(object obj)
        {
            db.Mountains.Remove(SelectedMountain);
            Mountains.Remove(SelectedMountain);
            db.SaveChanges();
        }

        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedMountain != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}