
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI
{
    partial class StartApplicationActionConfigView
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
            this.checkRunAsAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.method = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
            this.checkSyncButtonState = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.path.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.path.Icon = null;
            this.path.Location = new System.Drawing.Point(216, 145);
            this.path.MaxCharacters = 32767;
            this.path.Multiline = false;
            this.path.Name = "path";
            this.path.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.path.PasswordChar = false;
            this.path.PlaceHolderColor = System.Drawing.Color.Gray;
            this.path.PlaceHolderText = "";
            this.path.ReadOnly = false;
            this.path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.path.SelectionStart = 0;
            this.path.Size = new System.Drawing.Size(486, 29);
            this.path.TabIndex = 1;
            this.path.TabStop = false;
            this.path.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblPath
            // 
            this.lblPath.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.Location = new System.Drawing.Point(97, 145);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(83, 29);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BorderRadius = 8;
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));
            this.btnBrowse.Icon = null;
            this.btnBrowse.Location = new System.Drawing.Point(708, 145);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Progress = 0;
            this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
            this.btnBrowse.Size = new System.Drawing.Size(38, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.UseWindowsAccentColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblArguments
            // 
            this.lblArguments.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblArguments.Location = new System.Drawing.Point(97, 180);
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
            this.arguments.Location = new System.Drawing.Point(216, 180);
            this.arguments.MaxCharacters = 32767;
            this.arguments.Multiline = false;
            this.arguments.Name = "arguments";
            this.arguments.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.arguments.PasswordChar = false;
            this.arguments.PlaceHolderColor = System.Drawing.Color.Gray;
            this.arguments.PlaceHolderText = "";
            this.arguments.ReadOnly = false;
            this.arguments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.arguments.SelectionStart = 0;
            this.arguments.Size = new System.Drawing.Size(486, 29);
            this.arguments.TabIndex = 4;
            this.arguments.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // checkRunAsAdmin
            // 
            this.checkRunAsAdmin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkRunAsAdmin.Location = new System.Drawing.Point(497, 215);
            this.checkRunAsAdmin.Name = "checkRunAsAdmin";
            this.checkRunAsAdmin.Size = new System.Drawing.Size(249, 29);
            this.checkRunAsAdmin.TabIndex = 8;
            this.checkRunAsAdmin.Text = "As Administrator";
            this.checkRunAsAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(97, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Method:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // method
            // 
            this.method.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.method.Cursor = System.Windows.Forms.Cursors.Hand;
            this.method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.method.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.method.Icon = null;
            this.method.Location = new System.Drawing.Point(216, 214);
            this.method.Name = "method";
            this.method.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.method.SelectedIndex = -1;
            this.method.SelectedItem = null;
            this.method.Size = new System.Drawing.Size(159, 28);
            this.method.TabIndex = 10;
            // 
            // checkSyncButtonState
            // 
            this.checkSyncButtonState.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkSyncButtonState.Location = new System.Drawing.Point(97, 250);
            this.checkSyncButtonState.Name = "checkSyncButtonState";
            this.checkSyncButtonState.Size = new System.Drawing.Size(249, 29);
            this.checkSyncButtonState.TabIndex = 11;
            this.checkSyncButtonState.Text = "Sync button state";
            this.checkSyncButtonState.UseVisualStyleBackColor = true;
            // 
            // StartApplicationActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.path);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.checkSyncButtonState);
            this.Controls.Add(this.lblArguments);
            this.Controls.Add(this.method);
            this.Controls.Add(this.arguments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkRunAsAdmin);
            this.Name = "StartApplicationActionConfigView";
            this.Load += new System.EventHandler(this.StartApplicationActionConfigView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedTextBox path;
        private System.Windows.Forms.Label lblPath;
        private ButtonPrimary btnBrowse;
        private System.Windows.Forms.Label lblArguments;
        private RoundedTextBox arguments;
        private System.Windows.Forms.CheckBox checkRunAsAdmin;
        private System.Windows.Forms.Label label1;
        private RoundedComboBox method;
        private System.Windows.Forms.CheckBox checkSyncButtonState;
    }
}
