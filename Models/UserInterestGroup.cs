using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp_DataBinding_EF.Models
{
    public class UserInterestGroup : INotifyPropertyChanged
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged();
                }
            }
        }

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _interestGroupId;
        public int InterestGroupId
        {
            get => _interestGroupId;
            set
            {
                if (_interestGroupId != value)
                {
                    _interestGroupId = value;
                    OnPropertyChanged();
                }
            }
        }

        private InterestGroup _interestGroup;
        public InterestGroup InterestGroup
        {
            get => _interestGroup;
            set
            {
                if (_interestGroup != value)
                {
                    _interestGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _joinedAt = DateTime.Today;
        public DateTime JoinedAt
        {
            get => _joinedAt;
            set
            {
                if (_joinedAt != value)
                {
                    _joinedAt = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isModerator;
        public bool IsModerator
        {
            get => _isModerator;
            set
            {
                if (_isModerator != value)
                {
                    _isModerator = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
