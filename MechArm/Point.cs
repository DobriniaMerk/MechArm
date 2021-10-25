using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace MechArm
{
    class Point
    {
        public Point connectedTo;
        public Vector2f position;
        public Point afterConnectoin = null;
        public float length = 0;

        public Point(Vector2f pos, Point conn = null)
        {
            position = pos;
            connectedTo = conn;
            if (connectedTo != null)
            {
                connectedTo.afterConnectoin = this;
                length = position.Distanse(connectedTo.position);
            }
        }

        public void Draw(RenderWindow rw)
        {
            CircleShape cr = new CircleShape(10);
            cr.Position = new Vector2f(position.X - 10, position.Y - 10);
            cr.FillColor = new Color(150, 25, 25);

            if (connectedTo != null)
            {
                Vertex[] va = new Vertex[2];
                va[0] = new Vertex(new Vector2f(position.X, position.Y));
                va[1] = new Vertex(new Vector2f(connectedTo.position.X, connectedTo.position.Y));
                rw.Draw(va, PrimitiveType.Lines);

                cr.FillColor = new Color(255, 50, 50);
            }

            rw.Draw(cr);
        }

        public void Rotate(float angle, Vector2f origin)
        {
            if (connectedTo == null)
                return;

            Vector2f dir = position - origin;

            float ca = (float)Math.Cos(angle * (Math.PI / 180));
            float sa = (float)Math.Sin(angle * (Math.PI / 180));
            dir = new Vector2f(ca * dir.X - sa * dir.Y, sa * dir.X + ca * dir.Y);
            position = dir + origin;

            if(afterConnectoin != null)
                afterConnectoin.Rotate(angle, origin);
        }
    }
}
