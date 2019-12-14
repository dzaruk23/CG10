namespace lab10
{
    partial class Form1
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
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.triangle = new System.Windows.Forms.Button();
            this.rectangle = new System.Windows.Forms.Button();
            this.triangle_rgb = new System.Windows.Forms.Button();
            this.rand_fig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(273, 12);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(497, 370);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            // 
            // triangle
            // 
            this.triangle.Location = new System.Drawing.Point(35, 36);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(111, 34);
            this.triangle.TabIndex = 1;
            this.triangle.Text = "Треугольник";
            this.triangle.UseVisualStyleBackColor = true;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // rectangle
            // 
            this.rectangle.Location = new System.Drawing.Point(35, 96);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(111, 38);
            this.rectangle.TabIndex = 2;
            this.rectangle.Text = "Четырехугольник";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // triangle_rgb
            // 
            this.triangle_rgb.Location = new System.Drawing.Point(35, 158);
            this.triangle_rgb.Name = "triangle_rgb";
            this.triangle_rgb.Size = new System.Drawing.Size(111, 38);
            this.triangle_rgb.TabIndex = 3;
            this.triangle_rgb.Text = "Треугольик 2";
            this.triangle_rgb.UseVisualStyleBackColor = true;
            this.triangle_rgb.Click += new System.EventHandler(this.triangle_rgb_Click);
            // 
            // rand_fig
            // 
            this.rand_fig.Location = new System.Drawing.Point(35, 223);
            this.rand_fig.Name = "rand_fig";
            this.rand_fig.Size = new System.Drawing.Size(111, 36);
            this.rand_fig.TabIndex = 4;
            this.rand_fig.Text = "Рандом";
            this.rand_fig.UseVisualStyleBackColor = true;
            this.rand_fig.Click += new System.EventHandler(this.rand_fig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Чайник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rand_fig);
            this.Controls.Add(this.triangle_rgb);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.triangle);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Button triangle;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button triangle_rgb;
        private System.Windows.Forms.Button rand_fig;
        private System.Windows.Forms.Button button1;
    }
}

