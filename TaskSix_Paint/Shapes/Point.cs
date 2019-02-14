using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public class Point{
        private int _x, _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }
        public int y {
            get { return _y; }
            set { _y = value; }
        }

        public void add(int kx, int ky)
        {
            _x += kx;
            _y += ky;
        }
        public void setXY(int x, int y)
        {
            _x = x;
            _y = y;
        }

    }
}
