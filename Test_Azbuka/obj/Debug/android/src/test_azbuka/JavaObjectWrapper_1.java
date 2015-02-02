package test_azbuka;


public class JavaObjectWrapper_1
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Test_azbuka.JavaObjectWrapper`1, Test_azbuka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", JavaObjectWrapper_1.class, __md_methods);
	}


	public JavaObjectWrapper_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == JavaObjectWrapper_1.class)
			mono.android.TypeManager.Activate ("Test_azbuka.JavaObjectWrapper`1, Test_azbuka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
