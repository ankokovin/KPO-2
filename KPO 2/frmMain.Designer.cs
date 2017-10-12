namespace KPO_2
{
    partial class frmMain
    {
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.эффект11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PenButton = new System.Windows.Forms.ToolStripButton();
            this.PenWidthComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.ChangeColorButton = new System.Windows.Forms.ToolStripButton();
            this.StarButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.ElipseButton = new System.Windows.Forms.ToolStripButton();
            this.EraserButton = new System.Windows.Forms.ToolStripButton();
            this.ScaleUpButton = new System.Windows.Forms.ToolStripButton();
            this.ScaleDownButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(121, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.эффект1ToolStripMenuItem,
            this.эффект2ToolStripMenuItem,
            this.эффект3ToolStripMenuItem,
            this.эффект4ToolStripMenuItem,
            this.эффект5ToolStripMenuItem,
            this.эффект6ToolStripMenuItem,
            this.эффект7ToolStripMenuItem,
            this.эффект8ToolStripMenuItem,
            this.эффект9ToolStripMenuItem,
            this.эффект10ToolStripMenuItem,
            this.эффект11ToolStripMenuItem});
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            // 
            // эффект1ToolStripMenuItem
            // 
            this.эффект1ToolStripMenuItem.Name = "эффект1ToolStripMenuItem";
            this.эффект1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект1ToolStripMenuItem.Text = "Эффект 1";
            // 
            // эффект2ToolStripMenuItem
            // 
            this.эффект2ToolStripMenuItem.Name = "эффект2ToolStripMenuItem";
            this.эффект2ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект2ToolStripMenuItem.Text = "Эффект 2";
            // 
            // эффект3ToolStripMenuItem
            // 
            this.эффект3ToolStripMenuItem.Name = "эффект3ToolStripMenuItem";
            this.эффект3ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект3ToolStripMenuItem.Text = "Эффект 3";
            // 
            // эффект4ToolStripMenuItem
            // 
            this.эффект4ToolStripMenuItem.Name = "эффект4ToolStripMenuItem";
            this.эффект4ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект4ToolStripMenuItem.Text = "Эффект 4";
            // 
            // эффект5ToolStripMenuItem
            // 
            this.эффект5ToolStripMenuItem.Name = "эффект5ToolStripMenuItem";
            this.эффект5ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект5ToolStripMenuItem.Text = "Эффект 5";
            // 
            // эффект6ToolStripMenuItem
            // 
            this.эффект6ToolStripMenuItem.Name = "эффект6ToolStripMenuItem";
            this.эффект6ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект6ToolStripMenuItem.Text = "Эффект 6";
            // 
            // эффект7ToolStripMenuItem
            // 
            this.эффект7ToolStripMenuItem.Name = "эффект7ToolStripMenuItem";
            this.эффект7ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект7ToolStripMenuItem.Text = "Эффект 7";
            // 
            // эффект8ToolStripMenuItem
            // 
            this.эффект8ToolStripMenuItem.Name = "эффект8ToolStripMenuItem";
            this.эффект8ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект8ToolStripMenuItem.Text = "Эффект 8";
            // 
            // эффект9ToolStripMenuItem
            // 
            this.эффект9ToolStripMenuItem.Name = "эффект9ToolStripMenuItem";
            this.эффект9ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект9ToolStripMenuItem.Text = "Эффект 9";
            // 
            // эффект10ToolStripMenuItem
            // 
            this.эффект10ToolStripMenuItem.Name = "эффект10ToolStripMenuItem";
            this.эффект10ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект10ToolStripMenuItem.Text = "Эффект 10";
            // 
            // эффект11ToolStripMenuItem
            // 
            this.эффект11ToolStripMenuItem.Name = "эффект11ToolStripMenuItem";
            this.эффект11ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.эффект11ToolStripMenuItem.Text = "Эффект 11";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenButton,
            this.PenWidthComboBox,
            this.ChangeColorButton,
            this.StarButton,
            this.LineButton,
            this.ElipseButton,
            this.EraserButton,
            this.ScaleUpButton,
            this.ScaleDownButton});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(350, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PenButton
            // 
            this.PenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PenButton.Image = ((System.Drawing.Image)(resources.GetObject("PenButton.Image")));
            this.PenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PenButton.Name = "PenButton";
            this.PenButton.Size = new System.Drawing.Size(23, 22);
            this.PenButton.Text = "Перо";
            this.PenButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // PenWidthComboBox
            // 
            this.PenWidthComboBox.Name = "PenWidthComboBox";
            this.PenWidthComboBox.Size = new System.Drawing.Size(121, 25);
            this.PenWidthComboBox.Text = "Толщина";
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangeColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ChangeColorButton.Image")));
            this.ChangeColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(23, 22);
            this.ChangeColorButton.Text = "Поменять цвет пера";
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // StarButton
            // 
            this.StarButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StarButton.Image = ((System.Drawing.Image)(resources.GetObject("StarButton.Image")));
            this.StarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StarButton.Name = "StarButton";
            this.StarButton.Size = new System.Drawing.Size(23, 22);
            this.StarButton.Text = "Звезда";
            this.StarButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = ((System.Drawing.Image)(resources.GetObject("LineButton.Image")));
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(23, 22);
            this.LineButton.Text = "Линия";
            this.LineButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // ElipseButton
            // 
            this.ElipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ElipseButton.Image = ((System.Drawing.Image)(resources.GetObject("ElipseButton.Image")));
            this.ElipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ElipseButton.Name = "ElipseButton";
            this.ElipseButton.Size = new System.Drawing.Size(23, 22);
            this.ElipseButton.Text = "Эллипс";
            this.ElipseButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // EraserButton
            // 
            this.EraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserButton.Image = ((System.Drawing.Image)(resources.GetObject("EraserButton.Image")));
            this.EraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(23, 22);
            this.EraserButton.Text = "Ластик";
            this.EraserButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // ScaleUpButton
            // 
            this.ScaleUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScaleUpButton.Image = ((System.Drawing.Image)(resources.GetObject("ScaleUpButton.Image")));
            this.ScaleUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScaleUpButton.Name = "ScaleUpButton";
            this.ScaleUpButton.Size = new System.Drawing.Size(23, 22);
            this.ScaleUpButton.Text = "Масштаб+";
            this.ScaleUpButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ScaleUpButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // ScaleDownButton
            // 
            this.ScaleDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ScaleDownButton.Image = ((System.Drawing.Image)(resources.GetObject("ScaleDownButton.Image")));
            this.ScaleDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScaleDownButton.Name = "ScaleDownButton";
            this.ScaleDownButton.Size = new System.Drawing.Size(23, 22);
            this.ScaleDownButton.Text = "Масштаб-";
            this.ScaleDownButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 51);
            this.panel1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 303);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "My Paint";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект10ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem эффект11ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PenButton;
        private System.Windows.Forms.ToolStripComboBox PenWidthComboBox;
        private System.Windows.Forms.ToolStripButton ChangeColorButton;
        private System.Windows.Forms.ToolStripButton StarButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton ElipseButton;
        private System.Windows.Forms.ToolStripButton EraserButton;
        private System.Windows.Forms.ToolStripButton ScaleUpButton;
        private System.Windows.Forms.ToolStripButton ScaleDownButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

