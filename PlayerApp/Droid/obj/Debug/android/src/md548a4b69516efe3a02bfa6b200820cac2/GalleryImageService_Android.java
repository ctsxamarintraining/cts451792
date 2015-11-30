package md548a4b69516efe3a02bfa6b200820cac2;


public class GalleryImageService_Android
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PlayerApp.Droid.GalleryImageService_Android, PlayerApp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GalleryImageService_Android.class, __md_methods);
	}


	public GalleryImageService_Android () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GalleryImageService_Android.class)
			mono.android.TypeManager.Activate ("PlayerApp.Droid.GalleryImageService_Android, PlayerApp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
