using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RC.Models
{
    public class Factor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Model Category
        public Category Category { get; set; }
        public int categoryId { get; set; }

    }
}