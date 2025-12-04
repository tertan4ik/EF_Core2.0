
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_DataBinding_EF.Data;
using WpfApp_DataBinding_EF.Models;
using WpfApp_DataBinding_EF.Migrations;
using System.Collections.ObjectModel;
using System.Data;

namespace WpfApp_DataBinding_EF.Services
{
    public class UserInterestGroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        // Добавление связи User–InterestGroup с проверкой на дубль
        public void Add(User user, InterestGroup group, DateTime joinedAt, bool isModerator)
        {
            // если такая связь уже есть – ничего не делаем
            var exists = _db.UsersInterestGroups.Any(uig =>
                uig.UserId == user.Id &&
                uig.InterestGroupId == group.Id);

            if (exists)
                return;

            var entity = new UserInterestGroup
            {
                UserId = user.Id,
                InterestGroupId = group.Id,
                JoinedAt = joinedAt,
                IsModerator = isModerator
            };

            _db.UsersInterestGroups.Add(entity);
            _db.SaveChanges();
        }

        // Удаление связи
        public void Remove(UserInterestGroup link)
        {
            var entity = _db.UsersInterestGroups
                .FirstOrDefault(uig =>
                    uig.UserId == link.UserId &&
                    uig.InterestGroupId == link.InterestGroupId);

            if (entity != null)
            {
                _db.UsersInterestGroups.Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}

