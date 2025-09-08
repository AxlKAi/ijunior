using System;
using Terminal.Gui;

namespace GIU_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            var login = new Label("Login") { X = 5, Y = 5 };
            top.Add(login);


            var win = new Window("MyApp")
            {
                X = 0,
                Y = 1,

                Width = 30,
                Height = 25
            };
            top.Add(win);

            Application.Run();
        }
    }
}
