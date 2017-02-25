using Xamarin.Forms;
using Xamarin.JNG.ViewModels;

namespace Xamarin.JNG.Views
{
    public partial class MainView : ContentPage
    {
        protected string asdqq;

        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
