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
        /// Color , People (string) , places, objects, weirdness slider (0 - 1) <summary>
        public string People { get; set; }
        public string Places { get; set; }
        public string Objects { get; set; }
        public int Weirdness { get; set; }   
        public virtual ICollection<Emotion>? Emotions { get; set; }
    }
}