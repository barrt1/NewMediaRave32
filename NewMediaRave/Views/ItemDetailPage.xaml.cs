using NewMediaRave.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NewMediaRave.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}