using EF007.OverrideConfigurationByGrouping.Data.Config;
using System;

namespace EF007.OverrideConfigurationByGrouping.Entities
{
    internal class Tweet : TweetConfiguration
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string? TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
