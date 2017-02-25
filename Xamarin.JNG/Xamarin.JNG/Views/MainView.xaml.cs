using System;
using Xamarin.Forms;
using Xamarin.JNG.Models;
using Xamarin.JNG.ViewModels;

namespace Xamarin.JNG.Views
{
    public partial class MainView : ContentPage
    {
        private NameInfo _info;

        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
