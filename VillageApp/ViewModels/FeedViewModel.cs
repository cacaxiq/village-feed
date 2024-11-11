
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VillageApp.Models;

namespace VillageApp.ViewModels
{
    public partial class FeedViewModel : ObservableObject
    {
        public FeedViewModel()
        {
            var posts =  GeneratePosts(15);
            Posts = new ObservableCollection<Post>(posts);
            InitialPosts = [.. posts];

        }

        public ObservableCollection<Post> Posts { get; }

        private Post[] InitialPosts { get; }


        [RelayCommand]
        private void Search(string text)
        {
            var tempPosts = InitialPosts.Where(post => post.Title.Contains(text) || post.Content.Contains(text));
            Posts.Clear();
            if (tempPosts.Any())
            {
                foreach (var post in tempPosts)
                    Posts.Add(post);
            }
            else
            {
                foreach (var post in InitialPosts)
                    Posts.Add(post);
            }
        }

        static string GenerateRandomString(int count)
        {
            Random rand = new();

            int stringlen = rand.Next(4 * count, 10 * count);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number. 
                randValue = rand.Next(0, 26);

                // Generating random character by converting 
                // the random number into character. 
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string. 
                str = str + letter;
            }

            return str;
        }

        static ObservableCollection<Post> GeneratePosts(int count)
        {
            var posts = new ObservableCollection<Post>();
            for (int i = 0; i < count; i++)
            {
                posts.Add(new Post { Id = i, Title = GenerateRandomString(1), Content = GenerateRandomString(5) });
            }
            return posts;
        }
    }
}
