namespace ScriptKidAntiCheat.Forms
{
	// Token: 0x02000017 RID: 23
	public partial class Hidden : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005D RID: 93 RVA: 0x00006900 File Offset: 0x00004B00
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006920 File Offset: 0x00004B20
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(0, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Location = new global::System.Drawing.Point(-99999, -99999);
			base.Name = "Hidden";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Hidden";
			base.ResumeLayout(false);
		}

		// Token: 0x040000FA RID: 250
		private global::System.ComponentModel.IContainer components;
	}
}
