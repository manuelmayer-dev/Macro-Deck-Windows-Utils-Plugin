
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.GUI;

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
        this.lblAction = new System.Windows.Forms.Label();
        this.radioBack = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioForward = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioHome = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.radioRefresh = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
        this.SuspendLayout();
        // 
        // lblAction
        // 
        this.lblAction.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblAction.ForeColor = System.Drawing.Color.White;
        this.lblAction.Location = new System.Drawing.Point(185, 85);
        this.lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblAction.Name = "lblAction";
        this.lblAction.Size = new System.Drawing.Size(344, 23);
        this.lblAction.TabIndex = 5;
        this.lblAction.Text = "Action";
        this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // radioBack
        // 
        this.radioBack.Checked = true;
        this.radioBack.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioBack.Location = new System.Drawing.Point(102, 124);
        this.radioBack.Name = "radioBack";
        this.radioBack.Size = new System.Drawing.Size(120, 23);
        this.radioBack.TabIndex = 6;
        this.radioBack.TabStop = true;
        this.radioBack.Text = "Back";
        this.radioBack.UseVisualStyleBackColor = true;
        // 
        // radioForward
        // 
        this.radioForward.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioForward.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioForward.Location = new System.Drawing.Point(232, 124);
        this.radioForward.Name = "radioForward";
        this.radioForward.Size = new System.Drawing.Size(120, 23);
        this.radioForward.TabIndex = 7;
        this.radioForward.Text = "Forward";
        this.radioForward.UseVisualStyleBackColor = true;
        // 
        // radioHome
        // 
        this.radioHome.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioHome.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioHome.Location = new System.Drawing.Point(362, 124);
        this.radioHome.Name = "radioHome";
        this.radioHome.Size = new System.Drawing.Size(120, 23);
        this.radioHome.TabIndex = 8;
        this.radioHome.Text = "Home";
        this.radioHome.UseVisualStyleBackColor = true;
        // 
        // radioRefresh
        // 
        this.radioRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
        this.radioRefresh.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.radioRefresh.Location = new System.Drawing.Point(492, 124);
        this.radioRefresh.Name = "radioRefresh";
        this.radioRefresh.Size = new System.Drawing.Size(120, 23);
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
        this.Controls.Add(this.lblAction);
        this.Name = "ExplorerControlConfigurator";
        this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Label lblAction;
    private TabRadioButton radioBack;
    private TabRadioButton radioForward;
    private TabRadioButton radioHome;
    private TabRadioButton radioRefresh;
}
