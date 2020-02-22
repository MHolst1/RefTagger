using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefTagger.Core.Models
{
    public class ImageReference
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public IEnumerable<Tag> Tags => ImageReferenceTags.Select(x => x.Tag);
        public IEnumerable<ImageReferenceTag> ImageReferenceTags { get; set; }
    }
}
