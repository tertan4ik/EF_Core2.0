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
    public partial class InterestGroupFormPage : Page
    {
        private readonly InterestGroupsService _service;
        private readonly bool _isEdit;
        private readonly InterestGroup _group;

        public InterestGroupFormPage(InterestGroupsService service, InterestGroup? editGroup)
        {
            InitializeComponent();

            _service = service;

            if (editGroup == null)
            {
                _group = new InterestGroup();
                _isEdit = false;
                TitleText.Text = "Новая группа";
            }
            else
            {
                // создаём копию, чтобы не портить объект в списке, пока пользователь не сохранит
                _group = new InterestGroup
                {
                    Id = editGroup.Id,
                    Title = editGroup.Title,
                    Description = editGroup.Description
                };
                _isEdit = true;
                TitleText.Text = "Редактирование группы";
            }

            DataContext = _group;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_group.Title))
            {
                MessageBox.Show("Название группы обязательно");
                return;
            }

            try
            {
                if (_isEdit)
                    _service.Update(_group);
                else
                    _service.Add(_group);

                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
