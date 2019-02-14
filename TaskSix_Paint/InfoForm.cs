using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskSix_Paint
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            lbl_info.Text = "LCick - создание объекта\nRClick - удаление выделенных фигур\n"
                            +"8 - движение вверх\n6 - движение влево\n2 - движение вниз\n4 - движение вправо\n"
                            +"7 - вращение влево\n9 - вращение вправо\n+ - увеличение\n- - уменьшение\n" 
                            +"q - создать круг\nw - создать треугольник\ne - создать квадрат\n"
                            +"r - создать пятиугольник\nt - создать звезду";
        }
    }
}
