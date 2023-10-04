
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class IconPackSelector
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
        this.iconPacks = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
        this.btnOk = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.SuspendLayout();
        // 
        // iconPacks
        // 
        this.iconPacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.iconPacks.Cursor = System.Windows.Forms.Cursors.Hand;
        this.iconPacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.iconPacks.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.iconPacks.Icon = null;
        this.iconPacks.Location = new System.Drawing.Point(9, 20);
        this.iconPacks.Name = "iconPacks";
        this.iconPacks.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        this.iconPacks.SelectedIndex = -1;
        this.iconPacks.SelectedItem = null;
        this.iconPacks.Size = new System.Drawing.Size(308, 30);
        this.iconPacks.TabIndex = 2;
        // 
        // btnOk
        // 
        this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnOk.BorderRadius = 8;
        this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnOk.ForeColor = System.Drawing.Color.White;
        this.btnOk.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));
        this.btnOk.Icon = null;
        this.btnOk.Location = new System.Drawing.Point(271, 65);
        this.btnOk.Name = "btnOk";
        this.btnOk.Progress = 0;
        this.btnOk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnOk.Size = new System.Drawing.Size(75, 25);
        this.btnOk.TabIndex = 3;
        this.btnOk.Text = "Ok";
        this.btnOk.UseVisualStyleBackColor = true;
        this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
        // 
        // IconPackSelector
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(363, 108);
        this.Controls.Add(this.btnOk);
        this.Controls.Add(this.iconPacks);
        this.Name = "IconPackSelector";
        this.Text = "IconPackSelector";
        this.Controls.SetChildIndex(this.iconPacks, 0);
        this.Controls.SetChildIndex(this.btnOk, 0);
        this.ResumeLayout(false);

    }

    #endregion

    private RoundedComboBox iconPacks;
    private ButtonPrimary btnOk;
}