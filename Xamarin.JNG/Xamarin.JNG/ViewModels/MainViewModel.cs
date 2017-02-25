
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin.JNG.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _name;
        private string _firstSurname;
        private string _lastSurname;
        private string _city;
        private string _jediName;

        public ICommand ClickCommand
        {
            get
            {
                return new Command(GenerateJediName);
            }
        }

        void GenerateJediName()
        {
            string result = "Qui Gon Jinn";
            string jediName = "";
            string jediSurname = "";
            if (string.IsNullOrEmpty(_name) ||
                string.IsNullOrEmpty(_firstSurname) ||
                string.IsNullOrEmpty(_lastSurname) ||
                string.IsNullOrEmpty(_city))
            {
                result = string.Empty;
            }
            else
            {
                jediName = _firstSurname.Substring(0, 3).ToLower() + _name.Substring(0, 2).ToLower();
                jediSurname = _lastSurname.Substring(0, 2).ToLower() + _city.Substring(0, 3).ToLower();

                jediName = jediName.Substring(0, 1).ToUpper() + jediName.Substring(1);

                jediSurname = jediSurname.Substring(0, 1).ToUpper() + jediSurname.Substring(1);

                result = jediName + " " + jediSurname;
            }

            JediName = result;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
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
                    OnPropertyChanged("FirstSurname");
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
                    OnPropertyChanged("LastSurname");
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
                    OnPropertyChanged("City");
                }
            }
        }

        public string JediName
        {
            get
            {
                return _jediName;
            }
            set
            {
                _jediName = value;
                OnPropertyChanged("JediName");
            }
        }
    }
}
