using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using WpfApp_DataBinding_EF.Data;
using WpfApp_DataBinding_EF.Models;

namespace WpfApp_DataBinding_EF.Services
{
    public class UserInterestGroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public void Add(UserInterestGroup link)
        {
            var entity = new UserInterestGroup
            {
                UserId = link.UserId,
                InterestGroupId = link.InterestGroupId,
                JoinedAt = link.JoinedAt,
                IsModerator = link.IsModerator
            };

            _db.UsersInterestGroups.Add(entity);
            _db.SaveChanges();
        }

        public void Add(User user, InterestGroup group, DateTime joinedAt, bool isModerator)
        {
            var link = new UserInterestGroup
            {
                UserId = user.Id,
                InterestGroupId = group.Id,
                JoinedAt = joinedAt,
                IsModerator = isModerator
            };

            Add(link);
        }
    }
}

