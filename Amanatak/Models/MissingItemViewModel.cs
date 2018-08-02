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
        public List<ItemImages> ItemImages { get; set; }
        public ItemOwner ItemOwner { get; set; }
        public History History { get; set; }
    }
}