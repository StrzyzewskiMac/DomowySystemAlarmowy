using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUI.Pages;
using ConsoleUI.PageLayout;
using SystemCore.Exceptions;

namespace ConsoleUI.Helpers
{
    public static class PageHelper
    {
        private const string ChoosePage_ = "Wybierz jedna z akcji: ";
        public const string MissingDataError = "To pole jest wymagane.";

        public static string ToOnOffStatus(this bool status)
        {
            return status ? "ON" : "OFF";
        }

        public static T ReadInput<T>(string msg)
        {
            if (msg == null)
                throw new ArgumentNullException("msg");

            Console.Write(msg);
            string input = Console.ReadLine();
            try
            {
                var castedVal = (T)Convert.ChangeType(input, typeof(T));
                return castedVal;
            }
            catch(Exception)
            {
                return default(T);
            }
        }
        
        public static void WriteStatus(string msg)
        {
            var truncatedString = (msg.Length >= Console.WindowWidth) ? 
                msg.Substring(0, Console.WindowWidth - 1) : msg;
            int curLeft = Console.CursorLeft, curTop = Console.CursorTop;
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(new string(' ', Console.WindowWidth - 1));
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            WriteInAnotherColor(truncatedString, ConsoleColor.DarkRed);
            Console.SetCursorPosition(curLeft, curTop);
        }

        public static T GetValidInput<T>(string msg)
        {
            T input = default(T);
            do
            {
                input = ReadInput<T>(msg);
                if (input == null)
                {
                    Console.Error.WriteLine(MissingDataError);
                    continue;
                }

                var inputAsString = input as string;
                if (inputAsString != null && inputAsString == string.Empty)
                {
                    Console.Error.WriteLine(MissingDataError);
                    continue;
                }

                break;
            } while (true);

            return input;
        }

        public static bool GetAnswer(string q, params string[] possibleAnswers)
        {
            var ans = ReadInput<string>(string.Format(q));
            return ans != null && possibleAnswers.Contains(ans);
        }

        public static int ChoosePage()
        {
            return ReadInput<int>(ChoosePage_);   
        }

        public static void WriteInAnotherColor(string msg, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = old;
        }


        public static void PrintError(Exception ex, string template = "{0}")
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(template, ex.Message);
            Console.ForegroundColor = oldColor;
            AwaitAnyKey();
        }

        public static void AwaitAnyKey()
        {
            Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        public static bool GoToPage(PageLayoutManager manager, IList<IPage> pageConnection, object obj)
        {
            int page = (int)obj;
            if (page < 1 || page > pageConnection.Count)
                return false;

            try
            {
                var nextPage = pageConnection[page - 1];
                manager.Show(nextPage);

                return true;
            }
            catch(AccessDeniedException ade)
            {
                PrintError(ade, "Niewystarczające uprawnienia: {0}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
