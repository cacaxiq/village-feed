﻿namespace VillageApp.Models
{
    public record Post
    {
        public required string Title { get; set; }
        public required string Id { get; set; }
        public required string Content { get; set; }
    }
}
