using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000C RID: 12
	public partial class FakeCheatForm : Form
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00002F00 File Offset: 0x00001100
		public FakeCheatForm()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			this.title.Location = base.Location;
			this.title.Width = base.Width;
			this.title.Height = 30;
			this.title.BackColor = Color.Black;
			base.Controls.Add(this.title);
			this.title.BringToFront();
			this.close.Text = "Close";
			this.close.Font = new Font("Impact", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.close.Location = new Point(base.Width - 50, base.Location.Y + 3);
			this.close.ForeColor = Color.White;
			this.close.BackColor = Color.Black;
			base.Controls.Add(this.close);
			this.close.BringToFront();
			this.close.MouseEnter += this.Control_MouseEnter;
			this.close.MouseLeave += this.Control_MouseLeave;
			this.close.MouseClick += this.Control_MouseClick;
			this.title.MouseDown += this.Title_MouseDown;
			this.title.MouseUp += this.Title_MouseUp;
			this.title.MouseMove += this.Title_MouseMove;
			this.pictureBox2.BringToFront();
			this.label1.BringToFront();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000030D0 File Offset: 0x000012D0
		private void Control_MouseEnter(object sender, EventArgs e)
		{
			if (sender.Equals(this.close))
			{
				this.close.ForeColor = Color.Red;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000030F0 File Offset: 0x000012F0
		private void Control_MouseLeave(object sender, EventArgs e)
		{
			if (sender.Equals(this.close))
			{
				this.close.ForeColor = Color.White;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003110 File Offset: 0x00001310
		private void Control_MouseClick(object sender, MouseEventArgs e)
		{
			if (sender.Equals(this.close))
			{
				base.Close();
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003126 File Offset: 0x00001326
		private void Title_MouseUp(object sender, MouseEventArgs e)
		{
			this.drag = false;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000312F File Offset: 0x0000132F
		private void Title_MouseDown(object sender, MouseEventArgs e)
		{
			this.startPoint = e.Location;
			this.drag = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003144 File Offset: 0x00001344
		private void Title_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.drag)
			{
				Point p = new Point(e.X, e.Y);
				Point point = base.PointToScreen(p);
				Point location = new Point(point.X - this.startPoint.X, point.Y - this.startPoint.Y);
				base.Location = location;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000031A8 File Offset: 0x000013A8
		private void setCheckBoxColor(object sender, EventArgs e)
		{
			CheckBox checkBox = sender as CheckBox;
			if (checkBox.Checked)
			{
				checkBox.ForeColor = Color.LawnGreen;
				return;
			}
			checkBox.ForeColor = Color.Red;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000031DB File Offset: 0x000013DB
		public void log(string msg)
		{
			Console.WriteLine(msg);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000031E4 File Offset: 0x000013E4
		private void button1_Click(object sender, EventArgs e)
		{
			if (Program.GameProcess != null && Program.GameProcess.Process != null && Program.GameProcess.Process.IsRunning())
			{
				if (!Program.GameData.MatchInfo.IsMatchmaking && !Program.Debug.AllowLocal)
				{
					Analytics.TrackEvent("InjectButton", "NotInMatchmaking", "", 0);
					MessageBox.Show("You need to join a matchmaking game before injecting.", "No match in progress", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			else
			{
				Analytics.TrackEvent("InjectButton", "NotRunningCSGO", "", 0);
				MessageBox.Show("CSGO is not running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x040000A2 RID: 162
		private PictureBox title = new PictureBox();

		// Token: 0x040000A3 RID: 163
		private Label close = new Label();

		// Token: 0x040000A4 RID: 164
		private bool drag;

		// Token: 0x040000A5 RID: 165
		private Point startPoint = new Point(0, 0);
	}
}
