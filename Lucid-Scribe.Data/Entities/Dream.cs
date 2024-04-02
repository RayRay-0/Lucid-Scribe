using System.Security.Cryptography.X509Certificates;
using Lucid_Scribe.Data.Entities.Abstractions;

namespace Lucid_Scribe.Data.Entities
{
    public class Dream : BaseEntity
    {
        public Dream()
        {
            Emotions = new HashSet<Emotion>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public virtual ICollection<Emotion>? Emotions { get; set; }
    }
}