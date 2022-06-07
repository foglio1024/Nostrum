using System;
using System.IO;

namespace Nostrum.Extensions;

public static class BinaryWriterExtensions
{
	public static void WriteBE(this BinaryWriter bw, ushort value)
	{
		var data = BitConverter.GetBytes(value);
		Array.Reverse(data);
		bw.Write(data);
	}
	public static void WriteBE(this BinaryWriter bw, uint value)
	{
		var data = BitConverter.GetBytes(value);
		Array.Reverse(data);
		bw.Write(data);
	}
	public static void WriteBE(this BinaryWriter bw, int value)
	{
		var data = BitConverter.GetBytes(value);
		Array.Reverse(data);
		bw.Write(data);
	}
}
