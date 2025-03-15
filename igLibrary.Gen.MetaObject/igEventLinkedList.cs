using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igEventLinkedList : igObject
{
	public ulong _head;

	public ulong _nextPtr;

	public static igEventListItemPool _itemPool;
}
