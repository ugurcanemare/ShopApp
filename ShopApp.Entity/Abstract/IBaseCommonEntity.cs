using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entity.Abstract
{
    public interface IBaseCommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}