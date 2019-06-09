namespace VkStickerUploader
{
  partial class Two
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
      this.label2 = new System.Windows.Forms.Label();
      this.btn2Fac = new System.Windows.Forms.Button();
      this.txt2Fac = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(109, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Enter two factor code";
      // 
      // btn2Fac
      // 
      this.btn2Fac.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btn2Fac.Location = new System.Drawing.Point(12, 77);
      this.btn2Fac.Name = "btn2Fac";
      this.btn2Fac.Size = new System.Drawing.Size(260, 32);
      this.btn2Fac.TabIndex = 6;
      this.btn2Fac.Text = "Login";
      this.btn2Fac.UseVisualStyleBackColor = true;
      this.btn2Fac.Click += new System.EventHandler(this.btn2Fac_Click);
      // 
      // txt2Fac
      // 
      this.txt2Fac.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txt2Fac.Location = new System.Drawing.Point(12, 25);
      this.txt2Fac.Name = "txt2Fac";
      this.txt2Fac.PasswordChar = '*';
      this.txt2Fac.Size = new System.Drawing.Size(260, 32);
      this.txt2Fac.TabIndex = 5;
      // 
      // Two
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(283, 119);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btn2Fac);
      this.Controls.Add(this.txt2Fac);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Two";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btn2Fac;
    public System.Windows.Forms.TextBox txt2Fac;
  }
}