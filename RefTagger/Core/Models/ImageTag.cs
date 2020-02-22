using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefTagger.Core.Models
{
    public class ImageTag
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
