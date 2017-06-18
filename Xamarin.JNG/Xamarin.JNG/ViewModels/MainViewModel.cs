
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.JNG.BE;
using Xamarin.JNG.Models;

namespace Xamarin.JNG.ViewModels
{
    public class MainViewModel : BindableObject
    {
        //private string _name;
        //private string _firstSurname;
        //private string _lastSurname;
        //private string _city;
        //private string _jediName;

        #region FIELDS

        private JediGen _jediNameGen;

        private List<string> _select;

        private ObservableCollection<NameTypeListItem> _selectableNameTypes;

        #endregion

        #region PROPERTIES

        public List<string> Select
        {
            get
            {
                if (_select == null)
                {
                    _select = new List<string>()
                    {
                        "Uno", "Dos", "Tres"

                    };
                }
                return _select;
            }
        }
        
        public JediGen JediNameGen
        {
            get
            {
                return _jediNameGen;
            }
            set
            {
                _jediNameGen = value;
                OnPropertyChanged("JediNameGen");
            }
        }

        public string JediName
        {
            get
            {
                return _jediNameGen.JediName;
            }
            set
            {
                _jediNameGen.JediName = value;
                OnPropertyChanged("JediName");
            }
        }

        public ObservableCollection<NameTypeListItem> SelectableNameTypes
        {
            get
            {
                if (_selectableNameTypes == null)
                {
                    _selectableNameTypes = new ObservableCollection<NameTypeListItem>
                    {
                        new NameTypeListItem{ Name = Enum.NameTypes.STANDARD, Description = "Humano estándar" },
                        new NameTypeListItem{ Name = Enum.NameTypes.HUMAN_MALE, Description = "Humano Macho" },
                        new NameTypeListItem{ Name = Enum.NameTypes.HUMAN_FEMALE, Description = "Humano Hembra" },

                    };
                }
                return _selectableNameTypes;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public MainViewModel()
        {
            _jediNameGen = new JediGen();
            _jediNameGen.SelectedItem = SelectableNameTypes[0];
        }

        #endregion

        #region COMMANDS

        public ICommand ClickCommand
        {
            get
            {
                return new Command(GenerateJediName);
            }
        }

        #endregion

        #region PRIVATE METHODS

        private void GenerateJediName()
        {
            string result = "Qui Gon Jinn";
            if (string.IsNullOrEmpty(JediNameGen.Name) ||
                string.IsNullOrEmpty(JediNameGen.FirstSurname) ||
                string.IsNullOrEmpty(JediNameGen.LastSurname) ||
                string.IsNullOrEmpty(JediNameGen.City))
            {
                result = string.Empty;
            }
            else
            {
                switch(JediNameGen.SelectedItem.Name)
                {
                    case Enum.NameTypes.STANDARD:
                        result = GenerateStandardMode(JediNameGen);
                        break;
                    case Enum.NameTypes.HUMAN_FEMALE:
                        result = GenerateHumanFemaleMode(JediNameGen);
                        break;
                    case Enum.NameTypes.HUMAN_MALE:
                        result = GenerateHumanMaleMode(JediNameGen);
                        break;
                }
            }

            JediName = result;
        }

        private string GenerateHumanFemaleMode(JediGen jediNameGen)
        {
            string result = "Qui Gon Jinn";
            string jediName = "";
            string jediSurname = "";

            jediName =  JediNameGen.Name.Substring(JediNameGen.LastSurname.Length - 3, 3).ToLower() + 
                        JediNameGen.City.Substring(JediNameGen.City.Length - 2, 2).ToLower();

            jediSurname = JediNameGen.LastSurname.Substring(JediNameGen.LastSurname.Length - 3, 3).ToLower() +
                            JediNameGen.City.Substring(JediNameGen.LastSurname.Length - 2, 2).ToLower();

            jediName = jediName.Substring(0, 1).ToUpper() + jediName.Substring(1);

            jediSurname = jediSurname.Substring(0, 1).ToUpper() + jediSurname.Substring(1);

            result = jediName + " " + jediSurname;

            return result;
        }

        private string GenerateHumanMaleMode(JediGen jediNameGen)
        {
            string result = "Qui Gon Jinn";
            string jediName = "";
            string jediSurname = "";

            jediName = JediNameGen.Name.Substring(0, 3).ToLower() + JediNameGen.City.Substring(0, 3).ToLower();
            jediSurname =   JediNameGen.LastSurname.Substring(JediNameGen.LastSurname.Length - 3, 3).ToLower() + 
                            JediNameGen.City.Substring(JediNameGen.LastSurname.Length - 2, 2).ToLower();

            jediName = jediName.Substring(0, 1).ToUpper() + jediName.Substring(1);

            jediSurname = jediSurname.Substring(0, 1).ToUpper() + jediSurname.Substring(1);

            result = jediName + " " + jediSurname;

            return result;
        }

        private string GenerateStandardMode(JediGen jediNameGen)
        {
            string result = "Qui Gon Jinn";
            string jediName = "";
            string jediSurname = "";

            jediName = JediNameGen.FirstSurname.Substring(0, 3).ToLower() + JediNameGen.Name.Substring(0, 2).ToLower();
            jediSurname = JediNameGen.LastSurname.Substring(0, 2).ToLower() + JediNameGen.City.Substring(0, 3).ToLower();

            jediName = jediName.Substring(0, 1).ToUpper() + jediName.Substring(1);

            jediSurname = jediSurname.Substring(0, 1).ToUpper() + jediSurname.Substring(1);

            result = jediName + " " + jediSurname;

            return result;
        }

        #endregion


        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        if (_name != value)
        //        {
        //            _name = value;
        //            OnPropertyChanged("Name");
        //        }
        //    }
        //}

        //public string FirstSurname
        //{
        //    get { return _firstSurname; }
        //    set
        //    {
        //        if (_firstSurname != value)
        //        {
        //            _firstSurname = value;
        //            OnPropertyChanged("FirstSurname");
        //        }
        //    }
        //}

        //public string LastSurname
        //{
        //    get { return _lastSurname; }
        //    set
        //    {
        //        if (_lastSurname != value)
        //        {
        //            _lastSurname = value;
        //            OnPropertyChanged("LastSurname");
        //        }
        //    }
        //}

        //public string City
        //{
        //    get { return _city; }
        //    set
        //    {
        //        if (_city != value)
        //        {
        //            _city = value;
        //            OnPropertyChanged("City");
        //        }
        //    }
        //}

        //public string JediName
        //{
        //    get
        //    {
        //        return _jediName;
        //    }
        //    set
        //    {
        //        _jediName = value;
        //        OnPropertyChanged("JediName");
        //    }
        //}
    }
}
