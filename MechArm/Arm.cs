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
    class Arm
    {
        public List<Point> points;

        public Arm()
        {
            points = new List<Point>();
        }

        public void AddPoint(Vector2f pos)
        {
            if (points.Count == 0)
                points.Add(new Point(pos));
            else if (pos != points[points.Count - 1]?.position)
                points.Add(new Point(pos, points[points.Count - 1]));
        }

        public void Draw(RenderWindow rw)
        {
            for (int i = points.Count - 1; i >= 0; i--)
            {
                points[i].Draw(rw);
            }
        }

        public void Seek(Vector2f target)
        {
            if (points.Count() <= 1)
                return;

            for (int j = 0; j < 30; j++)
            {
                Vector2f lastPos = target;
                Vector2f t;
                for (int i = points.Count() - 1; i > 0; i--)
                {
                    t = points[i].position - points[i].connectedTo.position;
                    t = t.Normalize();
                    t *= points[i].length;

                    points[i].position = lastPos;

                    lastPos += t;
                }


                lastPos = points[0].position;


                for (int i = 1; i <= points.Count() - 1; i++)
                {
                    t = points[i].position - lastPos;
                    t = t.Normalize();
                    t *= points[i].length;

                    lastPos += t;

                    points[i].position = lastPos;
                }
            }
        }
    }
}
