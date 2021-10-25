using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace MechArm
{
    class Program
    {
        static Game game;
        static RenderWindow rw;

        static void Main(string[] args)
        {
            VideoMode vm = new VideoMode(800, 600);
            rw = new RenderWindow(vm, "Da movving arhm");
            game = new Game();

            rw.MouseButtonPressed += OnMousePressed;
            rw.Closed += OnClose;
            rw.KeyPressed += OnKeyPressed;
            rw.MouseMoved += OnMouseMoved;

            while (rw.IsOpen)
            {
                rw.DispatchEvents();
                rw.Clear();
                game.Draw(rw);
                rw.Display();
            }
        }

        static void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            game.MousePressed(sender, e);
        }

        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                RenderWindow rw = sender as RenderWindow;
                rw.Close();
            }

            game.KeyPressed(sender, e, rw);
        }

        static void OnClose(object sender, EventArgs e)
        {
            (sender as RenderWindow)?.Close();
        }

        static void OnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            game.MouseMoved(sender, e, rw);
        }
    }
}
