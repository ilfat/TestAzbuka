package imageviewextention;


public class ImageViewExtention_TaskWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ImageViewExtention.ImageViewExtention/TaskWrapper, Test_azbuka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ImageViewExtention_TaskWrapper.class, __md_methods);
	}


	public ImageViewExtention_TaskWrapper () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ImageViewExtention_TaskWrapper.class)
			mono.android.TypeManager.Activate ("ImageViewExtention.ImageViewExtention/TaskWrapper, Test_azbuka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
