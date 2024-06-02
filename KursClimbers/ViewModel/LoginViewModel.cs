using KursClimbers.Model;
using KursClimbers.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursClimbers.ViewModel
{
    internal class LoginViewModel
    {
        private readonly ModelContext _db;
        private readonly LoginView _window;

        public LoginViewModel(LoginView window)
        {
            _window = window;
            _db = new ModelContext();
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(async obj => await LoginAsync()));
            }
        }

        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return _registerCommand ?? (_registerCommand = new RelayCommand(async obj => await RegisterAsync()));
            }
        }

        private async Task LoginAsync()
        {
            string login = _window.LoginBox.Text;
            string password = Hash(_window.PasswordBox.Password);

            User user = await Task.Run(() => _db.User.FirstOrDefault(p => p.Login == login && p.Password == password));
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private async Task RegisterAsync()
        {
            try
            {
                User user = new User
                {
                    Login = _window.LoginBox.Text,
                    Password = Hash(_window.PasswordBox.Password)
                };

                _db.User.Add(user);
                int res = await _db.SaveChangesAsync();

                if (res == 1)
                {
                    MessageBox.Show("Пользователь успешно создан");
                }
                else
                {
                    MessageBox.Show("Ошибка: Не удалось сохранить пользователя");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка при регистрации пользователя: {ex.InnerException?.Message}");
            }
        }



        private string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash))).Replace("-", "");
            }
        }
    }
}
