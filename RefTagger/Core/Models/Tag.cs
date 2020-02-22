using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefTagger.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<ImageReference> ImageReferencesWithTag { get; set; }
        public ICollection<ImageReferenceTag> ImageReferenceTags { get; set; }
    }
}
