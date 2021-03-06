﻿using eOrder.CORE.Requests;
using eOrder.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eOrder.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        SearchViewModel model = null;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = model = new SearchViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            //categoryPicker.ItemsSource = model.Categories;
            //categoryPicker.ItemDisplayBinding = new Binding("Name");
        }

        private async void AddToCart(object sender, EventArgs e)
        {
            var productId = (int)(((Button)sender).BindingContext);
            await Navigation.PushModalAsync(new NavigationPage(new OrderDetailRequestPage(null, productId)));
        }

        protected void categoryPicker_SelectedIndexChanges(object sender, EventArgs eventArgs)
        {
            //if(categoryPicker.SelectedItem != null)
            //{
            //    model.CategoryId = (categoryPicker.SelectedItem as CategoryDTO).Id;
            //}
        }
    }
}