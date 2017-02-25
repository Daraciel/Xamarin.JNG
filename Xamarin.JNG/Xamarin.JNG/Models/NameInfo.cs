using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.JNG.Models
{
    class NameInfo
    {
        private string _name;
        private string _firstSurname;
        private string _lastSurname;
        private string _city;

        public string Name
        {
            get { return _name; }
            set
            {
                if(_name != value)
                {
                    _name = value;
                }
            }
        }

        public string FirstSurname
        {
            get { return _firstSurname; }
            set
            {
                if (_firstSurname != value)
                {
                    _firstSurname = value;
                }
            }
        }

        public string LastSurname
        {
            get { return _lastSurname; }
            set
            {
                if (_lastSurname != value)
                {
                    _lastSurname = value;
                }
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                }
            }
        }

        public string JediName
        {
            get
            {
                string result = "Qui Gon Jinn";
                string jediName = "";
                string jediSurname = "";
                if( _name == "" || _firstSurname == "" || _lastSurname == "" || _city == "" )
                {
                    return result;
                }

                jediName = _firstSurname.Substring(0, 3).ToLower() + _name.Substring(0, 2).ToLower();
                jediSurname = _lastSurname.Substring(0, 2).ToLower() + _city.Substring(0, 3).ToLower();

                jediName = jediName.Substring(0, 1).ToUpper() + jediName.Substring(1);

                jediSurname = jediSurname.Substring(0, 1).ToUpper() + jediSurname.Substring(1);

                result = jediName + " " + jediSurname;

                return result;
            }
        }


        public event EventHandler JediNameChanged;
    }
}
