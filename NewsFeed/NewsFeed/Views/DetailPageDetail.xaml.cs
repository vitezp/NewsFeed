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
    public partial class DetailPageDetail : ContentPage, ICategory
    {
        LoadNewsViewModel loadNewsViewModel;

        public Category Category { get; set; }

        public DetailPageDetail()
        {
            InitializeComponent();

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

        protected override void OnAppearing()
        {

            base.OnAppearing();
            Title = Category.GetDescription();

            loadNewsViewModel = new LoadNewsViewModel(Category);
			BindingContext = loadNewsViewModel;
            ArticlesList.RefreshCommand = loadNewsViewModel.PullToRefreshCommand;
			//var loadedArticles = await ArticleFacade.FetchArticles(Category);
            //loadNewsViewModel.ArticleList.Clear();
            //loadedArticles.ForEach(a => loadNewsViewModel.ArticleList.Add(a));
        }
    }
}