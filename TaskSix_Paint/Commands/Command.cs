using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public abstract class Command {

        protected Shape shape;

        public abstract void execute(Shape shape);
        public abstract void unexecute();
        public abstract Command clone();
        public Shape GetObj() { return shape; }
    }
}
