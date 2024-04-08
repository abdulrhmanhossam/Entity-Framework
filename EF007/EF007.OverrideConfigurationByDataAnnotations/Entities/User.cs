using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF007.OverrideConfigurationByDataAnnotations.Entities
{
    [Table("tblUsers")]
    internal class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
}
