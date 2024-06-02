using KursClimbers.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace KursClimbers.ViewModel
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged();
            }
        }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddGroupCommand { get; set; }
        public ICommand UpdateGroupCommand { get; set; }
        public ICommand DeleteGroupCommand { get; set; }

        private ModelContext db;

        public GroupViewModel()
        {
            db = new ModelContext();
            Groups = new ObservableCollection<Group>(db.Groups.ToList());

            AddGroupCommand = new RelayCommand(AddGroup);
            UpdateGroupCommand = new RelayCommand(UpdateGroup, CanUpdateOrDelete);
            DeleteGroupCommand = new RelayCommand(DeleteGroup, CanUpdateOrDelete);
        }

        private void AddGroup(object obj)
        {
            Group newGroup = new Group();
            Groups.Add(newGroup);
            db.Groups.Add(newGroup);
            db.SaveChanges();
        }

        private void UpdateGroup(object obj)
        {
            db.SaveChanges();
        }

        private void DeleteGroup(object obj)
        {
            db.Groups.Remove(SelectedGroup);
            Groups.Remove(SelectedGroup);
            db.SaveChanges();
        }

        private bool CanUpdateOrDelete(object obj)
        {
            return SelectedGroup != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
