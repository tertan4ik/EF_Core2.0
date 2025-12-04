using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp_DataBinding_EF.Data;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class InterestGroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<InterestGroup> InterestGroups { get; set; } = new();

        public InterestGroupsService()
        {
            GetAll();
        }

        public int Commit() => _db.SaveChanges();


        // Получение всех групп
        public void GetAll()
        {
            var groups = _db.InterestGroups.ToList();

            InterestGroups.Clear();
            foreach (var g in groups)
                InterestGroups.Add(g);
        }

        // Валидация уникального названия
        public bool IsTitleExists(string title, int currentId = 0)
        {
            var lower = title.ToLower();
            return _db.InterestGroups.Any(
                g => g.Title.ToLower() == lower && g.Id != currentId
            );
        }

        public void Add(InterestGroup group)
        {
            if (IsTitleExists(group.Title))
                throw new System.Exception("Группа с таким названием уже существует.");

            var entity = new InterestGroup
            {
                Title = group.Title,
                Description = group.Description
            };

            _db.InterestGroups.Add(entity);
            Commit();

            InterestGroups.Add(entity);
        }

        public void Update(InterestGroup group)
        {
            var entity = _db.InterestGroups.First(g => g.Id == group.Id);

            if (IsTitleExists(group.Title, group.Id))
                throw new System.Exception("Группа с таким названием уже существует.");

            entity.Title = group.Title;
            entity.Description = group.Description;

            Commit();

            var idx = InterestGroups
                .IndexOf(InterestGroups.First(g => g.Id == entity.Id));

            if (idx >= 0)
                InterestGroups[idx] = entity;
        }

        public void Remove(InterestGroup group)
        {
            _db.InterestGroups.Remove(group);

            if (Commit() > 0 && InterestGroups.Contains(group))
                InterestGroups.Remove(group);
        }

        // загрузка участников группы (UserInterestGroup → User)
        public void LoadUsers(InterestGroup group)
        {
            var entity = _db.InterestGroups
                .Include(g => g.UserGroups)
                    .ThenInclude(uig => uig.User)
                .First(g => g.Id == group.Id);

            group.UserGroups = new ObservableCollection<UserInterestGroup>(entity.UserGroups);
        }
    }
}
