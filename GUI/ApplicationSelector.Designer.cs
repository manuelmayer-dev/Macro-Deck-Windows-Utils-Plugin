
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI
{
    partial class ApplicationSelector
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.path = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblArguments = new System.Windows.Forms.Label();
            this.arguments = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.lblChoose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.path.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.path.Icon = null;
            this.path.Location = new System.Drawing.Point(122, 81);
            this.path.Multiline = false;
            this.path.Name = "path";
            this.path.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.path.PasswordChar = false;
            this.path.PlaceHolderColor = System.Drawing.Color.Gray;
            this.path.PlaceHolderText = "";
            this.path.ReadOnly = false;
            this.path.SelectionStart = 0;
            this.path.Size = new System.Drawing.Size(486, 29);
            this.path.TabIndex = 0;
            this.path.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblPath
            // 
            this.lblPath.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.Location = new System.Drawing.Point(3, 81);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(83, 29);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnBrowse.BorderRadius = 8;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));
            this.btnBrowse.Icon = null;
            this.btnBrowse.Location = new System.Drawing.Point(614, 81);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Progress = 0;
            this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
            this.btnBrowse.Size = new System.Drawing.Size(38, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblArguments
            // 
            this.lblArguments.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblArguments.Location = new System.Drawing.Point(3, 116);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(113, 29);
            this.lblArguments.TabIndex = 3;
            this.lblArguments.Text = "Arguments:";
            this.lblArguments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // arguments
            // 
            this.arguments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.arguments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.arguments.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.arguments.Icon = null;
            this.arguments.Location = new System.Drawing.Point(122, 116);
            this.arguments.Multiline = false;
            this.arguments.Name = "arguments";
            this.arguments.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.arguments.PasswordChar = false;
            this.arguments.PlaceHolderColor = System.Drawing.Color.Gray;
            this.arguments.PlaceHolderText = "";
            this.arguments.ReadOnly = false;
            this.arguments.SelectionStart = 0;
            this.arguments.Size = new System.Drawing.Size(486, 29);
            this.arguments.TabIndex = 4;
            this.arguments.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblChoose
            // 
            this.lblChoose.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblChoose.Location = new System.Drawing.Point(3, 184);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(709, 64);
            this.lblChoose.TabIndex = 7;
            this.lblChoose.Text = "Choose a file or drag and drop it here";
            this.lblChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.arguments);
            this.Controls.Add(this.lblArguments);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.path);
            this.Name = "ApplicationSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedTextBox path;
        private System.Windows.Forms.Label lblPath;
        private ButtonPrimary btnBrowse;
        private System.Windows.Forms.Label lblArguments;
        private RoundedTextBox arguments;
        private System.Windows.Forms.Label lblChoose;
    }
}
