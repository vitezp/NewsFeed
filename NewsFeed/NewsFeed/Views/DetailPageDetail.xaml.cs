using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsFeed.API;
using NewsFeed.Models;
using NewsFeed.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeed.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPageDetail : ContentPage
    {
        readonly LoadNewsViewModel loadNewsViewModel;

        public string Category { get; set; }

        public DetailPageDetail()
        {
            InitializeComponent();

            loadNewsViewModel = new LoadNewsViewModel();

            BindingContext = loadNewsViewModel;
            ArticlesList.RefreshCommand = loadNewsViewModel.PullToRefreshCommand;

            ArticlesList.IsPullToRefreshEnabled = true;

            ArticlesList.ItemTapped += (sender, e) =>
            {
                ArticlesList.SelectedItem = null;
            };
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var article = e.SelectedItem as Article;

            if (article == null)
            {
                return;
            }

            var inAppBrowser = new InAppBrowser(article.Url)
            {
                BindingContext = article
            };

            Navigation.PushModalAsync(inAppBrowser);
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            var loadedArticles = await ArticleFacade.GetArticles(Category);
            loadNewsViewModel.ArticleList.Clear();
            loadedArticles.ForEach(a => loadNewsViewModel.ArticleList.Add(a));

            //ArticlesList.ItemsSource = loadedArticles;
        }
    }
}