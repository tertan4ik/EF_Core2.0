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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Services;
using Microsoft.Win32;

namespace WpfApp_DataBinding_EF.Pages
{
    public partial class UserFormPage : Page
    {
        private readonly UsersService _service;
        private readonly bool _isEdit;
        private readonly User _user;

        public UserFormPage(UsersService service, User? editUser)
        {
            InitializeComponent();

       
            _service = service;
           
            if (editUser == null)
            {
                _user = new User
                {
                    CreatedAt = DateTime.Now,
                    Userprofile = new UserProfile(),
                    Role_Id = 1
                };       
              
                _isEdit = false;
            }
            else
            {
                _user = editUser;


                if (_user.Userprofile == null)
                    _user.Userprofile = new UserProfile { Id = _user.Id };
       
                _isEdit = true;
            }
          
            DataContext = _user;
        }

        private void Save(object sender, RoutedEventArgs e)
        {

    
            if (_user.Role == null)
            {
                MessageBox.Show("Выберите роль");
                return;
            }

            _user.Role_Id = _user.Role.Id;

            if (_service.IsLoginUnique(_user.Login, _user.Id))
            {
                MessageBox.Show("Такой логин уже существует");
                return;
            }

            if (_service.IsEmailUnique(_user.Email, _user.Id))
            {
                MessageBox.Show("Такой email уже существует");
                return;
            }

            if (_user.CreatedAt < DateTime.Today)
            {
                MessageBox.Show("Дата создания не может быть раньше сегодняшней");
                return;
            }


            if (_user.Name == null || _user.Email == null || _user.Password == null)
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }
            if (_isEdit)
                _service.UpdateUser(_user);
            else
                _service.AddUser(_user);


            NavigationService?.GoBack();
        }

        private void Back(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();

         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Avatarurl = _user.Userprofile.AvatarUrl;

            if (Avatarurl != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Avatarurl, UriKind.Absolute);
                bitmap.EndInit();

                Avatar.Source = bitmap;
                if (Avatar.Source == null)
                {
                    MessageBox.Show("dikbvslbvfs");
                }
            }
        }


 
    }
}
