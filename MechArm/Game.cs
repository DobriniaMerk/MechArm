using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace MechArm
{
    class Game
    {
        Arm arm = new Arm();
        bool pause = true;

        public void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if (pause)
                if (e.Button == Mouse.Button.Left)
                    arm.AddPoint(new Vector2f(e.X, e.Y));
        }

        public void MouseMoved(object sender, MouseMoveEventArgs e, RenderWindow rw)
        {
            if (!pause)
                arm.Seek((Vector2f)Mouse.GetPosition(rw));
        }

        public void KeyPressed(object sender, KeyEventArgs e, RenderWindow rw)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Space:
                    pause = !pause;
                    break;
                case Keyboard.Key.R:
                    arm = new Arm();
                    break;
            }
        }

        public void Draw(RenderWindow rw)
        {
            arm.Draw(rw);
        }
    }
}
