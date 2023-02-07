namespace PollutionMap
{
    partial class Autentificare
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
            this.dGVHarti = new System.Windows.Forms.DataGridView();
            this.dGVMasurare = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHarti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMasurare)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVHarti
            // 
            this.dGVHarti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVHarti.Location = new System.Drawing.Point(12, 55);
            this.dGVHarti.Name = "dGVHarti";
            this.dGVHarti.Size = new System.Drawing.Size(350, 313);
            this.dGVHarti.TabIndex = 0;
            // 
            // dGVMasurare
            // 
            this.dGVMasurare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMasurare.Location = new System.Drawing.Point(406, 66);
            this.dGVMasurare.Name = "dGVMasurare";
            this.dGVMasurare.Size = new System.Drawing.Size(640, 302);
            this.dGVMasurare.TabIndex = 1;
            // 
            // Autentificare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PollutionMap.Properties.Resources.back6;
            this.ClientSize = new System.Drawing.Size(1071, 563);
            this.Controls.Add(this.dGVMasurare);
            this.Controls.Add(this.dGVHarti);
            this.Name = "Autentificare";
            this.Text = "Autentificare";
            ((System.ComponentModel.ISupportInitialize)(this.dGVHarti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMasurare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVHarti;
        private System.Windows.Forms.DataGridView dGVMasurare;
    }
}

