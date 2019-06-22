namespace Dijital_Günlük
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnKaydol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(329, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 19);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(184, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "© 2016 Erciyes University";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Font = new System.Drawing.Font("Meiryo", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(181, 145);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 22);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LightBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("Meiryo", 13F, System.Drawing.FontStyle.Bold);
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(181, 190);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(131, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.WordWrap = false;
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.Transparent;
            this.btnGiris.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGiris.FlatAppearance.BorderSize = 0;
            this.btnGiris.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGiris.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiris.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGiris.Location = new System.Drawing.Point(84, 235);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(209, 53);
            this.btnGiris.TabIndex = 7;
            this.btnGiris.Text = "Giriş Yap ";
            this.btnGiris.UseCompatibleTextRendering = true;
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            this.btnGiris.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.btnGiris.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.btnGiris.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(81, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kayıt Ol";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnKaydol
            // 
            this.btnKaydol.BackColor = System.Drawing.Color.Transparent;
            this.btnKaydol.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnKaydol.FlatAppearance.BorderSize = 0;
            this.btnKaydol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnKaydol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnKaydol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydol.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnKaydol.ForeColor = System.Drawing.Color.White;
            this.btnKaydol.Location = new System.Drawing.Point(84, 234);
            this.btnKaydol.Name = "btnKaydol";
            this.btnKaydol.Size = new System.Drawing.Size(209, 53);
            this.btnKaydol.TabIndex = 10;
            this.btnKaydol.Text = "Kaydol ";
            this.btnKaydol.UseCompatibleTextRendering = true;
            this.btnKaydol.UseVisualStyleBackColor = true;
            this.btnKaydol.Visible = false;
            this.btnKaydol.Click += new System.EventHandler(this.btnKaydol_Click);
            this.btnKaydol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnKaydol_MouseDown);
            this.btnKaydol.MouseLeave += new System.EventHandler(this.btnKaydol_MouseLeave);
            this.btnKaydol.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnKaydol_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(360, 341);
            this.Controls.Add(this.btnKaydol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydol;
    }
}

