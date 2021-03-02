using Blog.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Tests
{

	[TestClass]
	public class Base64Tests
	{

		[TestMethod]
		public void ToBinaryTest()
		{
			//Arrange
			string t1 = "DEV";
			string t2 = "devellloper";
			string t3 = "koshovyi";

			//Act
			string r1 = Base64.ToBin(t1);
			string r2 = Base64.ToBin(t2);
			string r3 = Base64.ToBin(t3);

			//Assert
			Assert.AreEqual("010001000100010101010110", r1);
			Assert.AreEqual("0110010001100101011101100110010101101100011011000110110001101111011100000110010101110010", r2);
			Assert.AreEqual("0110101101101111011100110110100001101111011101100111100101101001", r3);
		}

		[TestMethod]
		public void CountOfEqualsTest()
		{
			//Arrange
			string t1 = "D";
			string t2 = "DE";
			string t3 = "DEV";
			string t4 = "DEVe";
			string t5 = "DEVel";
			string t6 = "DEVelo";

			//Act
			int r1 = Base64.GetCountOfEquals(t1);
			int r2 = Base64.GetCountOfEquals(t2);
			int r3 = Base64.GetCountOfEquals(t3);
			int r4 = Base64.GetCountOfEquals(t4);
			int r5 = Base64.GetCountOfEquals(t5);
			int r6 = Base64.GetCountOfEquals(t6);

			//Assert
			Assert.AreEqual(2, r1);
			Assert.AreEqual(1, r2);
			Assert.AreEqual(0, r3);
			Assert.AreEqual(2, r4);
			Assert.AreEqual(1, r5);
			Assert.AreEqual(0, r6);
		}

		private string Encode64(string data)
		{
			byte[] b = Encoding.UTF8.GetBytes(data);
			return Convert.ToBase64String(b);
		}

		[TestMethod]
		public void EncodeTest()
		{
			//Arrange
			string t1 = "DEV";
			string t2 = "DE";
			string t3 = "D";
			string t4 = "deve";
			string t5 = "devel";
			string t6 = "develo";
			string t7 = "develop";
			string t8 = "develope";
			string t9 = "developer";

			//Act
			string r1 = Base64.Encode(t1);
			string r2 = Base64.Encode(t2);
			string r3 = Base64.Encode(t3);
			string r4 = Base64.Encode(t4);
			string r5 = Base64.Encode(t5);
			string r6 = Base64.Encode(t6);
			string r7 = Base64.Encode(t7);
			string r8 = Base64.Encode(t8);
			string r9 = Base64.Encode(t9);

			//Assert
			Assert.AreEqual(Encode64(t1), r1);
			Assert.AreEqual(Encode64(t2), r2);
			Assert.AreEqual(Encode64(t3), r3);
			Assert.AreEqual(Encode64(t4), r4);
			Assert.AreEqual(Encode64(t5), r5);
			Assert.AreEqual(Encode64(t6), r6);
			Assert.AreEqual(Encode64(t7), r7);
			Assert.AreEqual(Encode64(t8), r8);
			Assert.AreEqual(Encode64(t9), r9);
		}

	}

}
