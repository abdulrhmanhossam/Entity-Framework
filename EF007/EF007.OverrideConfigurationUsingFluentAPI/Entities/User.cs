using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF007.OverrideConfigurationUsingFluentAPI.Entities
{   
    internal class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
