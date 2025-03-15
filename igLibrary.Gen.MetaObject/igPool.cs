using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igPool : igObject
{
	public bool _fixed;

	public bool _autoRefCount;

	public uint _capacity;

	public uint _peakAllocatedCount;

	public igPoolBucket _bucket;

	public igIndexPool _indices;

	public igMemoryPool _dataPool;

	public ushort _elementSize;

	public ushort _elementAlignment;

	public igMutex _lock;

	public igMetaObject _typeOverride;
}
