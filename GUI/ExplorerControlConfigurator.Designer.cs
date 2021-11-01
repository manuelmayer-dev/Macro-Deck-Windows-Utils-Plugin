
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI
{
    partial class ExplorerControlConfigurator
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBack = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioForward = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioHome = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioRefresh = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Control the explorer or browser";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(315, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Action";
            // 
            // radioBack
            // 
            this.radioBack.AutoSize = true;
            this.radioBack.Checked = true;
            this.radioBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioBack.Location = new System.Drawing.Point(172, 124);
            this.radioBack.Name = "radioBack";
            this.radioBack.Size = new System.Drawing.Size(59, 23);
            this.radioBack.TabIndex = 6;
            this.radioBack.TabStop = true;
            this.radioBack.Text = "Back";
            this.radioBack.UseVisualStyleBackColor = true;
            // 
            // radioForward
            // 
            this.radioForward.AutoSize = true;
            this.radioForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioForward.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioForward.Location = new System.Drawing.Point(257, 124);
            this.radioForward.Name = "radioForward";
            this.radioForward.Size = new System.Drawing.Size(85, 23);
            this.radioForward.TabIndex = 7;
            this.radioForward.Text = "Forward";
            this.radioForward.UseVisualStyleBackColor = true;
            // 
            // radioHome
            // 
            this.radioHome.AutoSize = true;
            this.radioHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioHome.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioHome.Location = new System.Drawing.Point(368, 124);
            this.radioHome.Name = "radioHome";
            this.radioHome.Size = new System.Drawing.Size(69, 23);
            this.radioHome.TabIndex = 8;
            this.radioHome.Text = "Home";
            this.radioHome.UseVisualStyleBackColor = true;
            // 
            // radioRefresh
            // 
            this.radioRefresh.AutoSize = true;
            this.radioRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioRefresh.Location = new System.Drawing.Point(463, 124);
            this.radioRefresh.Name = "radioRefresh";
            this.radioRefresh.Size = new System.Drawing.Size(80, 23);
            this.radioRefresh.TabIndex = 9;
            this.radioRefresh.Text = "Refresh";
            this.radioRefresh.UseVisualStyleBackColor = true;
            // 
            // ExplorerControlConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioRefresh);
            this.Controls.Add(this.radioHome);
            this.Controls.Add(this.radioForward);
            this.Controls.Add(this.radioBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "ExplorerControlConfigurator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TabRadioButton radioBack;
        private TabRadioButton radioForward;
        private TabRadioButton radioHome;
        private TabRadioButton radioRefresh;
    }
}
