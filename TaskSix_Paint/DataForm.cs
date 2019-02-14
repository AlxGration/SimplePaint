using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskSix_Paint {
    public partial class DataForm : Form {
        public DataForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.starVertexCount = (Byte)num_star_vertex.Value;
            this.Visible = false;
        }
    }
}
