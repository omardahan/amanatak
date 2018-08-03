using AmanatakBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amanatak.Models
{
    public class MissingItemViewModel
    {

        public Item Item { get; set; }
        public List<HttpPostedFileBase> ItemImages { get; set; }
        public List<ItemImages> ItemImagesList { get; set; }
        public ItemOwner ItemOwner { get; set; }
     }
}