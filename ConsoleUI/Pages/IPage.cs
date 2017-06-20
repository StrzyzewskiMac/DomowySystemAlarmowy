using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Pages;
using ConsoleUI.PageLayout;

namespace ConsoleUI.Pages
{
    public interface IPage
    {
        string Title { get; }

        string Undertitle { get; }

        IList<PageItem> MenuItems { get; }

        IList<IPage> PageConnections { get; }

        void ShowCustomMessage();

        object GetInput();

        bool ProcessInput(PageLayoutManager manager, object obj);
    }
}
