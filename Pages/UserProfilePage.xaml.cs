using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class UserProfilePage : Page
    {
        private readonly User _user;

        public UserProfilePage(User user)
        {
            InitializeComponent();

            // берём общий контекст
            var db = BaseDbService.Instance.Context;

            // подгружаем пользователя заново из БД с актуальными данными
            _user = db.Users
                .Include(u => u.Role)
                .Include(u => u.Userprofile)
                .Include(u => u.UserInterestGroups)
                    .ThenInclude(uig => uig.InterestGroup)
                .First(u => u.Id == user.Id);

            DataContext = _user;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void AddToGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddUserToInterestGroupPage(_user));
        }
    }
}
