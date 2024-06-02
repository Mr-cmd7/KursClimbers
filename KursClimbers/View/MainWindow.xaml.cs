using KursClimbers.View;
using System.Windows;

namespace KursClimbers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ShowAscentView(object sender, RoutedEventArgs e)
        {
            AscentView ascentView = new AscentView();
            ascentView.Show();
        }
        private void ShowClimberView(object sender, RoutedEventArgs e)
        {
            ClimberView climberView = new ClimberView();
            climberView.Show();
        }
        private void ShowGroupView(object sender, RoutedEventArgs e)
        {
            GroupView groupView = new GroupView();
            groupView.Show();
        }
        private void ShowMountainView(object sender, RoutedEventArgs e)
        {
            MountainView mountainView = new MountainView();
            mountainView.Show();
        }
    }
}