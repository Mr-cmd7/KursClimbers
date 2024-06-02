using KursClimbers.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KursClimbers.ViewModel
{
    public class ClimberViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Climber> climbers;
        public ObservableCollection<Climber> Climbers
        {
            get { return climbers; }
            set
            {
                climbers = value;
                OnPropertyChanged();
            }
        }

        private Climber selectedClimber;
        public Climber SelectedClimber
        {
            get { return selectedClimber; }
            set
            {
                selectedClimber = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddClimberCommand { get; set; }
        public ICommand UpdateClimberCommand { get; set; }
        public ICommand DeleteClimberCommand { get; set; }

        private ModelContext db;

        public ClimberViewModel()
        {
            db = new ModelContext();
            Climbers = new ObservableCollection<Climber>(db.Climbers.ToList());

            AddClimberCommand = new RelayCommand(AddClimber);
            UpdateClimberCommand = new RelayCommand(UpdateClimber, CanUpdateOrDelete);
            DeleteClimberCommand = new RelayCommand(DeleteClimber, CanUpdateOrDelete);
        }

        private void AddClimber(object obj)
        {
            Climber newClimber = new Climber();
            Climbers.Add(newClimber);
            db.Climbers.Add(newClimber);
            db.SaveChanges();
        }

        private void UpdateClimber(object obj)
        {
            db.SaveChanges();
        }

        private void DeleteClimber(object obj)
        {
            db.Climbers.Remove(SelectedClimber);
            Climbers.Remove(SelectedClimber);
            db.SaveChanges();
        }

        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedClimber != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}