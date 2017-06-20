using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Pages
{
    public struct PageItem
    {
        public string ItemName { get; set; }

        public Action<object> ItemAction { get; set; }
    }
}
