namespace igLibrary
{
	public class CBoltPoint : igLibrary.Core.igObject
	{
		public System.String _boltName;
		public System.String _preserveBoltName;
		public igLibrary.Math.igMatrix44f _adjustmentMatrix;
		public System.Boolean _useAdjustmentMatrix;
		public igLibrary.Math.igVec3f _rotation;
		public System.Boolean _flipX;
		public System.Boolean _flipY;
		public System.Boolean _flipZ;
		public System.Boolean _verticalAlign;
		public System.Boolean _worldAlign;
		public System.Boolean _cameraAlign;
		public System.Boolean _keepScale;
		public System.Boolean _keepConstantSize;
		public System.Single _scale;
		public igLibrary.Math.igVec3f _offset;
		public igLibrary.Math.igVec3f _postOffset;
		public igLibrary.Math.igVec4f _vfxColor;
		public igLibrary.Math.igVec4f _vfxParameters;
		public CBoltPoint _boltOrigin;
		public CBoltPoint _boltPelvis;
		public CBoltPoint _boltSpine;
		public CBoltPoint _boltLowerTorso;
		public CBoltPoint _boltTorso;
		public CBoltPoint _boltNeck;
		public CBoltPoint _boltHead;
		public CBoltPoint _boltRoot;
		public CBoltPoint _boltRHand;
		public CBoltPoint _boltLHand;
		public CBoltPoint _boltRHandAttach;
		public CBoltPoint _boltLHandAttach;
		public CBoltPoint _boltRFoot;
		public CBoltPoint _boltLFoot;
		public CBoltPoint _boltRUpperArm;
		public CBoltPoint _boltLUpperArm;
		public CBoltPoint _boltRForearm;
		public CBoltPoint _boltLForearm;
		public CBoltPoint _boltHeroHat;
		public CBoltPoint _boltCenter;
		public CBoltPoint _boltTop;
		public CBoltPoint _boltLockedTarget;
		public CBoltPoint _boltDriverAttach;
	}
}