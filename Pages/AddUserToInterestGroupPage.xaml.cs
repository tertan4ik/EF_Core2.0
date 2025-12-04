using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class AddUserToInterestGroupPage : Page
    {
        public User CurrentUser { get; }

        public InterestGroupsService GroupsService { get; } = new InterestGroupsService();
        private readonly UserInterestGroupsService _userGroupsService = new UserInterestGroupsService();

        public InterestGroup? SelectedGroup { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.Today;
        public bool IsModerator { get; set; }

        public AddUserToInterestGroupPage(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Выберите группу.");
                return;
            }

            if (JoinedAt == default)
            {
                MessageBox.Show("Укажите дату вступления.");
                return;
            }

            _userGroupsService.Add(CurrentUser, SelectedGroup, JoinedAt, IsModerator);

            MessageBox.Show("Пользователь добавлен в группу.");
            NavigationService?.GoBack();
        }
    }
}

