using XamarinToolkit.Mvvm;

namespace NewsFeed.ViewModels
{
	public class AppViewModelBase : ViewModelBase
    {
        public NewsFeedDatabase NewsDb => App.Database;
    }
}