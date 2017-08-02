using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Models.Requests
{
    public class ItemsRequest<T>
    {
        [Required]
        public List<T> Items { get; set; }
    }
}