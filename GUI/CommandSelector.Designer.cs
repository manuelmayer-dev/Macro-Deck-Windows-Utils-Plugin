
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI;

partial class CommandSelector
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
        this.workingDirectory = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.lblWorkingDirectory = new System.Windows.Forms.Label();
        this.lblCommand = new System.Windows.Forms.Label();
        this.command = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.btnBrowse = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
        this.checkSaveVariable = new System.Windows.Forms.CheckBox();
        this.variableName = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
        this.variableType = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
        this.SuspendLayout();
        // 
        // workingDirectory
        // 
        this.workingDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.workingDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
        this.workingDirectory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.workingDirectory.Icon = null;
        this.workingDirectory.Location = new System.Drawing.Point(183, 144);
        this.workingDirectory.Multiline = false;
        this.workingDirectory.Name = "workingDirectory";
        this.workingDirectory.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.workingDirectory.PasswordChar = false;
        this.workingDirectory.PlaceHolderColor = System.Drawing.Color.Gray;
        this.workingDirectory.PlaceHolderText = "(Optional) Select or drag and drop";
        this.workingDirectory.ReadOnly = false;
        this.workingDirectory.SelectionStart = 0;
        this.workingDirectory.Size = new System.Drawing.Size(469, 29);
        this.workingDirectory.TabIndex = 8;
        this.workingDirectory.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        // 
        // lblWorkingDirectory
        // 
        this.lblWorkingDirectory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblWorkingDirectory.Location = new System.Drawing.Point(3, 144);
        this.lblWorkingDirectory.Name = "lblWorkingDirectory";
        this.lblWorkingDirectory.Size = new System.Drawing.Size(174, 29);
        this.lblWorkingDirectory.TabIndex = 7;
        this.lblWorkingDirectory.Text = "Working directory:";
        this.lblWorkingDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblWorkingDirectory.Click += new System.EventHandler(this.lblWorkingDirectory_Click);
        // 
        // lblCommand
        // 
        this.lblCommand.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblCommand.Location = new System.Drawing.Point(3, 63);
        this.lblCommand.Name = "lblCommand";
        this.lblCommand.Size = new System.Drawing.Size(174, 75);
        this.lblCommand.TabIndex = 6;
        this.lblCommand.Text = "Command:";
        this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // command
        // 
        this.command.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.command.Cursor = System.Windows.Forms.Cursors.Hand;
        this.command.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.command.Icon = null;
        this.command.Location = new System.Drawing.Point(183, 63);
        this.command.Multiline = true;
        this.command.Name = "command";
        this.command.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.command.PasswordChar = false;
        this.command.PlaceHolderColor = System.Drawing.Color.Gray;
        this.command.PlaceHolderText = "";
        this.command.ReadOnly = false;
        this.command.SelectionStart = 0;
        this.command.Size = new System.Drawing.Size(513, 75);
        this.command.TabIndex = 5;
        this.command.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
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
        this.btnBrowse.Location = new System.Drawing.Point(658, 144);
        this.btnBrowse.Name = "btnBrowse";
        this.btnBrowse.Progress = 0;
        this.btnBrowse.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(94)))));
        this.btnBrowse.Size = new System.Drawing.Size(38, 29);
        this.btnBrowse.TabIndex = 9;
        this.btnBrowse.Text = "...";
        this.btnBrowse.UseVisualStyleBackColor = true;
        this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
        // 
        // checkSaveVariable
        // 
        this.checkSaveVariable.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.checkSaveVariable.Location = new System.Drawing.Point(3, 180);
        this.checkSaveVariable.Name = "checkSaveVariable";
        this.checkSaveVariable.Size = new System.Drawing.Size(174, 49);
        this.checkSaveVariable.TabIndex = 10;
        this.checkSaveVariable.Text = "Save output to variable";
        this.checkSaveVariable.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.checkSaveVariable.UseVisualStyleBackColor = true;
        this.checkSaveVariable.CheckedChanged += new System.EventHandler(this.CheckSaveVariable_CheckedChanged);
        // 
        // variableName
        // 
        this.variableName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.variableName.Cursor = System.Windows.Forms.Cursors.Hand;
        this.variableName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
        this.variableName.Icon = null;
        this.variableName.Location = new System.Drawing.Point(183, 179);
        this.variableName.Multiline = false;
        this.variableName.Name = "variableName";
        this.variableName.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
        this.variableName.PasswordChar = false;
        this.variableName.PlaceHolderColor = System.Drawing.Color.Gray;
        this.variableName.PlaceHolderText = "Variable name";
        this.variableName.ReadOnly = false;
        this.variableName.SelectionStart = 0;
        this.variableName.Size = new System.Drawing.Size(386, 29);
        this.variableName.TabIndex = 11;
        this.variableName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
        this.variableName.Visible = false;
        // 
        // variableType
        // 
        this.variableType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
        this.variableType.Cursor = System.Windows.Forms.Cursors.Hand;
        this.variableType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.variableType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.variableType.Icon = null;
        this.variableType.Location = new System.Drawing.Point(575, 180);
        this.variableType.Name = "variableType";
        this.variableType.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
        this.variableType.SelectedIndex = -1;
        this.variableType.SelectedItem = null;
        this.variableType.Size = new System.Drawing.Size(121, 28);
        this.variableType.TabIndex = 12;
        this.variableType.Visible = false;
        // 
        // CommandSelector
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.variableType);
        this.Controls.Add(this.variableName);
        this.Controls.Add(this.checkSaveVariable);
        this.Controls.Add(this.btnBrowse);
        this.Controls.Add(this.workingDirectory);
        this.Controls.Add(this.lblWorkingDirectory);
        this.Controls.Add(this.lblCommand);
        this.Controls.Add(this.command);
        this.Name = "CommandSelector";
        this.ResumeLayout(false);

    }

    #endregion

    private MacroDeck.GUI.CustomControls.RoundedTextBox workingDirectory;
    private System.Windows.Forms.Label lblWorkingDirectory;
    private System.Windows.Forms.Label lblCommand;
    private MacroDeck.GUI.CustomControls.RoundedTextBox command;
    private MacroDeck.GUI.CustomControls.ButtonPrimary btnBrowse;
    private System.Windows.Forms.CheckBox checkSaveVariable;
    private MacroDeck.GUI.CustomControls.RoundedTextBox variableName;
    private RoundedComboBox variableType;
}
