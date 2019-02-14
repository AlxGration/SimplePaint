using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TaskSix_Paint{

    public class Container<T>: Observable, Iterable<T>{


        // собственно написанный  двусвязный LIST с итератором


        private  int count;
        private  Node<T> head;
        private List<Observer> observers;
        public T cur;

        public Container()
        {
            init();
        }
        

        public void loadShapes(Iterator<Shape> it)
        {
            StreamReader sr = new StreamReader(Form1.mainPath, System.Text.Encoding.Default);
            try {

                    int n = Int32.Parse(sr.ReadLine());
                    if (n > 0) {
                        Clear();
                        FactoryShape factory = new FactoryShape();
                        string className = "";
                        char ch = (char)sr.Read();
                        for (int i = 0; i < n; i++) {
                            while (ch != ' ') {
                                className += ch;
                                ch = (char)sr.Read();
                            }
                            Shape shape = factory.createShape(className);

                            if (shape != null) {
                                shape.load(sr);
                                className = "";
                                ch = (char)sr.Read();
                                it.addNext(shape);
                            }
                        }
                    }
                    sr.Close();
                
            } catch (Exception e) {
                //
            } finally {
                sr.Dispose();
            }
            
            notifyAll();
        }

        public void saveShapes(Iterator<Shape> it)
        {
                StreamWriter sw = new StreamWriter(Form1.mainPath, false, System.Text.Encoding.Default);
                sw.WriteLine(count);
                for (it.begin(); !it.EOL(); it.next()) {
                    it.getVal().save(sw);
                }
                sw.Close();
        }


        public void Add(T elem)
        {
            Node<T> node = new Node<T>(elem);

            if (head == null) {
                head = node;
                head.Next = node;
                head.Prev = node;
            } else {
                node.Prev = head.Prev;
                node.Next = head;

                head.Prev.Next = node;
                head.Prev = node;
            }
            count++;
            notifyAll();
            cur = elem;
        }
        
        /*
        public T Get(int ind)
        {
            Iterator<T> it = iterator();
            for (it.begin(); !it.eot(); it.next()) {
                if (ind == 0) return it.getVal();
                ind--;
            }
            return it.getVal(); 
        }
       
        public bool Remove (int ind)// not working
        {
            if (ind > -1 && ind < count) {
                Node<T> cur = head;
                int i = ind;
                while (ind!=0){
                    cur = cur.Next;
                    ind--;
                }

                if (count > 1) {
                    cur.Prev.Next = cur.Next;
                    cur.Next.Prev = cur.Prev;
                    if (i == 0) head = head.Next;
                } else {
                    head = null;
                }
                count--;
                notifyAll();
                return true;
            }
            
            return false;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;

            Node<T> removedItem = null;
            if (count == 0) return false;

            // поиск удаляемого узла
            do {
                if (current.Val.Equals(data)) {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != head);

            if (removedItem != null) {
                // если удаляется единственный элемент списка
                if (count == 1)
                    head = null;
                else {
                    // если удаляется первый элемент
                    if (removedItem == head) {
                        head = head.Next;
                    }
                    removedItem.Prev.Next = removedItem.Next;
                    removedItem.Next.Prev = removedItem.Prev;
                }
                count--;
                notifyAll();
                return true;
            }
            return false;
        }

        public void RemoveLast()
        {
            if (count > 0) {
                if (count > 1) {
                    head.Prev = head.Prev.Prev;
                    head.Prev.Next = head;

                } else {
                    head = null;
                }
                count--;
                notifyAll();
            }
        }
        */
        public bool IsEmpty() { return count == 0;  }

        public int Count()
        {
            return count;
        }

        public void Clear()
        {
            count = 0;
            head = null;
            notifyAll();
        }

        private void init()
        {
            cur = default(T);
            count = 0;
            head = null;
            observers = new List<Observer>();
        }
        
        public T Last()
        {
            if (head != null)
            {
                return head.Prev.Val;
            }
            return default(T);
        }
        public T First()
        {
            if (head != null)
            {
                return head.Val;
            }
            return default(T);
        }
        public Iterator<T> iterator()
        {
            return new ListIterator(this);
        }

        public  void notifyAll()
        {
            if (observers != null)
                for(int i = 0; i < observers.Count(); i++) {
                    observers[i].onSubjectChanged(this);
                }
        }

        public  void addObserver(Observer obj)
        {
            observers.Add(obj);
        }

        private class ListIterator : Iterator<T> {
            Node<T> cur;
            int k = 0;
            Container<T> cont;

            public ListIterator(Container<T> _cont)
            {
                cont = _cont;
            }

            public void begin()
            {
                k = 0;
                cur = cont.head;
                if (cur != null)
                    cont.cur = cur.Val;
            }
            public void last()
            {
                k = cont.count - 1;
                if (cont.head.Prev != null)
                    cur = cont.head.Prev;
            }
            public bool hasNext()
            {
                return (k < cont.count - 1);
            }

            public bool hasPrev()
            {
                return (k >0);
            }

            public bool EOL()
            {
                return (k == cont.count);
            }

            public T next()
            {
                if (cont.count > 0) {
                    k++;
                    cur = cur.Next;
                    cont.cur = cur.Val;
                    return cur.Val;
                }
                return default(T);
            }
            public T prev()
            {
                k--;
                cur = cur.Prev;
                cont.cur = cur.Val;
                return cur.Val;
            }
            public T getVal()
            {
                return cur.Val;
            }
            public Node<T> getNode()
            {
                return cur;
            }
            public void addPrev(T elem)
            {
                Node<T> node = new Node<T>(elem);

                if (cur == null) {
                    cont.head = node;
                    cont.head.Next = node;
                    cont.head.Prev = node;
                } else {
                    node.Prev = cur.Prev;
                    node.Next = cur;

                    cur.Prev.Next = node;
                    cur.Prev = node;
                }
                cur = node;
                if (!hasPrev()) cont.head = node;
                cont.count++;
                cont.cur = cur.Val;
                cont.notifyAll();
            }
            public void addNext(T elem)
            {
                Node<T> node = new Node<T>(elem);

                if (cur == null) {
                    cont.head = node;
                    cont.head.Next = node;
                    cont.head.Prev = node;
                } else {
                    node.Prev = cur;
                    node.Next = cur.Next;
                    
                    cur.Next.Prev = node;
                    cur.Next = node;
                }
                cur = node;

                cont.count++;
                cont.cur = cur.Val;
                cont.notifyAll();
            }
            public T remove()
            {
                T v = cur.Val;
                if (cur == cont.head && cont.count > 1) {
                    cur.Prev.Next = cur.Next;
                    cur.Next.Prev = cur.Prev;
                    cont.head = cur.Next;
                    cur = cont.head.Prev;
                    cont.count--;
                    k--;
                } else {
                    if (cur == cont.head && cont.count == 1) {    // del last
                        cur = null;
                        cont.head = null;
                        k = 0;
                        cont.count = 0;
                    } else {
                        if (cur != cont.head && cont.count > 1) {
                            cur.Prev.Next = cur.Next;
                            cur.Next.Prev = cur.Prev;
                            cur = cur.Prev;
                            cont.count--;
                            k--;
                        }
                    }
                }
                if (cur != null)
                    cont.cur = cur.Val;
                cont.notifyAll();
                return v;
            }
            
        }
        ~Container()
        {
            Clear();
        }
    }

    public class Node<T> {
        T val;
        Node<T> prev, next;

        public Node(T val, Node<T> prev, Node<T> next)
        {
            this.prev = prev;
            this.val = val;
            this.next = next;
        }
        public Node(T val)
        {
            this.val = val;
        }
        public T Val {
            get { return val; }
            set { val = value; }
        }

        public Node<T> Prev {
            get { return prev; }
            set { prev = value; }
        }

        public Node<T> Next {
            get { return next; }
            set { next = value; }
        }
    }
    
}
