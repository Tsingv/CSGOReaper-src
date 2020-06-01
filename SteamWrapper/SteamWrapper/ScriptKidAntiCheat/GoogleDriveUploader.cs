using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using ScriptKidAntiCheat.Utils;

namespace ScriptKidAntiCheat
{
	// Token: 0x02000007 RID: 7
	internal class GoogleDriveUploader
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002704 File Offset: 0x00000904
		public GoogleDriveUploader()
		{
			if ((this.refreshToken == "" || GoogleDriveUploader.secrets.ClientId == "" || GoogleDriveUploader.secrets.ClientSecret == "") && Program.Debug.ShowDebugMessages)
			{
				MessageBox.Show("Google drive uploading is disabled - you need to create ClientId and ClientSecret in Google Developer Console. Check my GoogleDriveUploader class for more info.", "Developer helper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002780 File Offset: 0x00000980
		public void UploadFile(FileInfo ReplayFile)
		{
			if (this.refreshToken == "" || GoogleDriveUploader.secrets.ClientId == "" || GoogleDriveUploader.secrets.ClientSecret == "")
			{
				return;
			}
			UserCredential httpClientInitializer = this.AuthorizeWithRefreshToken(this.refreshToken);
			string path = this.ZipDirectory(ReplayFile);
			if (!File.Exists(path))
			{
				return;
			}
			DriveService driveService = new DriveService(new BaseClientService.Initializer
			{
				HttpClientInitializer = httpClientInitializer,
				ApplicationName = "PUBG REPLAY UPLOADER"
			});
			File file = new File
			{
				Name = ReplayFile.Name + ".zip",
				MimeType = "application/zip, application/octet-stream, application/x-zip-compressed, multipart/x-zip"
			};
			FilesResource.CreateMediaUpload createMediaUpload;
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				createMediaUpload = driveService.Files.Create(file, fileStream, "application/zip");
				createMediaUpload.Fields = "id";
				createMediaUpload.Upload();
			}
			File responseBody = createMediaUpload.ResponseBody;
			if (Program.Debug.ShowDebugMessages)
			{
				if (responseBody.Id.Length > 0)
				{
					MessageBox.Show("Upload complete", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					MessageBox.Show("Upload failed", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else if (responseBody.Id.Length > 0)
			{
				Analytics.TrackEvent("Replays", "UploadSuccess", "", 0);
			}
			else
			{
				Analytics.TrackEvent("Replays", "UploadFail", "", 0);
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002918 File Offset: 0x00000B18
		public UserCredential generateNewToken()
		{
			if (Directory.Exists("token.json"))
			{
				Directory.Delete("token.json", true);
			}
			return GoogleWebAuthorizationBroker.AuthorizeAsync(new GoogleAuthorizationCodeFlow.Initializer
			{
				ClientSecrets = GoogleDriveUploader.secrets
			}, GoogleDriveUploader.Scopes, "user", CancellationToken.None, new FileDataStore("token.json", true), null).Result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002971 File Offset: 0x00000B71
		private UserCredential AuthorizeWithRefreshToken(string token)
		{
			return new UserCredential(new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
			{
				ClientSecrets = GoogleDriveUploader.secrets
			}), "user", new TokenResponse
			{
				RefreshToken = token
			});
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000029A0 File Offset: 0x00000BA0
		private string ZipDirectory(FileInfo ReplayFile)
		{
			string text = Path.GetTempPath() + ReplayFile.Name + ".zip";
			string text2 = Path.GetTempPath() + ReplayFile.Name;
			string text3 = ReplayFile.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(ReplayFile.FullName) + ".log";
			Directory.CreateDirectory(text2);
			if (File.Exists(text3))
			{
				FileInfo fileInfo = new FileInfo(text3);
				fileInfo.MoveTo(text2 + "\\" + fileInfo.Name);
			}
			ReplayFile.MoveTo(text2 + "\\" + ReplayFile.Name);
			if (!File.Exists(text) && Directory.Exists(text2) && File.Exists(text2 + "\\" + ReplayFile.Name))
			{
				ZipFile.CreateFromDirectory(text2, text);
			}
			return text;
		}

		// Token: 0x04000093 RID: 147
		private static string[] Scopes = new string[]
		{
			DriveService.Scope.DriveFile
		};

		// Token: 0x04000094 RID: 148
		private static readonly ClientSecrets secrets = new ClientSecrets
		{
			ClientId = "REMOVED",
			ClientSecret = "REMOVED"
		};

		// Token: 0x04000095 RID: 149
		public string refreshToken = "REMOVED";
	}
}
