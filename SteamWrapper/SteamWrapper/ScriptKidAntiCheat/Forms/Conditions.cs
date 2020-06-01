using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat.Forms
{
	// Token: 0x02000016 RID: 22
	public partial class Conditions : Form
	{
		// Token: 0x06000057 RID: 87 RVA: 0x00006585 File Offset: 0x00004785
		public Conditions()
		{
			this.InitializeComponent();
			Analytics.TrackEvent("Conditions", "Shown", "", 0);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000065A8 File Offset: 0x000047A8
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!this.acceptedTerms)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000065B8 File Offset: 0x000047B8
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				Analytics.TrackEvent("Conditions", "AcceptedTerms", "", 0);
				this.acceptedTerms = true;
				base.Close();
				return;
			}
			this.checkBox1.ForeColor = Color.Red;
			MessageBox.Show("You must accept the terms and conditions if you want to use this software.", "Terms & Conditions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		// Token: 0x040000F5 RID: 245
		public bool acceptedTerms;
	}
}
