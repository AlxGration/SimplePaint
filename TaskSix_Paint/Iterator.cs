using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix_Paint{
    public interface Iterator<T> {
        void begin();
        void last();
        bool hasNext();
        bool hasPrev();
        bool EOL();
        T next();
        
        T prev();
        T getVal();
        Node<T> getNode();
        void addNext(T elem);
        void addPrev(T elem);
        T remove();

    }
    public interface Iterable<T> {
        Iterator<T> iterator();
    }
}
