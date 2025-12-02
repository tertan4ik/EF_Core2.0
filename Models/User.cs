using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_DataBinding_EF.Models
{
    public class User : INotifyPropertyChanged
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

        private int _pid;
        public int Pid
        {
            get => _pid;
            set
            {
                if (_pid != value)
                {
                    _pid = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _role_id;
        public int Role_Id
        {
            get => _role_id;
            set
            {
                if (_role_id != value)
                {
                    _role_id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _login = "";
        public string Login
        {
            get => _login;
            set
            {
                if (_login != value)
                {
                    _login = value;
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

        private string _email = "";
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                if (_createdAt != value)
                {
                    _createdAt = value;
                    OnPropertyChanged();
                }
            }
        }
        private UserProfile _userprofile;
        public UserProfile Userprofile
        {
            get => _userprofile;
            set
            {
                _userprofile = value;
            }
        }
        private Role _role;
        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
