using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace ScriptKidAntiCheat.Utils
{
	// Token: 0x02000005 RID: 5
	internal static class Analytics
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000021EC File Offset: 0x000003EC
		static Analytics()
		{
			string userName = Environment.UserName;
			byte[] bytes = new UTF8Encoding().GetBytes(userName);
			Analytics.cid = BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes)).Replace("-", string.Empty).ToLower();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002254 File Offset: 0x00000454
		public static async void TrackEvent(string Category, string Action, string label = "", int value = 0)
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

		// Token: 0x04000004 RID: 4
		private static readonly HttpClient client = new HttpClient();

		// Token: 0x04000005 RID: 5
		private static string UAID = "UA-148967474-3";

		// Token: 0x04000006 RID: 6
		private static string cid;
	}
}
