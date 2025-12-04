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
    public partial class InterestGroupMembersPage : Page
    {
        private readonly InterestGroup _group;
        private readonly InterestGroupsService _service = new InterestGroupsService();

        public InterestGroupMembersPage(InterestGroup group)
        {
            InitializeComponent();

            _group = group;

            // Подгружаем участников из БД (UserGroups + User)
            _service.LoadUsers(_group);

            DataContext = _group;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}

