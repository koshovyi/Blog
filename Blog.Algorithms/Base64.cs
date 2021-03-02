using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Algorithms
{
	public class Base64
	{

		public const int COUNT_ENCODE_BYTES = 3;
		
		public const int COUNT_BITS = 24;

		public const int COUNT_ENCODE_BITS = 6;

		public const int COUNT_DECODE_BITS = 8;

		public static readonly char[] AR = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();

		public static string ToBin(byte[] data) => string.Join(string.Empty, data.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

		public static string ToBin(string data) => ToBin(Encoding.UTF8.GetBytes(data));

		public static string[] Split(string bin, int count)
		{
			if (bin.Length != COUNT_BITS)
				throw new ArgumentException(nameof(bin));

			List<string> result = new List<string>();
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < COUNT_BITS; i++)
			{
				sb.Append(bin[i]);
				if(sb.Length == count)
				{
					result.Add(sb.ToString());
					sb.Clear();
				}
			}
			return result.ToArray();
		}

		public static int[] BinToInt(string[] data)
		{
			List<int> result = new List<int>();
			foreach(string c in data)
				result.Add(Convert.ToInt32(c, 2));
			return result.ToArray();
		}

		public static int GetCountOfEquals(string data)
		{
			int mod = data.Length % COUNT_ENCODE_BYTES;
			if (mod == 0)
				return 0;
			return COUNT_ENCODE_BYTES - mod;
		}

		public static string Encode(string data)
		{
			Queue<char> q = new Queue<char>(); 
			StringBuilder sb = new StringBuilder();

			foreach(char c in data)
			{
				if (q.Count == COUNT_ENCODE_BYTES)
					sb.Append(Process(q));
				q.Enqueue(c);
			}

			if (q.Count > 0)
			{
				sb.Append(Process(q));

				int e = GetCountOfEquals(data);
				sb.Remove(sb.Length - e, e);
				sb.Append(new string('=', e));
			}

			return sb.ToString();
		}

		public static string Process(Queue<char> q)
		{
			string data = GetDataFromQueue(q);
			string bin = ToBin(data).PadRight(COUNT_BITS, '0');
			string[] parts = Split(bin, COUNT_ENCODE_BITS);
			int[] index = BinToInt(parts);

			StringBuilder sb = new StringBuilder();
			foreach (int i in index)
				sb.Append(AR[i]);

			return sb.ToString();
		}

		public static string GetDataFromQueue(Queue<char> q)
		{
			StringBuilder sb = new StringBuilder();
			while (q.Count > 0)
				sb.Append(q.Dequeue());
			return sb.ToString();
		}

	}
}
