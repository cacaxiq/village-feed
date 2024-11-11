using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageApp.Models;

namespace VillageApp.Handlers
{
    internal class PostSearchHandler :  SearchHandler
    {
        public IList<Post> Posts { get; set; }

    }
}
