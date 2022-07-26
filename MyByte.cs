using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToBits
{
	internal class MyByte
	{
		public static string GetByte(byte[] b)
		{
			string[] s = new string[b.Length];
			for (int i = 0; i < b.Length; i++)
			{
				s[i] = GetByte(b[i]);
			}
			Array.Reverse(s);
			return string.Join(" ", s);
		}
		public static string GetByte(byte b)
		{
			return FormatString(Convert.ToInt32(Convert.ToString(b, 2)).ToString("D8"));
		}
		/// <summary>
		/// Просто вставляет пробелы в <paramref name="fused"/>
		/// </summary>
		/// <param name="fused">Слитная строка типа "11111111"</param>
		/// <returns>Возвращает разъедененную строку типа "1 1 1 1 1 1 1 1"</returns>
		static string FormatString(string fused)
		{
			string newString = "";
			for (int i = 1; i < fused.Length * 2 - 2; i += 2)
			{
				if (i == 1)
				{
					newString = fused.Insert(i, " ");
					continue;
				}
				newString = newString.Insert(i, " ");

			}
			return newString;
		}
	}
}
