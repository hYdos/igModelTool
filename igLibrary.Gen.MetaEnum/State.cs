namespace igLibrary.Gen.MetaEnum;

public enum State
{
	kStateIdle,
	kStateOpening,
	kStateOpened,
	kStateReadingHeader,
	kStateReadHeader,
	kStateReadingSections,
	kStateReadSections,
	kStateFinished,
	kStateAborting,
	kStateFailed
}
