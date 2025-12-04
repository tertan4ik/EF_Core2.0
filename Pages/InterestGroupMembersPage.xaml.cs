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

using System.Collections.ObjectModel;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class InterestGroupMembersPage : Page
    {
        private readonly InterestGroup _group;
        private readonly InterestGroupsService _service = new InterestGroupsService();
        private readonly UserInterestGroupsService _userGroupsService = new UserInterestGroupsService();

        public ObservableCollection<UserInterestGroup> UserGroups => _group.UserGroups;
        public string Title => _group.Title;

        public UserInterestGroup? SelectedUserGroup { get; set; }

        public InterestGroupMembersPage(InterestGroup group)
        {
            InitializeComponent();

            _group = group;

            _service.LoadUsers(_group);

            DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void RemoveFromGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUserGroup == null)
            {
                MessageBox.Show("Выберите участника для удаления");
                return;
            }

            if (MessageBox.Show("Удалить пользователя из группы?",
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            _userGroupsService.Remove(SelectedUserGroup);
            UserGroups.Remove(SelectedUserGroup);
        }
    }
}

