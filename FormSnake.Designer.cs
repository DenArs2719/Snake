namespace Snake
{
    partial class FormSnake
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxSnakeBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnakeBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSnakeBoard
            // 
            this.pictureBoxSnakeBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSnakeBoard.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSnakeBoard.Name = "pictureBoxSnakeBoard";
            this.pictureBoxSnakeBoard.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxSnakeBoard.TabIndex = 0;
            this.pictureBoxSnakeBoard.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxSnakeBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSnake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSnakeBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSnakeBoard;
    }
}

