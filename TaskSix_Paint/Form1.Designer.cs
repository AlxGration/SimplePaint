namespace TaskSix_Paint {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemCounter = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_group = new System.Windows.Forms.Button();
            this.pic_polygon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_star = new System.Windows.Forms.PictureBox();
            this.bar_pen_w = new System.Windows.Forms.TrackBar();
            this.btn_color = new System.Windows.Forms.Label();
            this.btn_bgcolor = new System.Windows.Forms.Label();
            this.pic_circle = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_polygon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_star)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_pen_w)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_circle)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCounter,
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemCounter
            // 
            this.toolStripMenuItemCounter.Name = "toolStripMenuItemCounter";
            this.toolStripMenuItemCounter.Size = new System.Drawing.Size(25, 24);
            this.toolStripMenuItemCounter.Text = "0";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.openMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(158, 24);
            this.saveMenuItem.Tag = "Save";
            this.saveMenuItem.Text = "Сохранить";
            this.saveMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuFileClick);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(158, 24);
            this.openMenuItem.Tag = "Open";
            this.openMenuItem.Text = "Открыть";
            this.openMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuFileClick);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.очиститьToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.управлениеToolStripMenuItem.Text = "Управление";
            this.управлениеToolStripMenuItem.Click += new System.EventHandler(this.управлениеToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btn_group);
            this.groupBox1.Controls.Add(this.pic_polygon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pic_star);
            this.groupBox1.Controls.Add(this.bar_pen_w);
            this.groupBox1.Controls.Add(this.btn_color);
            this.groupBox1.Controls.Add(this.btn_bgcolor);
            this.groupBox1.Controls.Add(this.pic_circle);
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 632);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(0, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 30);
            this.button1.TabIndex = 16;
            this.button1.Text = "Ungroup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // btn_group
            // 
            this.btn_group.AutoSize = true;
            this.btn_group.Location = new System.Drawing.Point(0, 437);
            this.btn_group.Name = "btn_group";
            this.btn_group.Size = new System.Drawing.Size(142, 30);
            this.btn_group.TabIndex = 15;
            this.btn_group.Text = "Group";
            this.btn_group.UseVisualStyleBackColor = true;
            this.btn_group.Click += new System.EventHandler(this.btn_group_Click);
            // 
            // pic_polygon
            // 
            this.pic_polygon.BackColor = System.Drawing.Color.Transparent;
            this.pic_polygon.Image = global::TaskSix_Paint.Properties.Resources.ic_poly;
            this.pic_polygon.Location = new System.Drawing.Point(71, 96);
            this.pic_polygon.Name = "pic_polygon";
            this.pic_polygon.Size = new System.Drawing.Size(65, 65);
            this.pic_polygon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_polygon.TabIndex = 14;
            this.pic_polygon.TabStop = false;
            this.pic_polygon.Tag = "Polygon";
            this.pic_polygon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shapes_ClickListener);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 517);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Кисть:";
            // 
            // pic_star
            // 
            this.pic_star.BackColor = System.Drawing.Color.Transparent;
            this.pic_star.Image = global::TaskSix_Paint.Properties.Resources.ic_star;
            this.pic_star.InitialImage = null;
            this.pic_star.Location = new System.Drawing.Point(71, 25);
            this.pic_star.Name = "pic_star";
            this.pic_star.Size = new System.Drawing.Size(65, 65);
            this.pic_star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_star.TabIndex = 12;
            this.pic_star.TabStop = false;
            this.pic_star.Tag = "Star";
            this.pic_star.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shapes_ClickListener);
            // 
            // bar_pen_w
            // 
            this.bar_pen_w.Location = new System.Drawing.Point(6, 573);
            this.bar_pen_w.Maximum = 5;
            this.bar_pen_w.Minimum = 1;
            this.bar_pen_w.Name = "bar_pen_w";
            this.bar_pen_w.Size = new System.Drawing.Size(130, 45);
            this.bar_pen_w.TabIndex = 11;
            this.bar_pen_w.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.bar_pen_w.Value = 1;
            this.bar_pen_w.Scroll += new System.EventHandler(this.bar_pen_w_Scroll);
            // 
            // btn_color
            // 
            this.btn_color.AutoSize = true;
            this.btn_color.BackColor = System.Drawing.Color.Black;
            this.btn_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_color.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_color.Location = new System.Drawing.Point(92, 546);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(32, 22);
            this.btn_color.TabIndex = 10;
            this.btn_color.Text = "PC";
            this.btn_color.Click += new System.EventHandler(this.palitra_ClickListener);
            // 
            // btn_bgcolor
            // 
            this.btn_bgcolor.AutoSize = true;
            this.btn_bgcolor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_bgcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btn_bgcolor.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btn_bgcolor.Location = new System.Drawing.Point(12, 546);
            this.btn_bgcolor.Name = "btn_bgcolor";
            this.btn_bgcolor.Size = new System.Drawing.Size(33, 22);
            this.btn_bgcolor.TabIndex = 7;
            this.btn_bgcolor.Text = "BG";
            this.btn_bgcolor.Click += new System.EventHandler(this.palitra_ClickListener);
            // 
            // pic_circle
            // 
            this.pic_circle.BackColor = System.Drawing.Color.Transparent;
            this.pic_circle.Image = global::TaskSix_Paint.Properties.Resources.ic_circle;
            this.pic_circle.Location = new System.Drawing.Point(0, 25);
            this.pic_circle.Name = "pic_circle";
            this.pic_circle.Size = new System.Drawing.Size(65, 65);
            this.pic_circle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_circle.TabIndex = 2;
            this.pic_circle.TabStop = false;
            this.pic_circle.Tag = "Circle";
            this.pic_circle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shapes_ClickListener);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(1184, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(200, 632);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1370, 661);
            this.ControlBox = false;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moveShapesListener);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawShapeListener);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_polygon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_star)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar_pen_w)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_circle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pic_circle;
        private System.Windows.Forms.Label btn_bgcolor;
        private System.Windows.Forms.Label btn_color;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCounter;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.TrackBar bar_pen_w;
        private System.Windows.Forms.PictureBox pic_star;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_polygon;
        private System.Windows.Forms.Button btn_group;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
    }
}

