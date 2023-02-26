/// <summary>
/// Miksowanie obrazów
/// Alorytm pozwala na połączenie dwóch obrazów o takiej samej rozdzielczości i wybranie współczynnika mieszania
/// 2022/2023 Sem.5 Jakub Hoś gr.2
/// v1.0
/// </summary>
using System.Runtime.InteropServices;

namespace JaProj
{
    partial class MainForm
    {
        //[DllImport(@"C:\Users\Jakub\Desktop\JaProj\x64\Release\JaAsm.dll")]
        [DllImport(@"..\..\..\..\x64\Release\JaAsm.dll")]
        //"C:\Users\Jakub\Desktop\JaProj\bin\x64\Release\netcoreapp3.1"
        static extern int mixAsm(int pixelA, int pixelB, int u);
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.lavelImageA = new System.Windows.Forms.Label();
            this.urlButtonA = new System.Windows.Forms.Button();
            this.lavelImageB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioCpp = new System.Windows.Forms.RadioButton();
            this.radioAsm = new System.Windows.Forms.RadioButton();
            this.urlButtonB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfThreadsLabel = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxA = new System.Windows.Forms.PictureBox();
            this.pictureBoxB = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.runButton = new System.Windows.Forms.Button();
            this.errLabel = new System.Windows.Forms.Label();
            this.deleteA = new System.Windows.Forms.Button();
            this.deleteB = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.deleteResult = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(603, 90);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Mieszanie obrazów";
            // 
            // lavelImageA
            // 
            this.lavelImageA.AutoSize = true;
            this.lavelImageA.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lavelImageA.Location = new System.Drawing.Point(23, 99);
            this.lavelImageA.Name = "lavelImageA";
            this.lavelImageA.Size = new System.Drawing.Size(80, 23);
            this.lavelImageA.TabIndex = 1;
            this.lavelImageA.Text = "Obraz A:";
            // 
            // urlButtonA
            // 
            this.urlButtonA.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.urlButtonA.Location = new System.Drawing.Point(185, 210);
            this.urlButtonA.Name = "urlButtonA";
            this.urlButtonA.Size = new System.Drawing.Size(170, 37);
            this.urlButtonA.TabIndex = 2;
            this.urlButtonA.Text = "Wybierz obraz A";
            this.urlButtonA.UseVisualStyleBackColor = true;
            this.urlButtonA.Click += new System.EventHandler(this.urlButtonA_Click);
            // 
            // lavelImageB
            // 
            this.lavelImageB.AutoSize = true;
            this.lavelImageB.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lavelImageB.Location = new System.Drawing.Point(23, 346);
            this.lavelImageB.Name = "lavelImageB";
            this.lavelImageB.Size = new System.Drawing.Size(78, 23);
            this.lavelImageB.TabIndex = 3;
            this.lavelImageB.Text = "Obraz B:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(692, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sposób wykonania:";
            // 
            // radioCpp
            // 
            this.radioCpp.AutoSize = true;
            this.radioCpp.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioCpp.Location = new System.Drawing.Point(692, 60);
            this.radioCpp.Name = "radioCpp";
            this.radioCpp.Size = new System.Drawing.Size(51, 27);
            this.radioCpp.TabIndex = 6;
            this.radioCpp.TabStop = true;
            this.radioCpp.Text = "C#";
            this.radioCpp.UseVisualStyleBackColor = true;
            // 
            // radioAsm
            // 
            this.radioAsm.AutoSize = true;
            this.radioAsm.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioAsm.Location = new System.Drawing.Point(692, 93);
            this.radioAsm.Name = "radioAsm";
            this.radioAsm.Size = new System.Drawing.Size(97, 27);
            this.radioAsm.TabIndex = 7;
            this.radioAsm.TabStop = true;
            this.radioAsm.Text = "Asembler";
            this.radioAsm.UseVisualStyleBackColor = true;
            // 
            // urlButtonB
            // 
            this.urlButtonB.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.urlButtonB.Location = new System.Drawing.Point(185, 455);
            this.urlButtonB.Name = "urlButtonB";
            this.urlButtonB.Size = new System.Drawing.Size(170, 37);
            this.urlButtonB.TabIndex = 8;
            this.urlButtonB.Text = "Wybierz obraz B";
            this.urlButtonB.UseVisualStyleBackColor = true;
            this.urlButtonB.Click += new System.EventHandler(this.urlButtonB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(692, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Liczba wątków:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(692, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Współczynnik mieszania u:";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(692, 169);
            this.hScrollBar1.Maximum = 64;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(547, 31);
            this.hScrollBar1.TabIndex = 12;
            this.hScrollBar1.Value = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(710, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "1";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(1199, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "64";
            // 
            // numberOfThreadsLabel
            // 
            this.numberOfThreadsLabel.AutoSize = true;
            this.numberOfThreadsLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberOfThreadsLabel.Location = new System.Drawing.Point(809, 136);
            this.numberOfThreadsLabel.Name = "numberOfThreadsLabel";
            this.numberOfThreadsLabel.Size = new System.Drawing.Size(17, 23);
            this.numberOfThreadsLabel.TabIndex = 15;
            this.numberOfThreadsLabel.Text = "1";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.LargeChange = 1;
            this.hScrollBar2.Location = new System.Drawing.Point(692, 274);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(547, 31);
            this.hScrollBar2.TabIndex = 16;
            this.hScrollBar2.Value = 50;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(710, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1207, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "1";
            // 
            // uLabel
            // 
            this.uLabel.AutoSize = true;
            this.uLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uLabel.Location = new System.Drawing.Point(892, 240);
            this.uLabel.Name = "uLabel";
            this.uLabel.Size = new System.Drawing.Size(34, 23);
            this.uLabel.TabIndex = 19;
            this.uLabel.Text = "0,5";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(775, 344);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBoxA
            // 
            this.pictureBoxA.Location = new System.Drawing.Point(76, 125);
            this.pictureBoxA.Name = "pictureBoxA";
            this.pictureBoxA.Size = new System.Drawing.Size(400, 200);
            this.pictureBoxA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxA.TabIndex = 21;
            this.pictureBoxA.TabStop = false;
            this.pictureBoxA.Visible = false;
            // 
            // pictureBoxB
            // 
            this.pictureBoxB.Location = new System.Drawing.Point(76, 372);
            this.pictureBoxB.Name = "pictureBoxB";
            this.pictureBoxB.Size = new System.Drawing.Size(400, 200);
            this.pictureBoxB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxB.TabIndex = 22;
            this.pictureBoxB.TabStop = false;
            this.pictureBoxB.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.runButton.Location = new System.Drawing.Point(762, 432);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(421, 68);
            this.runButton.TabIndex = 23;
            this.runButton.Text = "MIESZAJ OBRAZY";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // errLabel
            // 
            this.errLabel.AutoSize = true;
            this.errLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.errLabel.ForeColor = System.Drawing.Color.Red;
            this.errLabel.Location = new System.Drawing.Point(12, 604);
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(699, 38);
            this.errLabel.TabIndex = 24;
            this.errLabel.Text = "Proszę wybrać obrazy o takiej samej rozdzielczości";
            this.errLabel.Visible = false;
            // 
            // deleteA
            // 
            this.deleteA.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteA.Location = new System.Drawing.Point(482, 125);
            this.deleteA.Name = "deleteA";
            this.deleteA.Size = new System.Drawing.Size(48, 25);
            this.deleteA.TabIndex = 25;
            this.deleteA.Text = "Usuń";
            this.deleteA.UseVisualStyleBackColor = true;
            this.deleteA.Visible = false;
            this.deleteA.Click += new System.EventHandler(this.deleteA_Click);
            // 
            // deleteB
            // 
            this.deleteB.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteB.Location = new System.Drawing.Point(482, 372);
            this.deleteB.Name = "deleteB";
            this.deleteB.Size = new System.Drawing.Size(48, 25);
            this.deleteB.TabIndex = 26;
            this.deleteB.Text = "Usuń";
            this.deleteB.UseVisualStyleBackColor = true;
            this.deleteB.Visible = false;
            this.deleteB.Click += new System.EventHandler(this.deleteB_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(892, 647);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(185, 23);
            this.timeLabel.TabIndex = 27;
            this.timeLabel.Text = "Czas wykonania: 0,0 sec";
            this.timeLabel.Visible = false;
            // 
            // deleteResult
            // 
            this.deleteResult.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteResult.Location = new System.Drawing.Point(1181, 344);
            this.deleteResult.Name = "deleteResult";
            this.deleteResult.Size = new System.Drawing.Size(48, 25);
            this.deleteResult.TabIndex = 28;
            this.deleteResult.Text = "Usuń";
            this.deleteResult.UseVisualStyleBackColor = true;
            this.deleteResult.Visible = false;
            this.deleteResult.Click += new System.EventHandler(this.deleteResult_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1059, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 37);
            this.button1.TabIndex = 29;
            this.button1.Text = "Testuj czasy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteResult);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.deleteB);
            this.Controls.Add(this.deleteA);
            this.Controls.Add(this.errLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.urlButtonA);
            this.Controls.Add(this.pictureBoxA);
            this.Controls.Add(this.uLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.numberOfThreadsLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlButtonB);
            this.Controls.Add(this.radioAsm);
            this.Controls.Add(this.radioCpp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lavelImageB);
            this.Controls.Add(this.lavelImageA);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBoxB);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Mieszanie obrazów";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label lavelImageA;
        private System.Windows.Forms.Button urlButtonA;
        private System.Windows.Forms.Label lavelImageB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioCpp;
        private System.Windows.Forms.RadioButton radioAsm;
        private System.Windows.Forms.Button urlButtonB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label numberOfThreadsLabel;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label uLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxA;
        private System.Windows.Forms.PictureBox pictureBoxB;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label errLabel;
        private System.Windows.Forms.Button deleteB;
        private System.Windows.Forms.Button deleteA;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button deleteResult;
        private System.Windows.Forms.Button button1;
    }
}

