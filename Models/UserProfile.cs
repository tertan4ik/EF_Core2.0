using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_DataBinding_EF.Models
{
    public class UserProfile:INotifyPropertyChanged
    {
         
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _AvatarUrl = "";
        public string AvatarUrl
        {
            get => _AvatarUrl;
            set
            {
                if (_AvatarUrl != value)
                {
                    _AvatarUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phone = "";
        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }


        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _bio = "";
        public string Bio
        {
            get => _bio;
            set
            {
                if (_bio != value)
                {
                    _bio = value;
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
                 _user=value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

