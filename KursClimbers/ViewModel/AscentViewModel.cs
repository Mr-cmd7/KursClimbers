using KursClimbers.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace KursClimbers.ViewModel
{
    public class AscentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Ascent> ascents;
        public ObservableCollection<Ascent> Ascents
        {
            get { return ascents; }
            set
            {
                ascents = value;
                OnPropertyChanged();
            }
        }

        private Ascent selectedAscent;
        public Ascent SelectedAscent
        {
            get { return selectedAscent; }
            set
            {
                selectedAscent = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddAscentCommand { get; set; }
        public ICommand UpdateAscentCommand { get; set; }
        public ICommand DeleteAscentCommand { get; set; }

        private ModelContext db;

        public AscentViewModel()
        {
            db = new ModelContext();
            Ascents = new ObservableCollection<Ascent>(db.Ascents.ToList());

            AddAscentCommand = new RelayCommand(AddAscent);
            UpdateAscentCommand = new RelayCommand(UpdateAscent, CanUpdateOrDelete);
            DeleteAscentCommand = new RelayCommand(DeleteAscent, CanUpdateOrDelete);
        }

        private void AddAscent(object obj)
        {
            Ascent newAscent = new Ascent();
            Ascents.Add(newAscent);
            db.Ascents.Add(newAscent);
            db.SaveChanges();
        }

        private void UpdateAscent(object obj)
        {
            db.SaveChanges();
        }

        private void DeleteAscent(object obj)
        {
            db.Ascents.Remove(SelectedAscent);
            Ascents.Remove(SelectedAscent);
            db.SaveChanges();
        }

        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedAscent != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
