using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages
{
    public abstract class PageBase : IPage
    {
        protected readonly List<PageItem> pageItems = new List<PageItem>();
        protected readonly List<IPage> pageConnection = new List<IPage>();
        protected readonly string title;
        protected readonly string undertitle;

        

        protected PageBase(string title, string undertitle)
        {
            this.title = title;
            this.undertitle = undertitle;
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Undertitle
        {
            get
            {
                return undertitle;
            }
        }

        IList<PageItem> IPage.MenuItems
        {
            get
            {
                return pageItems;
            }
        }

        IList<IPage> IPage.PageConnections
        {
            get
            {
                return pageConnection;
            }
        }

        public virtual void ShowCustomMessage()
        {
            
        }

        public virtual object GetInput()
        {
            return null;
        }

        public virtual bool ProcessInput(PageLayoutManager manager, object obj)
        {
            return true;
        }
    }
}
