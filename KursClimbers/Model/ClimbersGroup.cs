using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KursClimbers.Model
{
    public class ClimbersGroup : INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClimberId { get; set; }

        [Required]
        public int GroupId { get; set; }

        private DateTime dateStart;
        public DateTime DateStart
        {
            get { return dateStart; }
            set
            {
                dateStart = value;
                OnPropertyChanged();
            }
        }

        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
