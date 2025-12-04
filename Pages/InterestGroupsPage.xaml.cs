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
    public partial class InterestGroupsPage : Page
    {
        public InterestGroupsService GroupsService { get; } = new InterestGroupsService();

        public InterestGroup? SelectedGroup { get; set; }

        public InterestGroupsPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new InterestGroupFormPage(GroupsService, null));
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Выберите группу для редактирования");
                return;
            }

            NavigationService?.Navigate(new InterestGroupFormPage(GroupsService, SelectedGroup));
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Выберите группу для удаления");
                return;
            }

            if (MessageBox.Show("Удалить выбранную группу?",
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            GroupsService.Remove(SelectedGroup);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        // Двойной клик по группе -> страница участников
        private void GroupsList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SelectedGroup == null)
                return;

            NavigationService?.Navigate(new InterestGroupMembersPage(SelectedGroup));
        }
    }
}

