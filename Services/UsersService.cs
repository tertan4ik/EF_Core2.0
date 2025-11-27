
﻿using System.Collections.ObjectModel;
using System.Linq;
using WpfApp_DataBinding_EF.Data;
﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class UsersService
    {
        private readonly Data.AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();
        public User? SelectedUser { get; set; }

        public UsersService()
        {

            LoadUsers();
        }

        public void LoadUsers()
        {
            Users.Clear();
            foreach (var u in _db.Users.ToList())
                Users.Add(u);
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users
                .Include(u => u.Role)
                .Include(u => u.Userprofile)
                .AsNoTracking()
                .ToList();

            Users.Clear();
            foreach (var u in users)
                Users.Add(u);
        }

  

        public void AddUser(User formUser)
        {
            // создаём ОТДЕЛЬНУЮ сущность для EF, не трогаем объект, привязанный к форме
            var entity = new User
            {
                Login = formUser.Login,
                Name = formUser.Name,
                Email = formUser.Email,
                Password = formUser.Password,
                CreatedAt = formUser.CreatedAt,

                Role_Id = formUser.Role != null ? formUser.Role.Id : formUser.Role_Id
            };

            // профиль
            if (formUser.Userprofile != null)
            {
                var p = formUser.Userprofile;

                entity.Userprofile = new UserProfile
                {
                    AvatarUrl = p.AvatarUrl,
                    Name = p.Name,
                    Phone = p.Phone,
                    Birthday = p.Birthday,
                    Bio = p.Bio
                };
            }

            _db.Users.Add(entity);
            _db.SaveChanges();

            _db.Entry(entity).Reference(u => u.Role).Load();

            Users.Add(entity);
        }



        public void UpdateUser(User formUser)
        {

            var entity = _db.Users
                .Include(u => u.Userprofile)
                .Include(u => u.Role)
                .First(u => u.Id == formUser.Id);

         
            entity.Login = formUser.Login;
            entity.Name = formUser.Name;
            entity.Email = formUser.Email;
            entity.Password = formUser.Password;
            entity.CreatedAt = formUser.CreatedAt;
            entity.Role_Id = formUser.Role != null ? formUser.Role.Id : formUser.Role_Id;

 
            entity.Userprofile = formUser.Userprofile;
    
            _db.SaveChanges();

 
            _db.Entry(entity).Reference(u => u.Role).Load();

 
            var idx = Users.IndexOf(Users.First(u => u.Id == entity.Id));
            if (idx >= 0)
                Users[idx] = entity;
        }



        public void RemoveUser(User user)
        {
            _db.Users.Remove(user);
            if (Commit() > 0 && Users.Contains(user))
                Users.Remove(user);
        }


        public bool IsLoginUnique(string login, int currentId = 0)
        {
            var lower = login.ToLower();
            return _db.Users.Any(u => u.Login.ToLower() == lower && u.Id != currentId);
        }

        public bool IsEmailUnique(string email, int currentId = 0)
        {

            var lower = email.ToLower();
            return _db.Users.Any(u => u.Email.ToLower() == lower && u.Id != currentId);

        }
    }
}
