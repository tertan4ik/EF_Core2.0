
﻿using System;
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

using WpfApp_DataBinding_EF.Services;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class MainPage : Page
    {
        public UsersService Service { get; set; } = new UsersService();

        public MainPage()
        {
            InitializeComponent();
            DataContext = Service;
        }

        private void GotoAdd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserFormPage(Service, null));

        }

        private void GotoEdit(object sender, RoutedEventArgs e)
        {
            if (Service.SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }


            NavigationService.Navigate(new UserFormPage(Service, Service.SelectedUser));
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (Service.SelectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }



            if (MessageBox.Show("Удалить пользователя?",
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Service.RemoveUser(Service.SelectedUser);
            }
        }


                private void GotoRoles(object sender, RoutedEventArgs e)
                {
                    NavigationService?.Navigate(new RolesPage());
                }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Service.SelectedUser == null)
                return;

            NavigationService?.Navigate(new UserProfilePage(Service.SelectedUser));
        }

        private void GoToInterestsGroups(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new InterestGroupsPage());
        }
    }
 }




