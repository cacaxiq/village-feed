﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using VillageApp.Data;
using VillageApp.Models;
using VillageApp.Services;
using VillageApp.ViewModels.Base;

namespace VillageApp.ViewModels
{
    public partial class FeedViewModel(INavigationService navigationService, AppDbContext dbContext) : ViewModelBase(navigationService)
    {
        private readonly INavigationService navigationService = navigationService;
        private readonly AppDbContext dbContext = dbContext;

        public ObservableCollectionEx<Post> Posts { get; } = [];

        public override async Task InitializeAsync()
        {
            var posts = dbContext.Posts.Include(post => post.User).Select(post => post.ToModel()).ToList();
            Posts.ReloadData(posts);
        }

        [RelayCommand]
        private void Search(string text)
        {
            var posts = dbContext.Posts
                .Include(post => post.User)
                .Where(post => post.Title.Contains(text) || post.Content.Contains(text))
                .Select(post => post.ToModel())
                .ToList();

            Posts.ReloadData(posts);
        }

        [RelayCommand]
        private Task AddPost()
        {
            return navigationService.NavigateToAsync("AddPost");
        }
    }
}
