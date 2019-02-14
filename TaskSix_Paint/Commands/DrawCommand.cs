using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TaskSix_Paint {
    public class DrawCommand : Command {
        private Graphics gr;

        public DrawCommand(Graphics _gr, string _sh)
        {
            gr = _gr;
            shape = null;
        }

        public override Command clone()
        {
            throw new NotImplementedException();
        }

        public override void execute(Shape _shape)
        {
            shape = _shape;
            shape.draw(gr);
        }

        public override void unexecute()
        {
            
        }
    }
}
