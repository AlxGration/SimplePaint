using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint {
    public interface  Observable {
          void notifyAll();
          void addObserver(Observer obj);
    }
}
