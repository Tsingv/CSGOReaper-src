using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000067 RID: 103
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0000B514 File Offset: 0x00009714
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000B528 File Offset: 0x00009728
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000B590 File Offset: 0x00009790
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000B5C4 File Offset: 0x000097C4
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000B648 File Offset: 0x00009848
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullName;
			if (resourceNames.TryGetValue(name, out fullName))
			{
				return AssemblyLoader.LoadStream(fullName);
			}
			return null;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000B668 File Offset: 0x00009868
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000B690 File Offset: 0x00009890
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000B750 File Offset: 0x00009950
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				obj = AssemblyLoader.nullCacheLock;
				lock (obj)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0000B830 File Offset: 0x00009A30
		// Note: this type is marked as 'beforefieldinit'.
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("axinterop.wmplib", "costura.axinterop.wmplib.dll.compressed");
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.assemblyNames.Add("gma.system.mousekeyhook", "costura.gma.system.mousekeyhook.dll.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis.auth", "costura.google.apis.auth.dll.compressed");
			AssemblyLoader.symbolNames.Add("google.apis.auth", "costura.google.apis.auth.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis.auth.platformservices", "costura.google.apis.auth.platformservices.dll.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis.core", "costura.google.apis.core.dll.compressed");
			AssemblyLoader.symbolNames.Add("google.apis.core", "costura.google.apis.core.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis", "costura.google.apis.dll.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis.drive.v3", "costura.google.apis.drive.v3.dll.compressed");
			AssemblyLoader.symbolNames.Add("google.apis.drive.v3", "costura.google.apis.drive.v3.pdb.compressed");
			AssemblyLoader.symbolNames.Add("google.apis", "costura.google.apis.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("google.apis.platformservices", "costura.google.apis.platformservices.dll.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("sharpdx", "costura.sharpdx.dll.compressed");
			AssemblyLoader.assemblyNames.Add("sharpdx.mathematics", "costura.sharpdx.mathematics.dll.compressed");
			AssemblyLoader.symbolNames.Add("sharpdx.mathematics", "costura.sharpdx.mathematics.pdb.compressed");
			AssemblyLoader.symbolNames.Add("sharpdx", "costura.sharpdx.pdb.compressed");
		}

		// Token: 0x060001EA RID: 490 RVA: 0x0000B9CD File Offset: 0x00009BCD
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x04000353 RID: 851
		private static object nullCacheLock = new object();

		// Token: 0x04000354 RID: 852
		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x04000355 RID: 853
		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x04000356 RID: 854
		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x04000357 RID: 855
		private static int isAttached;
	}
}
