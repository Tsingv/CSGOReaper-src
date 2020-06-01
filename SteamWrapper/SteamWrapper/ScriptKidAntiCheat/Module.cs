using System;
using System.Diagnostics;

namespace ScriptKidAntiCheat
{
	// Token: 0x0200000B RID: 11
	public class Module : IDisposable
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002EAC File Offset: 0x000010AC
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002EB4 File Offset: 0x000010B4
		public Process Process { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002EBD File Offset: 0x000010BD
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002EC5 File Offset: 0x000010C5
		public ProcessModule ProcessModule { get; private set; }

		// Token: 0x06000027 RID: 39 RVA: 0x00002ECE File Offset: 0x000010CE
		public Module(Process process, ProcessModule processModule)
		{
			this.Process = process;
			this.ProcessModule = processModule;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002EE4 File Offset: 0x000010E4
		public void Dispose()
		{
			this.Process = null;
			this.ProcessModule.Dispose();
			this.ProcessModule = null;
		}
	}
}
