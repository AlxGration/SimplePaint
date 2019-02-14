using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TaskSix_Paint {
    public partial class Form1 : Form {
        Random rand;
        DataForm dForm = new DataForm();        // форма , в которой м-о выбрать кол-во углов звезды
        public static Graphics gr;
        public static Color curColor;           // текущий цвет
        public static int brush_w;              // ширина кисти
        public static string mainPath = @"C:\Users\alex\Desktop\";

        private string curShape = "";
        public static Byte starVertexCount;     // по названию понятно
        
        public const char CH_BRUSHW_COLOR = 'C';
        public const byte STEP = 10;             // шаг для +- размера и передвижения
        public const float ROTATION_K = 0.2f;

        public const int WINDOW_WIDTH = 1184;
        public const int WINDOW_HEIGHT = 663;
        public const int STD_SHAPE_SIZE = 25;

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        public static Color backgroundColor;


        Iterator<Shape> iter;
        Iterator<Shape> paintIter;
        Dictionary<char, Command> commands;     // тут хранятся доступные команды
        Stack<Command> history;                 
        Container<Shape> cont;                  // контейнер фигур

        FactoryShape factory;
        ContainerObs contObserver;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            brush_w = bar_pen_w.Value;
            starVertexCount = 5;

            curColor = Color.Black;
            backgroundColor = SystemColors.ControlLight;
            gr = this.CreateGraphics();

            cont = new Container<Shape>();
            contObserver = new ContainerObs(treeView1.Nodes);
            cont.addObserver(contObserver);     // подпишемся на события контейнера для treeView

            rand = new Random();
            factory = new FactoryShape();
            iter = cont.iterator();
            paintIter = cont.iterator();

            commands = new Dictionary<char, Command>();
            commands['8'] = new MoveCommand(0, -STEP);  // up
            commands['4'] = new MoveCommand(-STEP, 0);  // left
            commands['2'] = new MoveCommand(0, STEP);   // down
            commands['6'] = new MoveCommand(STEP, 0);   // right

            commands['7'] = new RotationCommand(-ROTATION_K);   // rot L
            commands['9'] = new RotationCommand(ROTATION_K);    // rot R

            commands['+'] = new SizeCommand(STEP);      // size +
            commands['-'] = new SizeCommand(-STEP);     // size -
            //commands['c'] = new DrawCommand(gr, "Circle");

            history = new Stack<Command>();

            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        
        private void shapes_ClickListener(object sender, MouseEventArgs e)
        {
            unselectTools();
            curShape = ((PictureBox)sender).Tag.ToString();
            ((PictureBox)sender).BackColor = SystemColors.ActiveBorder;
            
            if (curShape == "Star" || curShape == "Polygon") dForm.Show();     // вызов формы для выбора кол-ва вершин звезды 
        }
        
        private void unselectTools()
        {
            pic_polygon.BackColor = Color.Transparent;
            pic_circle.BackColor = Color.Transparent;
            pic_star.BackColor = Color.Transparent;
        }

        private void drawShapeListener(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {    // L click - paint 
                Shape sh = findCollision(e.X, e.Y);
                if (sh == null) {
                    drawShape(e.X, e.Y, curShape);
                } else {                            // or select
                    foreach (TreeNode tn in treeView1.Nodes) {
                        if (tn.Text == cont.cur.shapeName()) {
                            if (tn.IsSelected) treeView1.SelectedNode = null;
                            else treeView1.SelectedNode = tn;
                            cont.cur = sh;
                            break;
                        }
                    }
                    treeView1.Select();
                }
            } else {                                // R click - select or delete
               
                if (e.Button == MouseButtons.Right) {
                    deleteSelected();
                }else {
                    unselectAll(cont);
                    paintAction();
                }
            }
        }
        
        public void paintAction()
        {
            for (paintIter.begin(); !paintIter.EOL(); paintIter.next()) {
                paintIter.getVal().hide(gr);
                paintIter.getVal().show(gr);
            }
        }
        
        public Shape findCollision(int x, int y)
        {
            for (iter.begin(); !iter.EOL(); iter.next()) {
                if (iter.getVal().collisionEnter(x, y)) {
                    return iter.getVal();
                }
            }
            return null;
        }

        private void moveShapesListener(object sender, KeyPressEventArgs e)
        {
            // add action to SELECTED SHAPES
            Command command = null;
            if (commands.ContainsKey(e.KeyChar))
            {
                command = commands[e.KeyChar];
            }

            if (command != null)
            {
                for (iter.begin(); !iter.EOL(); iter.next())
                {
                    if (iter.getVal().brush.isSelect())
                    {
                        command.execute(iter.getVal());         // action
                        history.Push(command.clone());   
                    }
                }
                if (history.Count > 100) history.Clear();    // почистим память, если слишком много сохранили

            }

            if (e.KeyChar == (char)Keys.Back && history.Count > 0)
            {
                history.Peek().unexecute();
            }
            

            // keyboard creating shape
            if (e.KeyChar == 'q') drawShape(rand.Next(142 + STD_SHAPE_SIZE, WINDOW_WIDTH - STD_SHAPE_SIZE), rand.Next(STD_SHAPE_SIZE + 30, WINDOW_HEIGHT - STD_SHAPE_SIZE - 30), "Circle"); //+30 IS MENU
            if (e.KeyChar == 'w'){
                starVertexCount = 3;
                drawShape(rand.Next(142 + STD_SHAPE_SIZE, WINDOW_WIDTH - STD_SHAPE_SIZE), rand.Next(STD_SHAPE_SIZE + 30, WINDOW_HEIGHT - STD_SHAPE_SIZE - 30), "Polygon");
            //triangle
                
            }
            if (e.KeyChar == 'e'){
                starVertexCount = 4;
                drawShape(rand.Next(142 + STD_SHAPE_SIZE, WINDOW_WIDTH - STD_SHAPE_SIZE), rand.Next(STD_SHAPE_SIZE + 30, WINDOW_HEIGHT - STD_SHAPE_SIZE-30), "Polygon");
            // rectangle
               
            }
            if (e.KeyChar == 'r'){
                starVertexCount = 5;
                drawShape(rand.Next(142 + STD_SHAPE_SIZE, WINDOW_WIDTH - STD_SHAPE_SIZE), rand.Next(STD_SHAPE_SIZE + 30, WINDOW_HEIGHT - STD_SHAPE_SIZE - 30), "Polygon");
            //5angle
               
            }
            if (e.KeyChar == 't'){
                starVertexCount = 5;
                drawShape(rand.Next(142 + STD_SHAPE_SIZE, WINDOW_WIDTH - STD_SHAPE_SIZE), rand.Next(STD_SHAPE_SIZE + 30, WINDOW_HEIGHT - STD_SHAPE_SIZE - 30), "Star");
            // star 5
                
            }

        }
        

        public void drawShape(int x, int y, string className)
        {
            if (className != "") {

                unselectAll(cont);
                paintAction();
                // and after creating some shape, it stand selected
                Shape shape = factory.createShape(x, y, className);
                if (shape != null)
                {
                    cont.Add(shape);
                  
                    cont.Last().draw(gr);
                    toolStripMenuItemCounter.Text = cont.Count() + "";  // счетчик фигур на форме, отображается слева вверху
                } 
            }
        }
        

        private void MenuFileClick(object sender, MouseEventArgs e)
        {

            if (((ToolStripMenuItem)sender).Tag.ToString() == "Save") {
                // SAVE
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                mainPath = saveFileDialog.FileName;
               
                MessageBox.Show("Файл сохранен");

                cont.saveShapes(cont.iterator());

            } else {
                // OPEN
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                mainPath = openFileDialog.FileName;
               
                
                MessageBox.Show("Файл открыт");
                cont.loadShapes(cont.iterator());
                paintAction();
            }

            toolStripMenuItemCounter.Text = cont.Count()+"";

        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for(iter.begin(); !iter.EOL(); iter.next()) {
                if (iter.getVal().shapeName() == e.Node.Text) {
                    iter.getVal().hide(gr);
                    iter.getVal().brush.select();
                    iter.getVal().show(gr);
                    break;
                }
            }            
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void palitra_ClickListener(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {

                if (((Label)sender).Name.ToString() == "btn_bgcolor") {
                    this.BackColor = colorDialog1.Color;
                    backgroundColor = colorDialog1.Color;
                } else {
                    curColor = colorDialog1.Color;
                    notifyPropertyChanged();
                }
                ((Label)sender).BackColor = colorDialog1.Color;
            }
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cont.Clear();
            Invalidate();
            toolStripMenuItemCounter.Text = "0";
        }

        private void deleteSelected()
        {
            Iterator<Shape> it = cont.iterator();
            string delName = "";
            for (it.begin(); !it.EOL(); it.next()) {
                if (it.getVal().brush.isSelect()) {
                    it.getVal().hide(gr);   // hide

                    delName = it.getVal().shapeName();
                    it.remove();
                    
                    toolStripMenuItemCounter.Text = cont.Count() + "";

                }
            }
          
            paintAction();
        }

        private void bar_pen_w_Scroll(object sender, EventArgs e) // регулятор толщины кисти
        {
            brush_w = bar_pen_w.Value;
            notifyPropertyChanged();
        }

        public void notifyPropertyChanged() // если изменили цвет или толщину кисти, примменить изменения ко всем выделенным
        {
            for (iter.begin(); !iter.EOL(); iter.next()) {
                if (iter.getVal().brush.isSelect()) {
                    iter.getVal().doAction(CH_BRUSHW_COLOR);    // action
                    iter.getVal().hide(gr);                     // hide

                    iter.getVal().show(gr);                     // show
                }
            }
        }
        public void unselectAll(Container<Shape> c)
        {
            
            if (c.Count() > 0) {
                Iterator<Shape> it = c.iterator();
                for (it.begin(); !it.EOL(); it.next()) {
                    if (it.getVal().brush.isSelect()) {
                        it.getVal().hide(gr);         // hide
                        it.getVal().brush.select();   // action
                        it.getVal().show(gr);         // show
                    }
                }
            }

        }
        
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void btn_group_Click(object sender, EventArgs e)
        {
            if (cont.Count() > 0)
            {
                ShapeGroup shapeGroup = new ShapeGroup();
                Iterator<Shape> it = cont.iterator();
                for (it.begin(); !it.EOL(); it.next())
                {
                    if (it.getVal().brush.isSelect())
                    {
                        break;
                    }
                }
                if (((Button)sender).Text == "Group")
                {
                    // GROUP  

                    for (; !it.EOL(); it.next())
                    {
                        if (it.getVal().brush.isSelect())
                        {
                            shapeGroup.addShape((VShape)it.remove()); // transfer obj from main container to group
                        }
                    }
                    unselectAll(shapeGroup.children);   // shapes in group is unselect
                    cont.Add(shapeGroup);
                }
                else
                {
                    // UNGROUP
                    if (it.getVal().className() == "ShapeGroup ") {
                        shapeGroup = ((ShapeGroup)it.getVal()); // save shapeGroup in var
                        Iterator<Shape> itChild = shapeGroup.children.iterator();
                        shapeGroup.hide(gr);                    // 
                        it.remove();                            // remove shapeGroup


                        for (itChild.begin(); !itChild.EOL(); itChild.next()) {
                            it.addNext(itChild.remove());   // transfer obj from group to main container

                            it.getVal().brush.select();     // when ungroup, obj stand select for u can group undo
                            it.getVal().show(gr);
                        }
                    }
                }
                paintAction();
                toolStripMenuItemCounter.Text = cont.Count() + "";
            }
        }

        private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm info = new InfoForm();
            info.Show();
        }
    }
}
