using Blog.ComputerScience;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

	[TestClass]
	public class BitOperationsTests
	{

		[TestMethod]
		public void BitOperations_AddContains_1()
		{
			//Arrange
			BitOperations b = new BitOperations();

			//Act
			b.Add(AccessLevels.CREATE_PROFILES);

			//Assert
			Assert.AreEqual(AccessLevels.CREATE_PROFILES, b.Value);
			Assert.IsTrue(b.Contains(AccessLevels.CREATE_PROFILES));
		}

		[TestMethod]
		public void BitOperations_AddContains_2()
		{
			//Arrange
			BitOperations b = new BitOperations();

			//Act
			b.Add(AccessLevels.READ_ARTICLES | AccessLevels.READ_COMMENTS);

			//Assert
			Assert.AreEqual(AccessLevels.READ_ARTICLES | AccessLevels.READ_COMMENTS, b.Value);
			Assert.IsTrue(b.Contains(AccessLevels.READ_ARTICLES));
			Assert.IsTrue(b.Contains(AccessLevels.READ_COMMENTS));
		}


		[TestMethod]
		public void BitOperations_AddContains_All()
		{
			//Arrange
			BitOperations b = new BitOperations();

			//Act
			b.Add(AccessLevels.ALL);

			//Assert
			Assert.IsTrue(b.Contains(AccessLevels.READ_ARTICLES));
			Assert.IsTrue(b.Contains(AccessLevels.WRITE_ARTICLES));
			Assert.IsTrue(b.Contains(AccessLevels.DELETE_ARTICLES));
			Assert.IsTrue(b.Contains(AccessLevels.READ_COMMENTS));
			Assert.IsTrue(b.Contains(AccessLevels.WRITE_COMMENTS));
			Assert.IsTrue(b.Contains(AccessLevels.DELETE_COMMENTS));
			Assert.IsTrue(b.Contains(AccessLevels.BLOCK_PROFILES));
			Assert.IsTrue(b.Contains(AccessLevels.CREATE_PROFILES));
		}

		[TestMethod]
		public void BitOperations_Remove_1()
		{
			//Arrange
			BitOperations b = new BitOperations();
			b.Add(AccessLevels.READ_ARTICLES | AccessLevels.READ_COMMENTS | AccessLevels.CREATE_PROFILES);

			//Act
			b.Remove(AccessLevels.CREATE_PROFILES);

			//Assert
			Assert.AreEqual(AccessLevels.READ_ARTICLES | AccessLevels.READ_COMMENTS, b.Value);
			Assert.IsTrue(b.Contains(AccessLevels.READ_ARTICLES));
			Assert.IsTrue(b.Contains(AccessLevels.READ_COMMENTS));
		}

		[TestMethod]
		public void CMYK_DEC_1()
		{
			//Arrange

			//Act

			//Assert
			Assert.AreEqual(0, (int)CMYK1.None);
			Assert.AreEqual(1, (int)CMYK1.C);
			Assert.AreEqual(2, (int)CMYK1.M);
			Assert.AreEqual(4, (int)CMYK1.Y);
			Assert.AreEqual(8, (int)CMYK1.K);
		}

		[TestMethod]
		public void CMYK_HEX_1()
		{
			//Arrange

			//Act

			//Assert
			Assert.AreEqual(0, (int)CMYK2.None);
			Assert.AreEqual(1, (int)CMYK2.C);
			Assert.AreEqual(2, (int)CMYK2.M);
			Assert.AreEqual(4, (int)CMYK2.Y);
			Assert.AreEqual(8, (int)CMYK2.K);
		}

		[TestMethod]
		public void CMYK_BIN_1()
		{
			//Arrange

			//Act

			//Assert
			Assert.AreEqual(0, (int)CMYK3.None);
			Assert.AreEqual(1, (int)CMYK3.C);
			Assert.AreEqual(2, (int)CMYK3.M);
			Assert.AreEqual(4, (int)CMYK3.Y);
			Assert.AreEqual(8, (int)CMYK3.K);
		}

	}

}
