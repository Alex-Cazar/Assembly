using System;
using System.Collections;
using System.Collections.Generic;

namespace Blamite.Extensions
{
	public static class BitArrayExtensions
	{
		public static byte[] ToByteArray(this BitArray bits)
		{
			var bytes = new byte[bits.Length / 8];
			for (var i = 0; i < bits.Length; i += 8)
			{
				byte b = 0x00;
				for (var y = 0; y < 8; y++)
					if (bits[i + y])
						b |= (byte)(1 << y);
				
				bytes[i == 0 ? 0 : (i / 8)] = b;
			}

			return bytes;
		}

		public static int[] ToIntArray(this BitArray bits)
		{
			var bytes = bits.ToByteArray();
			var ints = new List<int>();

			for(var i = 0; i < bytes.Length; i += 4)
				ints.Add(Convert.ToInt32(new []
				{
					bytes[i],
					bytes[i + 1],
					bytes[i + 2],
					bytes[i + 3]
				}));

			return ints.ToArray();
		}
	}
}
