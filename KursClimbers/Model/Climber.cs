using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace KursClimbers.Model
{
    public class Climber : INotifyPropertyChanged
    {
        [Key]
        [Column("ID_Climber")]
        public int IdClimber { get; set; }

        private string fio;
        [Required]
        [StringLength(100)]
        public string Fio
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged();
            }
        }

        private string address;
        [Required]
        [StringLength(200)]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        private string phone;
        [Required]
        [StringLength(15)]
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        private string rank;
        [StringLength(50)]
        public string Rank
        {
            get { return rank; }
            set
            {
                rank = value;
                OnPropertyChanged();
            }
        }

        private string sex;
        [StringLength(10)]
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
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
