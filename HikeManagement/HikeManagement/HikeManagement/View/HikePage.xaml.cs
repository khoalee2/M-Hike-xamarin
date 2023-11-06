using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HikeManagement.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HikeManagement.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HikePage : ContentPage
    {
        public HikePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabase.ReadHikes();
            }
            catch
            {

            }
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHike());
        }
        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var hike = item.CommandParameter as HikeModel;
            await Navigation.PushAsync(new AddHike(hike));
        }
        
        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var hike = item.CommandParameter as HikeModel;
            var result = await DisplayAlert("Delete", $"Are you sure to delete {hike.Name}?", "Yes", "No");
            if (result)
            {
                await App.MyDatabase.DeleteHike(hike);
                myCollectionView.ItemsSource = await App.MyDatabase.ReadHikes();
            }
        }
    }
}