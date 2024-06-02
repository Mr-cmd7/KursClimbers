using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KursClimbers.Model
{
    public class Ascent : INotifyPropertyChanged
    {
        [Key]
        [Column("Date_A")]
        public DateTime DateA { get; set; }

        [Required]
        [Column("ID_Group")] 
        public int GroupId { get; set; }

        [Required]
        [Column("ID_Mountain")]
        public int MountainId { get; set; }

        private bool successful;
        public bool Successful
        {
            get { return successful; }
            set
            {
                successful = value;
                OnPropertyChanged();
            }
        }

        private int duration;
        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
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
