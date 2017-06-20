using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Pages;
using ConsoleUI.PageLayout;

namespace ConsoleUI.PageLayout
{
    public class PageLayoutManager
    {
        public IPage StartPage { get; set; }
        
        public void Show()
        {
            Show(StartPage);
        }

        public void Show(IPage page)
        {
            if (StartPage == null)
                return;
            
            do
            {
                Console.Clear();
                _PrintTitle(page.Title);
                _PrintUndertitle(page.Undertitle);
                _WritePageConnections(page.PageConnections);

                bool outcome = false;
                do
                {
                    page.ShowCustomMessage();
                    object input = page.GetInput();
                    outcome = page.ProcessInput(this, input);
                } while (!outcome);
            } while (StartPage == page);

        }

        private void _WritePageConnections(IList<IPage> pageConnections)
        {
            for(int i = 0; i < pageConnections.Count; ++i)
            {
                Console.WriteLine("[{0}] {1}", i+1, pageConnections[i].Title);
            }
        }

        private void _PrintUndertitle(string undertitle)
        {
            Console.WriteLine("\n{0}\n", undertitle);
        }

        private void _PrintTitle(string title)
        {
            var separator = new string('=', title.Length);

            Console.WriteLine(separator);
            Console.WriteLine(title);
            Console.WriteLine(separator);
        }
    }
}
