using System.ComponentModel.DataAnnotations.Schema;

namespace EF009.ExcludeEntities.Entities
{
    //[NotMapped]
    public class Snapshot
    {
        public DateTime LoadedAt => DateTime.UtcNow;
        public string Version => 
            Guid.NewGuid().ToString().Substring(0, 8);

        public override string ToString()
        {
            return $"{LoadedAt} // {Version}";
        }
    }
}
