using DemoList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<User> UserList;
        public MainPage()
        {
            InitializeComponent();
            UserList = new ObservableCollection<User>()
            {
                new User{Id=1,Name="Hiren1" },
                 new User{Id=2,Name="Hiren2" },
                  new User{Id=3,Name="Hiren3" },
                   new User{Id=4,Name="Hiren4" },
                    new User{Id=5,Name="Hiren5" },
            };
            UserData.ItemsSource = UserList;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            //var lastId = 1;
            //if (UserList.Count > 1)
            //{
              var  lastId = UserList[UserList.Count - 1].Id;
               
            //}            
            var newUser = new User();
            newUser.Id = lastId+1;
            newUser.Name = MyName.Text;
            UserList.Add(newUser);
            MyName.Text = null;

        }     

        private async Task Delete_Tapped_Async(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Image)sender;
            var data = (User)(((TapGestureRecognizer)item.GestureRecognizers[0]).CommandParameter);
            if (data != null)
            {
                var deleteItem = await Application.Current.MainPage.DisplayAlert("Delete", "Really want to delete item", "OK", "Cancel");
                if (deleteItem)
                {
                    UserList.Remove(data);
                    
                }
            }
        }
    }
}
