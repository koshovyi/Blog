using System;

namespace Blog.ComputerScience
{

	#region CMYK

	//CMYK Shift
	[Flags]
	public enum CMYK1 : uint
	{
		None = 0,
		C = 1,
		M = C << 1,
		Y = M << 1,
		K = Y << 1,
	}

	//CMYK HEX
	[Flags]
	public enum CMYK2 : uint
	{
		None = 0,
		C = 0x1,
		M = 0x2,
		Y = 0x4,
		K = 0x8,
	}

	//CMYK BIN
	[Flags]
	public enum CMYK3 : uint
	{
		None = 0,
		C = 0b1,
		M = 0b1_0,
		Y = 0b1_00,
		K = 0b1_000,
	}

	#endregion

	[Flags]
	public enum AccessLevels : uint
	{
		None = 0,

		//Articles
		READ_ARTICLES = 1,
		WRITE_ARTICLES = 2,
		DELETE_ARTICLES = 4,

		//Comments
		READ_COMMENTS = 8,
		WRITE_COMMENTS = 16,
		DELETE_COMMENTS = 32,

		//Profiles
		CREATE_PROFILES = 64,
		BLOCK_PROFILES = 128,

		ALL = ~None,
	}

	public class BitOperations
	{

		public AccessLevels Value { get; private set; }

		public BitOperations() => this.Value = AccessLevels.None;

		public BitOperations(AccessLevels value) => this.Value = value;

		public void Add(AccessLevels value) => this.Value |= value;

		public void Remove(AccessLevels value) => this.Value ^= value;

		public bool Contains(AccessLevels value) => (this.Value & value) == value;

		public override string ToString() => this.Value.ToString("G");

	}

}
