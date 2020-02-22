using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefTagger.Core.Models
{
    public class ImageReferenceTag
    {
        public int Id { get; set; }
        public int ImageReferenceId { get; set; }
        public int TagId { get; set; }
        public ImageReference ImageReference { get; set; }
        public Tag Tag { get; set; }
    }
}
