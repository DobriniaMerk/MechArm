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
        //Arm arm = new Arm();
        List<Arm> arms = new List<Arm>();
        int i = 0;
        bool pause = true;

        public void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if (pause)
                if (e.Button == Mouse.Button.Left)
                    if (arms.Count == 0)
                        arms.Add(new Arm());
                    arms[i].AddPoint(new Vector2f(e.X, e.Y));
        }

        public void MouseMoved(object sender, MouseMoveEventArgs e, RenderWindow rw)
        {
            if (!pause)
                foreach(Arm arm in arms)
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
                    arms = new List<Arm>();
                    i = 0;
                    break;
                case Keyboard.Key.N:
                    arms.Add(new Arm());
                    i++;
                    break;
            }
        }

        public void Draw(RenderWindow rw)
        {
            foreach(Arm arm in arms)
                arm.Draw(rw);
        }
    }
}
