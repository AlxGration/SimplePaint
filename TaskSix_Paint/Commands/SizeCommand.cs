using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public class SizeCommand : Command{

        int k;

        public SizeCommand(int _k)
        {
            shape = null;
            k = _k;
        }

        public SizeCommand (int _k , Shape _shape)
        {
            k = _k;
            shape = _shape;
        }

        public override Command clone()
        {
            return new SizeCommand(k, shape);
        }

        public override void execute(Shape _shape)
        {
            shape = _shape;
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.changeSize(k);
                shape.show(Form1.gr);
            }
        }

        public override void unexecute()
        {
            if (shape != null) {
                shape.hide(Form1.gr);
                shape.changeSize(-k);
                shape.show(Form1.gr);
            }
        }
    }
}
