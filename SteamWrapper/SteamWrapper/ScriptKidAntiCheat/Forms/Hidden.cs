using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScriptKidAntiCheat.Forms
{
	// Token: 0x02000017 RID: 23
	public partial class Hidden : Form
	{
		// Token: 0x0600005C RID: 92 RVA: 0x000068DD File Offset: 0x00004ADD
		public Hidden()
		{
			this.InitializeComponent();
			base.WindowState = FormWindowState.Minimized;
			base.ShowInTaskbar = false;
			base.WindowState = FormWindowState.Normal;
		}
	}
}
