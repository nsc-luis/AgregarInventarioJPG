using Microsoft.Win32;
using System;
using System.Management;

namespace AgregarInventarioJPG
{
	internal class hardwareInfo
	{
		public hardwareInfo()
		{
		}

		/* public string[,] AntivirusInstalled()
		{
			int num = 0;
			int num1 = 0;
			ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntivirusProduct")).Get();
			string[,] item = new string[managementObjectCollections.Count, 3];
			foreach (ManagementObject managementObject in managementObjectCollections)
			{
				num1 = int.Parse(managementObject["productState"].ToString());
				string str = num1.ToString("x");
				if (str.Length < 6)
				{
					str = string.Concat("0", str);
				}
				string str1 = str.Substring(2, 2);
				string str2 = str.Substring(4, 2);
				item[num, 0] = (string)managementObject["displayName"];
				item[num, 1] = str1;
				item[num, 2] = str2;
			}
			return item;
		} */

		public static string GetAccountName()
		{
			string str;
			foreach (ManagementObject managementObject in (new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_UserAccount")).Get())
			{
				try
				{
					str = managementObject.GetPropertyValue("Name").ToString();
					return str;
				}
				catch
				{
				}
			}
			str = "User Account Name: Unknown";
			return str;
		}

		public string GetComputerName()
		{
			ManagementObjectCollection instances = (new ManagementClass("Win32_ComputerSystem")).GetInstances();
			string empty = string.Empty;
			foreach (ManagementObject instance in instances)
			{
				empty = (string)instance["Name"];
			}
			return empty;
		}

		public string GetCPUManufacturer()
		{
			string empty = string.Empty;
			foreach (ManagementObject instance in (new ManagementClass("Win32_Processor")).GetInstances())
			{
				if (empty == string.Empty)
				{
					empty = instance.Properties["Name"].Value.ToString();
				}
			}
			return empty;
		}

		public string GetCSProduct()
		{
			string str;
			foreach (ManagementObject managementObject in (new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystemProduct")).Get())
			{
				try
				{
					str = string.Concat(new string[] { managementObject.GetPropertyValue("Vendor").ToString(), ", ", managementObject.GetPropertyValue("Name").ToString(), ", ", managementObject.GetPropertyValue("Version").ToString() });
					return str;
				}
				catch
				{
				}
			}
			str = "Product: Unknown";
			return str;
		}

		public string GetHDDSerialNo()
		{
			ManagementObjectCollection instances = (new ManagementClass("Win32_LogicalDisk")).GetInstances();
			decimal num = new decimal();
			decimal num1 = new decimal();
			string str = "";
			string str1 = "";
			string str2 = "";
			foreach (ManagementObject instance in instances)
			{
				num = Math.Round(Convert.ToDecimal(instance["Size"]) / new decimal(0x40000000), 2);
				num1 = Math.Round(Convert.ToDecimal(instance["FreeSpace"]) / new decimal(0x40000000), 2);
				str = instance["Name"].ToString();
				str1 = instance["DriveType"].ToString();
				str2 = string.Concat(new object[] { str2, "(", str, " | Total=", num, " | Libre=", num1, ") " });
			}
			return str2;
		}

		public string GetMACAddress()
		{
			ManagementObjectCollection instances = (new ManagementClass("Win32_NetworkAdapterConfiguration")).GetInstances();
			string empty = string.Empty;
			foreach (ManagementObject instance in instances)
			{
				if (empty == string.Empty)
				{
					if ((bool)instance["IPEnabled"])
					{
						empty = instance["MacAddress"].ToString();
					}
				}
				instance.Dispose();
			}
			return empty;
		}

		/* public string GetOfficeVersion()
		{
			string str;
			string str1 = "\\Excel.Application\\CurVer";
			string value = null;
			string str2 = null;
			RegistryKey registryKey = null;
			registryKey = Registry.ClassesRoot.OpenSubKey(str1, false);
			if (registryKey == null)
			{
				str = "Unknown";
			}
			else
			{
				value = (string)registryKey.GetValue(string.Empty);
				value = value.Substring(value.LastIndexOf(".") + 1);
				string str3 = value;
				switch (str3)
				{
					case "7":
					{
						str2 = "Office95";
						break;
					}
					case "8":
					{
						str2 = "Office97";
						break;
					}
					case "9":
					{
						str2 = "Office2000";
						break;
					}
					case "10":
					{
						str2 = "Office2002";
						break;
					}
					case "11":
					{
						str2 = "Office2003";
						break;
					}
					case "12":
					{
						str2 = "Office2007";
						break;
					}
					case "14":
					{
						str2 = "Office2010";
						break;
					}
					case "15":
					{
						str2 = "Office2013";
						break;
					}
					default:
					{
						str2 = (str3 == "16" ? "Office365/2016/2019" : "Unknown");
						break;
					}
				}
				str = str2;
			}
			return str;
		} */

		public string GetOSInformation()
		{
			string str;
			foreach (ManagementObject managementObject in (new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")).Get())
			{
				try
				{
					str = string.Concat(new string[] { ((string)managementObject["Caption"]).Trim(), ", ", (string)managementObject["Version"], ", ", (string)managementObject["OSArchitecture"] });
					return str;
				}
				catch
				{
				}
			}
			str = "BIOS Maker: Unknown";
			return str;
		}

		public string GetPhysicalMemory()
		{
			ManagementScope managementScope = new ManagementScope();
			ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory"))).Get();
			long num = (long)0;
			long num1 = (long)0;
			foreach (ManagementObject managementObject in managementObjectCollections)
			{
				num1 = Convert.ToInt64(managementObject["Capacity"]);
				num += num1;
			}
			num = num / (long)0x400 / (long)0x400;
			return string.Concat(num.ToString(), "MB");
		}

		public static string GetProcessorInformation()
		{
			ManagementObjectCollection instances = (new ManagementClass("win32_processor")).GetInstances();
			string empty = string.Empty;
			foreach (ManagementObject instance in instances)
			{
				string item = (string)instance["Name"];
				item = item.Replace("(TM)", "™").Replace("(tm)", "™").Replace("(R)", "®").Replace("(r)", "®").Replace("(C)", "©").Replace("(c)", "©").Replace("    ", " ").Replace("  ", " ");
				empty = string.Concat(new string[] { item, ", ", (string)instance["Caption"], ", ", (string)instance["SocketDesignation"] });
			}
			return empty;
		}

		public string GetProcessorName()
		{
			ManagementObjectCollection instances = (new ManagementClass("win32_processor")).GetInstances();
			string empty = string.Empty;
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject current = (ManagementObject)enumerator.Current;
					empty = current.Properties["name"].Value.ToString();
				}
			}
			return empty;
		}
	}
}