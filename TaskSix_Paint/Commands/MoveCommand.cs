using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public class MoveCommand : Command {

        int dx, dy;

        public MoveCommand(int _dx, int _dy)
        {
            shape = null;
            dx = _dx;
            dy = _dy;
        }

        public MoveCommand(int _dx, int _dy, Shape _shape)
        {
            shape = _shape;
            dx = _dx;
            dy = _dy;
        }

        public override Command clone()
        {
            return new MoveCommand(dx, dy, shape);
        }

        public override void execute(Shape _shape)
        {
            shape = _shape;
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.move(dx, dy);
                shape.show(Form1.gr);
            }
            
        }

        public override void unexecute()
        {
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.move(-dx, -dy);
                shape.show(Form1.gr);
            }
        }
    }
}
