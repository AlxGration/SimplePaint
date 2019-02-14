using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public class RotationCommand : Command{

        float k;

        public RotationCommand(float _k)
        {
            shape = null;
            k = _k;
        }

        public RotationCommand(float _k, Shape _shape)
        {
            shape = _shape;
            k = _k;
        }

        public override Command clone()
        {
            return new RotationCommand(k, shape);
        }

        public override void execute(Shape _shape)
        {
            shape = _shape;
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.rotation(k);
                shape.show(Form1.gr);
            }
        }

        public override void unexecute()
        {
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.rotation(-k);
                shape.show(Form1.gr);
            }
        }
    }
}
