using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanatakBLL.Models
{
   public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public bool Status { get; set; }
        public ICollection<Types> Types { get; set; }
       
    }
    public enum Types
    {
        type1,
        type2
    }
}
