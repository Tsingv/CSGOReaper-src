using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using ScriptKidAntiCheat.Utils;
using ScriptKidAntiCheat.Win32;

namespace ScriptKidAntiCheat.Data
{
	// Token: 0x02000061 RID: 97
	public class GameProcess : U_ThreadedComponent
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000AA15 File Offset: 0x00008C15
		protected override string ThreadName
		{
			get
			{
				return "GameProcess";
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000AA1C File Offset: 0x00008C1C
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000AA24 File Offset: 0x00008C24
		protected override TimeSpan ThreadFrameSleep { get; set; } = new TimeSpan(0, 0, 0, 0, 500);

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000AA2D File Offset: 0x00008C2D
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000AA35 File Offset: 0x00008C35
		public Process Process { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000AA3E File Offset: 0x00008C3E
		// (set) Token: 0x060001BB RID: 443 RVA: 0x0000AA46 File Offset: 0x00008C46
		public Module ModuleClient { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000AA4F File Offset: 0x00008C4F
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000AA57 File Offset: 0x00008C57
		public Module ModuleEngine { get; private set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000AA60 File Offset: 0x00008C60
		// (set) Token: 0x060001BF RID: 447 RVA: 0x0000AA68 File Offset: 0x00008C68
		public Module ModuleServer { get; private set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000AA71 File Offset: 0x00008C71
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000AA79 File Offset: 0x00008C79
		private IntPtr WindowHwnd { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000AA82 File Offset: 0x00008C82
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000AA8A File Offset: 0x00008C8A
		public Rectangle WindowRectangleClient { get; private set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000AA93 File Offset: 0x00008C93
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000AA9B File Offset: 0x00008C9B
		private bool WindowActive { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000AAA4 File Offset: 0x00008CA4
		public bool IsValid
		{
			get
			{
				return this.WindowActive && this.Process != null && this.ModuleClient != null && this.ModuleEngine != null && this.ModuleServer != null;
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000AAD4 File Offset: 0x00008CD4
		public override void Dispose()
		{
			this.InvalidateWindow();
			this.InvalidateModules();
			base.Dispose();
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		protected override void FrameAction()
		{
			if (!this.EnsureProcessAndModules())
			{
				this.InvalidateModules();
			}
			if (!this.EnsureWindow())
			{
				this.InvalidateWindow();
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000AB08 File Offset: 0x00008D08
		private void InvalidateModules()
		{
			Module moduleEngine = this.ModuleEngine;
			if (moduleEngine != null)
			{
				moduleEngine.Dispose();
			}
			this.ModuleEngine = null;
			Module moduleClient = this.ModuleClient;
			if (moduleClient != null)
			{
				moduleClient.Dispose();
			}
			this.ModuleClient = null;
			Process process = this.Process;
			if (process != null)
			{
				process.Dispose();
			}
			this.Process = null;
			Module moduleServer = this.ModuleServer;
			if (moduleServer != null)
			{
				moduleServer.Dispose();
			}
			this.ModuleServer = null;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000AB75 File Offset: 0x00008D75
		private void InvalidateWindow()
		{
			this.WindowHwnd = IntPtr.Zero;
			this.WindowRectangleClient = Rectangle.Empty;
			this.WindowActive = false;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000AB94 File Offset: 0x00008D94
		private bool EnsureProcessAndModules()
		{
			if (this.Process == null)
			{
				this.Process = Process.GetProcessesByName("csgo").FirstOrDefault<Process>();
			}
			if (this.Process == null || !this.Process.IsRunning())
			{
				return false;
			}
			if (this.Process.IsRunning() && !GameConsole.cfgIsReady)
			{
				this.Process.Kill();
				Program.GameConsole.checkIfCfgIsReady();
			}
			if (this.ModuleClient == null)
			{
				this.ModuleClient = this.Process.GetModule("client_panorama.dll");
			}
			if (this.ModuleClient == null)
			{
				return false;
			}
			if (this.ModuleEngine == null)
			{
				this.ModuleEngine = this.Process.GetModule("engine.dll");
			}
			if (this.ModuleEngine == null)
			{
				return false;
			}
			if (this.ModuleServer == null)
			{
				this.ModuleServer = this.Process.GetModule("server.dll");
			}
			return this.ModuleServer != null;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000AC78 File Offset: 0x00008E78
		private bool EnsureWindow()
		{
			this.WindowHwnd = User32.FindWindow(null, "Counter-Strike: Global Offensive");
			if (this.WindowHwnd == IntPtr.Zero)
			{
				return false;
			}
			this.WindowRectangleClient = Helper.GetClientRectangle(this.WindowHwnd);
			if (this.WindowRectangleClient.Width <= 0 || this.WindowRectangleClient.Height <= 0)
			{
				return false;
			}
			this.WindowActive = (this.WindowHwnd == User32.GetForegroundWindow());
			return this.WindowActive;
		}

		// Token: 0x04000330 RID: 816
		private const string NAME_PROCESS = "csgo";

		// Token: 0x04000331 RID: 817
		private const string NAME_MODULE_CLIENT = "client_panorama.dll";

		// Token: 0x04000332 RID: 818
		private const string NAME_MODULE_ENGINE = "engine.dll";

		// Token: 0x04000333 RID: 819
		private const string NAME_MODULE_SERVER = "server.dll";

		// Token: 0x04000334 RID: 820
		private const string NAME_WINDOW = "Counter-Strike: Global Offensive";
	}
}
