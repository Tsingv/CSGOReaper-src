using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000039 RID: 57
	internal static class Analytics
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00007B3C File Offset: 0x00005D3C
		static Analytics()
		{
			string userName = Environment.UserName;
			byte[] bytes = new UTF8Encoding().GetBytes(userName);
			Analytics.cid = BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes)).Replace("-", string.Empty).ToLower();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00007BA4 File Offset: 0x00005DA4
		public static async void TrackEvent(string Category, string Action, string label = "", int value = 0)
		{
			if (!Program.Debug.SkipAnalyticsTracking)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>
				{
					{
						"v",
						"1"
					},
					{
						"tid",
						Analytics.UAID
					},
					{
						"cid",
						Analytics.cid.ToString()
					},
					{
						"t",
						"event"
					},
					{
						"ec",
						Category
					},
					{
						"ea",
						Action
					}
				};
				if (label != "" && value != 0)
				{
					dictionary.Add("el", label);
					dictionary.Add("ev", value.ToString());
				}
				FormUrlEncodedContent content = new FormUrlEncodedContent(dictionary);
				await(await Analytics.client.PostAsync("http://www.google-analytics.com/collect", content)).Content.ReadAsStringAsync();
			}
		}

		// Token: 0x04000206 RID: 518
		private static readonly HttpClient client = new HttpClient();

		// Token: 0x04000207 RID: 519
		private static string UAID = "UA-148967474-3";

		// Token: 0x04000208 RID: 520
		private static string cid;
	}
}
