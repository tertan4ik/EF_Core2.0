using System.Collections.ObjectModel;
using System.Linq;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class RolesService
    {
        private readonly Data.AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<Role> Roles { get; set; } = new();

        public RolesService()
        {
            GetAll();
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var roles = _db.Roles.ToList();
            Roles.Clear();
            foreach (var role in roles)
                Roles.Add(role);
        }

        // Загрузка пользователей выбранной роли
        public void LoadUsers(Role role)
        {
            var users = _db.Users
                .Where(u => u.Role_Id == role.Id)
                .ToList();

            role.Users = new ObservableCollection<User>(users);
        }
    }
}
