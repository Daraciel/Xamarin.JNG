using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.JNG.Models;

namespace Xamarin.JNG.Views
{
    public partial class MainView : ContentPage
    {
        private NameInfo _info;

        public MainView()
        {
            InitializeComponent();

            _info = new NameInfo
            {

            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            lblJediName.Text = _info.JediName;
        }

        private void tbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            _info.City = tbCity.Text;
        }

        private void tbSecondSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            _info.LastSurname = tbSecondSurname.Text;
        }

        private void tbFirstSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            _info.FirstSurname = tbFirstSurname.Text;
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _info.Name = tbName.Text;
        }
    }
}
