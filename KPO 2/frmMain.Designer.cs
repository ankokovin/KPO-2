﻿namespace KPO_2
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.NoToolButton = new System.Windows.Forms.ToolStripButton();
            this.PenButton = new System.Windows.Forms.ToolStripButton();
            this.StarButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripButton();
            this.EraserButton = new System.Windows.Forms.ToolStripButton();
            this.ScaleUpButton = new System.Windows.Forms.ToolStripButton();
            this.ScaleDownButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.domainPenWidth = new System.Windows.Forms.DomainUpDown();
            this.pbPenWidthImage = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ChangeColorButton = new System.Windows.Forms.ToolStripButton();
            this.CancelButton = new System.Windows.Forms.ToolStripButton();
            this.ReturnButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OneFileSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.domainStarCount = new System.Windows.Forms.DomainUpDown();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваНаправоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуВнизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.упорядочитьЗначкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPenWidthImage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.окноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(169, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.файлToolStripMenuItem.DropDownOpened += new System.EventHandler(this.файлToolStripMenuItem_DropDownOpened);
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
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
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
            this.эффект1ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект1ToolStripMenuItem.Text = "Эффект 1";
            this.эффект1ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект2ToolStripMenuItem
            // 
            this.эффект2ToolStripMenuItem.Name = "эффект2ToolStripMenuItem";
            this.эффект2ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект2ToolStripMenuItem.Text = "Эффект 2";
            this.эффект2ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект3ToolStripMenuItem
            // 
            this.эффект3ToolStripMenuItem.Name = "эффект3ToolStripMenuItem";
            this.эффект3ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект3ToolStripMenuItem.Text = "Эффект 3";
            this.эффект3ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект4ToolStripMenuItem
            // 
            this.эффект4ToolStripMenuItem.Name = "эффект4ToolStripMenuItem";
            this.эффект4ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект4ToolStripMenuItem.Text = "Эффект 4";
            this.эффект4ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект5ToolStripMenuItem
            // 
            this.эффект5ToolStripMenuItem.Name = "эффект5ToolStripMenuItem";
            this.эффект5ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект5ToolStripMenuItem.Text = "Эффект 5";
            this.эффект5ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект6ToolStripMenuItem
            // 
            this.эффект6ToolStripMenuItem.Name = "эффект6ToolStripMenuItem";
            this.эффект6ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект6ToolStripMenuItem.Text = "Эффект 6";
            this.эффект6ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект7ToolStripMenuItem
            // 
            this.эффект7ToolStripMenuItem.Name = "эффект7ToolStripMenuItem";
            this.эффект7ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект7ToolStripMenuItem.Text = "Эффект 7";
            this.эффект7ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект8ToolStripMenuItem
            // 
            this.эффект8ToolStripMenuItem.Name = "эффект8ToolStripMenuItem";
            this.эффект8ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект8ToolStripMenuItem.Text = "Поворот против часовой";
            this.эффект8ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект9ToolStripMenuItem
            // 
            this.эффект9ToolStripMenuItem.Name = "эффект9ToolStripMenuItem";
            this.эффект9ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект9ToolStripMenuItem.Text = "Поворот по часовой";
            this.эффект9ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект10ToolStripMenuItem
            // 
            this.эффект10ToolStripMenuItem.Name = "эффект10ToolStripMenuItem";
            this.эффект10ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект10ToolStripMenuItem.Text = "Отражение по вертикали";
            this.эффект10ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // эффект11ToolStripMenuItem
            // 
            this.эффект11ToolStripMenuItem.Name = "эффект11ToolStripMenuItem";
            this.эффект11ToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.эффект11ToolStripMenuItem.Text = "Отражениие по горизонтали";
            this.эффект11ToolStripMenuItem.Click += new System.EventHandler(this.FunctionButtonClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoToolButton,
            this.PenButton,
            this.StarButton,
            this.LineButton,
            this.EllipseButton,
            this.EraserButton,
            this.ScaleUpButton,
            this.ScaleDownButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(4, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(196, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // NoToolButton
            // 
            this.NoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NoToolButton.Image = ((System.Drawing.Image)(resources.GetObject("NoToolButton.Image")));
            this.NoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NoToolButton.Name = "NoToolButton";
            this.NoToolButton.Size = new System.Drawing.Size(23, 22);
            this.NoToolButton.Text = "Без инструмента";
            this.NoToolButton.Click += new System.EventHandler(this.Button_Click);
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
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(23, 22);
            this.EllipseButton.Text = "Эллипс";
            this.EllipseButton.Click += new System.EventHandler(this.Button_Click);
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
            this.panel1.Controls.Add(this.domainStarCount);
            this.panel1.Controls.Add(this.domainPenWidth);
            this.panel1.Controls.Add(this.pbPenWidthImage);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.toolStrip);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 78);
            this.panel1.TabIndex = 2;
            // 
            // domainPenWidth
            // 
            this.domainPenWidth.Location = new System.Drawing.Point(194, 49);
            this.domainPenWidth.Name = "domainPenWidth";
            this.domainPenWidth.ReadOnly = true;
            this.domainPenWidth.Size = new System.Drawing.Size(47, 20);
            this.domainPenWidth.TabIndex = 4;
            this.domainPenWidth.Text = "domainPenWidth";
            this.domainPenWidth.TextChanged += new System.EventHandler(this.domainPenWidth_TextChanged);
            // 
            // pbPenWidthImage
            // 
            this.pbPenWidthImage.Location = new System.Drawing.Point(88, 49);
            this.pbPenWidthImage.Name = "pbPenWidthImage";
            this.pbPenWidthImage.Size = new System.Drawing.Size(100, 25);
            this.pbPenWidthImage.TabIndex = 3;
            this.pbPenWidthImage.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeColorButton,
            this.CancelButton,
            this.ReturnButton});
            this.toolStrip1.Location = new System.Drawing.Point(4, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            // CancelButton
            // 
            this.CancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(23, 22);
            this.CancelButton.Text = "Назад";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReturnButton.Image = ((System.Drawing.Image)(resources.GetObject("ReturnButton.Image")));
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(23, 22);
            this.ReturnButton.Text = "Вперёд";
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = " .bmp | *.bmp";
            this.openFileDialog1.InitialDirectory = "Изображения";
            // 
            // OneFileSaveDialog
            // 
            this.OneFileSaveDialog.Filter = ".bmp | *.bmp";
            this.OneFileSaveDialog.InitialDirectory = "Изображения";
            // 
            // domainStarCount
            // 
            this.domainStarCount.Items.Add("2");
            this.domainStarCount.Items.Add("3");
            this.domainStarCount.Items.Add("4");
            this.domainStarCount.Items.Add("5");
            this.domainStarCount.Items.Add("6");
            this.domainStarCount.Items.Add("7");
            this.domainStarCount.Items.Add("8");
            this.domainStarCount.Items.Add("9");
            this.domainStarCount.Items.Add("10");
            this.domainStarCount.Items.Add("12");
            this.domainStarCount.Items.Add("15");
            this.domainStarCount.Items.Add("18");
            this.domainStarCount.Items.Add("20");
            this.domainStarCount.Location = new System.Drawing.Point(204, 23);
            this.domainStarCount.Name = "domainStarCount";
            this.domainStarCount.ReadOnly = true;
            this.domainStarCount.Size = new System.Drawing.Size(37, 20);
            this.domainStarCount.TabIndex = 5;
            this.domainStarCount.Text = "domainUpDown1";
            this.domainStarCount.SelectedItemChanged += new System.EventHandler(this.domainStarCount_SelectedItemChanged);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.слеваНаправоToolStripMenuItem,
            this.сверхуВнизToolStripMenuItem,
            this.упорядочитьЗначкиToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.каскадомToolStripMenuItem.Text = "Каскадом";
            this.каскадомToolStripMenuItem.Click += new System.EventHandler(this.каскадомToolStripMenuItem_Click);
            // 
            // слеваНаправоToolStripMenuItem
            // 
            this.слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            this.слеваНаправоToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.слеваНаправоToolStripMenuItem.Text = "Слева направо";
            this.слеваНаправоToolStripMenuItem.Click += new System.EventHandler(this.слеваНаправоToolStripMenuItem_Click);
            // 
            // сверхуВнизToolStripMenuItem
            // 
            this.сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            this.сверхуВнизToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.сверхуВнизToolStripMenuItem.Text = "Сверху вниз";
            this.сверхуВнизToolStripMenuItem.Click += new System.EventHandler(this.сверхуВнизToolStripMenuItem_Click);
            // 
            // упорядочитьЗначкиToolStripMenuItem
            // 
            this.упорядочитьЗначкиToolStripMenuItem.Name = "упорядочитьЗначкиToolStripMenuItem";
            this.упорядочитьЗначкиToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.упорядочитьЗначкиToolStripMenuItem.Text = "Упорядочить значки";
            this.упорядочитьЗначкиToolStripMenuItem.Click += new System.EventHandler(this.упорядочитьЗначкиToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 478);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "My Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPenWidthImage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        /// <summary>
        /// Главное меню
        /// </summary>
        private System.Windows.Forms.MenuStrip menuStrip1;
        /// <summary>
        /// Выпадающее меню основных действий с файлами
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        /// <summary>
        /// Пункт выбора создания нового изображения
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        /// <summary>
        /// Пункт выбора открытия уже существующего изображения
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        /// <summary>
        /// Пункт выбора сохранения текущего изображения с уточнением
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        /// <summary>
        /// Пукнт выбора сохранения текущего изображения
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        /// <summary>
        /// Пукнт выбора выхода из программы
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        /// <summary>
        /// Пункт выбора используемого эффекта
        /// </summary>
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
        /// <summary>
        /// Панель основных инструментов
        /// </summary>
        private System.Windows.Forms.ToolStrip toolStrip;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.Pen"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton PenButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.Star"/>         
        /// </summary>
        private System.Windows.Forms.ToolStripButton StarButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.Line"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton LineButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.Elipse"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton EllipseButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.Eraser"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton EraserButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.ScaleUp"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton ScaleUpButton;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.ScaleDown"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton ScaleDownButton;
        /// <summary>
        /// Верхняя панель окна
        /// </summary>
        private System.Windows.Forms.Panel panel1;
        /// <summary>
        /// Диалог изменения цвета
        /// </summary>
        private System.Windows.Forms.ColorDialog colorDialog1;
        /// <summary>
        /// Кнопка инструмента <see cref="Tools.None"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton NoToolButton;
        /// <summary>
        /// Панель дополнительных настроек
        /// </summary>
        private System.Windows.Forms.ToolStrip toolStrip1;
        /// <summary>
        /// Кнопка вызова <see cref="colorDialog1"/>
        /// </summary>
        private System.Windows.Forms.ToolStripButton ChangeColorButton;
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        private System.Windows.Forms.ToolStripButton CancelButton;
        /// <summary>
        /// Кнопка возвращения после отмены
        /// </summary>
        private System.Windows.Forms.ToolStripButton ReturnButton;
        /// <summary>
        /// Пикчурбокс для отображения текущей ширины
        /// </summary>
        private System.Windows.Forms.PictureBox pbPenWidthImage;
        /// <summary>
        /// Домейн для изменения ширины
        /// </summary>
        private System.Windows.Forms.DomainUpDown domainPenWidth;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog OneFileSaveDialog;
        private System.Windows.Forms.DomainUpDown domainStarCount;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem упорядочитьЗначкиToolStripMenuItem;
    }
}

