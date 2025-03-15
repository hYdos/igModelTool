using System.Runtime.InteropServices;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
public class igMemoryCommandStream : igCommandStream
{
	public igMemory<byte> _memory;

	public uint _bytesWritten;
}
