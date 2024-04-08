using EF007.CallGroupingConfigurationUsingAssembliy.Data.Config;
using System;

namespace EF007.CallGroupingConfigurationUsingAssembliy.Entities
{
    internal class Tweet : TweetConfiguration
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string? TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
