using CauldronModels.igLibrary.Gen.MetaEnum;
using igLibrary.Core;

namespace CauldronModels.igLibrary.Gen.MetaObject;

public class igTimeTransform2 : igObject
{
	public float _scale;

	public float _bias;

	public uint _cutoff;

	public RepeatMode _repeatMode;

	public uint _initialTime;
}
