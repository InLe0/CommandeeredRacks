using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XaFirstMVVMNav.Models;
using XaFirstMVVMNav.ViewModels;
using System.Reflection;

namespace XaFirstMVVMNav.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
    {
		public MasterDetail ()
		{
			InitializeComponent ();
            profileImage.Source = ImageSource.FromFile("spider.jpg");

            navigationList.ItemsSource = GetMenuList();

            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Try ViewModel",
                Detail = "Try it out",
                ImagePath = "skeleton.png",
                TargetViewModel = typeof(TryViewModel) 
            });

            list.Add(new MasterMenuItems()
            {
                Text = "Test ViewModel",
                Detail = "Test it out",
                ImagePath = "grill.png",
                TargetViewModel = typeof(TestViewModel)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Welcome",
                Detail = "Welcome is here",
                ImagePath = "grill.png",
                TargetViewModel = typeof(WelcomeViewModel)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Information",
                Detail = "You find information here",
                ImagePath = "grill.png",
                TargetViewModel = typeof(InfoViewModel)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "About",
                Detail = "About us page",
                ImagePath = "grill.png",
                TargetViewModel = typeof(AboutViewModel)
            });

            return list;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;

            var viewModel = (ViewModels.MasterDetailViewModel)this.BindingContext;
            viewModel.ChangeVMCMD.Execute(selectedMenuItem);

            IsPresented = false;
        }
    }
}