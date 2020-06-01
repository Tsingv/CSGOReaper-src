namespace ScriptKidAntiCheat.Forms
{
	// Token: 0x02000016 RID: 22
	public partial class Conditions : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00006618 File Offset: 0x00004818
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006638 File Offset: 0x00004838
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ScriptKidAntiCheat.Forms.Conditions));
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.richTextBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 27.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.richTextBox1.ForeColor = global::System.Drawing.Color.Black;
			this.richTextBox1.Location = new global::System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new global::System.Drawing.Size(414, 265);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = componentResourceManager.GetString("richTextBox1.Text");
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Location = new global::System.Drawing.Point(12, 335);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(414, 49);
			this.button1.TabIndex = 1;
			this.button1.Text = "START CSGO REAPER";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.checkBox1.Location = new global::System.Drawing.Point(12, 292);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(420, 28);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "I ACCEPT THESE TERMS AND CONDITIONS";
			this.checkBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(438, 396);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.richTextBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Conditions";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Terms & Conditions";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040000F6 RID: 246
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.CheckBox checkBox1;
	}
}
