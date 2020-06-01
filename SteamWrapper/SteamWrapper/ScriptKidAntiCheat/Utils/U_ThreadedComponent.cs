using System;
using System.Threading;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x0200004A RID: 74
	public abstract class U_ThreadedComponent : IDisposable
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000124 RID: 292 RVA: 0x0000920F File Offset: 0x0000740F
		protected virtual string ThreadName
		{
			get
			{
				return "U_ThreadedComponent";
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00009216 File Offset: 0x00007416
		// (set) Token: 0x06000126 RID: 294 RVA: 0x0000921E File Offset: 0x0000741E
		protected virtual TimeSpan ThreadTimeout { get; set; } = new TimeSpan(0, 0, 0, 3);

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00009227 File Offset: 0x00007427
		// (set) Token: 0x06000128 RID: 296 RVA: 0x0000922F File Offset: 0x0000742F
		protected virtual TimeSpan ThreadFrameSleep { get; set; } = new TimeSpan(0, 0, 0, 0, 1);

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00009238 File Offset: 0x00007438
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00009240 File Offset: 0x00007440
		private Thread Thread { get; set; }

		// Token: 0x0600012B RID: 299 RVA: 0x0000924C File Offset: 0x0000744C
		protected U_ThreadedComponent()
		{
			this.Thread = new Thread(new ThreadStart(this.ThreadStart))
			{
				Name = this.ThreadName
			};
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000092A1 File Offset: 0x000074A1
		public virtual void Dispose()
		{
			this.Thread.Interrupt();
			if (!this.Thread.Join(this.ThreadTimeout))
			{
				this.Thread.Abort();
			}
			this.Thread = null;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000092D3 File Offset: 0x000074D3
		public void Start()
		{
			this.Thread.Start();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000092E0 File Offset: 0x000074E0
		private void ThreadStart()
		{
			try
			{
				for (;;)
				{
					this.FrameAction();
					Thread.Sleep(this.ThreadFrameSleep);
				}
			}
			catch (ThreadInterruptedException)
			{
			}
		}

		// Token: 0x0600012F RID: 303
		protected abstract void FrameAction();
	}
}
