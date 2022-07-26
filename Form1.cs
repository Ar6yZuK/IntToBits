using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntToBits
{
	public partial class Form1 : Form
	{
		CheckBox[] bits = new CheckBox[32];
		
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 32; i++)
			{
				bits[i] = new CheckBox() { CheckAlign = ContentAlignment.BottomCenter, AutoSize = true, Text = $"{i}\n" + Math.Pow(2, i).ToString(), Dock = DockStyle.Left, Margin = new Padding(0, 0, 0, 0) };
				panel1.Controls.Add(bits[i]);
				bits[i].CheckedChanged += Form1_CheckedChanged;
			}
			Array.Reverse(bits);
			numericUpDown1.Value = 0;
		}

		private void Form1_CheckedChanged(object sender, EventArgs e)
		{
			if(((CheckBox)sender).Checked)
				((CheckBox)sender).BackColor = Color.Red;
			else
				((CheckBox)sender).BackColor = Color.FromName("Control");
			numericUpDown1.Value = ToInt(GetBits());
		}

		void Temporary()
		{
			while (true)
			{
				Console.Write($"Введи число(от {((long)int.MinValue) - 1} и до {((ulong)int.MaxValue) + 1}): ");
				string readNumber = "1";
				if (!int.TryParse(readNumber, out int intNumber) || intNumber > int.MaxValue || intNumber < int.MinValue)
					continue;
				byte[] bytes = BitConverter.GetBytes(intNumber);
				ConsoleWriteByteArray(bytes);
				for (int i = 0; i < bytes.Length; i++)
				{
					Console.Write($"byte {i}: ");
				}
				Console.WriteLine();
			}
		}
		static void ConsoleWriteByteArray(byte[] bytes)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				Console.WriteLine($"byte {i}\t: {bytes[i]} ");
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			string bitsStr = MyByte.GetByte(BitConverter.GetBytes((int)numericUpDown1.Value));
			textBox1.Text = bitsStr;
			SetBits(bitsStr);
		}
		void SetBits(string bitsStr)
		{
			for (int i = 0, j = 0; i < bits.Length; i++, j += 2)
			{
				if (bitsStr[j] == '1')
				{
					bits[i].Checked = true;
				}
				else
				{
					bits[i].Checked = false;
				}
			}
		}
		string GetBits()
		{
			string s = "";
			for (int i = 0; i < bits.Length; i++)
			{
				if (i == bits.Length - 1)
				{
					if (bits[i].Checked)

						s += "1";
					else
						s += "0";
					continue;
				}

				if (bits[i].Checked)
					s += "1 ";
				else 
					s += "0 ";
			}
			return s;
		}
		int ToInt(string s)
		{
			return Convert.ToInt32(s.Replace(" ", ""), 2);
		}
		void AllTrue()
		{
			for (int i = 0; i < bits.Length; i++)
			{
				bits[i].Checked = true;
			}
		}
		void AllFalse()
		{
			for (int i = 0; i < bits.Length; i++)
			{
				bits[i].Checked = false;
			}
		}

		private void AllTrueButton_Click(object sender, EventArgs e)
		{
			AllTrue();
		}
		private void ResetButton_Click(object sender, EventArgs e)
		{
			AllFalse();
		}
	}
}