using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public abstract class Observer {
        public abstract void onSubjectChanged(Observable who);
        
    }
}
