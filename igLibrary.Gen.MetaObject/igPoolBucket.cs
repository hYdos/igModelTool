using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igPoolBucket : igObject
{
	public igMemory<byte> _data;

	public uint _count;

	public igPoolBucket _next;
}
