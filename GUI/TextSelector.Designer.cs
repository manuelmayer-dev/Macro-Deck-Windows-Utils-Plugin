
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class TextSelector
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
        this.components = new System.ComponentModel.Container();
        this.textBox = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.btnAddVariable = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.variablesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.SuspendLayout();
        // 
        // textBox
        // 
        this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.textBox.Cursor = System.Windows.Forms.Cursors.Hand;
        this.textBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.textBox.Icon = null;
        this.textBox.Location = new System.Drawing.Point(19, 56);
        this.textBox.MaxCharacters = 32767;
        this.textBox.Multiline = true;
        this.textBox.Name = "textBox";
        this.textBox.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.textBox.PasswordChar = false;
        this.textBox.PlaceHolderColor = System.Drawing.Color.Gray;
        this.textBox.PlaceHolderText = "Type text here";
        this.textBox.ReadOnly = false;
        this.textBox.SelectionStart = 0;
        this.textBox.Size = new System.Drawing.Size(675, 123);
        this.textBox.TabIndex = 0;
        this.textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // btnAddVariable
        // 
        this.btnAddVariable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
        this.btnAddVariable.BorderRadius = 8;
        this.btnAddVariable.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAddVariable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnAddVariable.ForeColor = System.Drawing.Color.White;
        this.btnAddVariable.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(184)))));
        this.btnAddVariable.Icon = null;
        this.btnAddVariable.Location = new System.Drawing.Point(556, 185);
        this.btnAddVariable.Name = "btnAddVariable";
        this.btnAddVariable.Progress = 0;
        this.btnAddVariable.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnAddVariable.Size = new System.Drawing.Size(140, 30);
        this.btnAddVariable.TabIndex = 1;
        this.btnAddVariable.Text = "Add variable";
        this.btnAddVariable.UseVisualStyleBackColor = true;
        this.btnAddVariable.Click += new System.EventHandler(this.BtnAddVariable_Click);
        // 
        // variablesContextMenu
        // 
        this.variablesContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
        this.variablesContextMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.variablesContextMenu.Name = "variablesContextMenu";
        this.variablesContextMenu.ShowImageMargin = false;
        this.variablesContextMenu.Size = new System.Drawing.Size(36, 4);
        // 
        // TextSelector
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.btnAddVariable);
        this.Controls.Add(this.textBox);
        this.Name = "TextSelector";
        this.ResumeLayout(false);

    }

    #endregion

    private RoundedTextBox textBox;
    private ButtonPrimary btnAddVariable;
    private System.Windows.Forms.ContextMenuStrip variablesContextMenu;
}
