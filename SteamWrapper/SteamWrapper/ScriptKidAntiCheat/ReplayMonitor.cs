using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000008 RID: 8
	internal class ReplayMonitor
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002AA0 File Offset: 0x00000CA0
		public ReplayMonitor()
		{
			if (Directory.Exists(Helper.getPathToCSGO()) && !Program.Debug.DisableGoogleDriveUpload)
			{
				this.watcher = new FileSystemWatcher();
				this.watcher.Path = Helper.getPathToCSGO();
				this.watcher.NotifyFilter = NotifyFilters.FileName;
				this.watcher.Filter = "*.dem";
				this.watcher.Created += this.OnNewReplayCreation;
				this.watcher.EnableRaisingEvents = true;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B30 File Offset: 0x00000D30
		private void OnNewReplayCreation(object source, FileSystemEventArgs e)
		{
			if (File.Exists(e.FullPath))
			{
				FileInfo file = new FileInfo(e.FullPath);
				Analytics.TrackEvent("Replays", "Created", "", 0);
				while (Helper.IsFileLocked(file))
				{
					Thread.Sleep(5000);
				}
				Task.Run(delegate()
				{
					this.GoogleDriveUploader.UploadFile(file);
				});
			}
		}

		// Token: 0x04000096 RID: 150
		private FileSystemWatcher watcher;

		// Token: 0x04000097 RID: 151
		public GoogleDriveUploader GoogleDriveUploader = new GoogleDriveUploader();
	}
}
