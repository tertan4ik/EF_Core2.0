using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class RolesPage : Page
    {
        public RolesService service { get; set; } = new RolesService();

        public RolesPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RolesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = RolesList.SelectedItem as Role;
            if (selectedRole == null)
            {
                UsersList.ItemsSource = null;
                return;
            }

            // подгружаем пользователей из БД
            service.LoadUsers(selectedRole);

            // и явно привязываем к списку справа
            UsersList.ItemsSource = selectedRole.Users;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
