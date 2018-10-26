using System;
using System.Collections.Generic;

namespace CoreServices.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
