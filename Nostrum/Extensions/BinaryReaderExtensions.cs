using System;
using System.IO;

namespace Nostrum.Extensions;

public static class BinaryReaderExtensions
{
	public static float ReadSingleBE(this BinaryReader br)
	{
		var data = br.ReadBytes(4);
		Array.Reverse(data);
		return BitConverter.ToSingle(data, 0);
	}

	public static ushort ReadUInt16BE(this BinaryReader br)
	{
		var data = br.ReadBytes(2);
		Array.Reverse(data);
		return BitConverter.ToUInt16(data, 0);
	}

	public static uint ReadUInt32BE(this BinaryReader br)
	{
		var data = br.ReadBytes(4);
		Array.Reverse(data);
		return BitConverter.ToUInt32(data, 0);
	}
	public static int ReadInt32BE(this BinaryReader br)
	{
		var data = br.ReadBytes(4);
		Array.Reverse(data);
		return BitConverter.ToInt32(data, 0);
	}
}
