using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskSix_Paint {
    public class ContainerObs: Observer {
        TreeNodeCollection nodeCollection;
        public ContainerObs(TreeNodeCollection _nodeCollection)
        {
            nodeCollection = _nodeCollection;
        }

        public override void onSubjectChanged(Observable who)
        {
            
            Container<Shape> list = (Container<Shape>)who;
            nodeCollection.Clear();
            if (list.Count() > 0) { 
                Iterator<Shape> iter = list.iterator();
                for (iter.begin(); !iter.EOL(); iter.next()) {
                    iter.getVal().processNode(nodeCollection);
                }
            }
            
        }
    }
}
