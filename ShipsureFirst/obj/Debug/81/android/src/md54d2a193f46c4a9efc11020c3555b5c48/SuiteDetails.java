package md54d2a193f46c4a9efc11020c3555b5c48;


public class SuiteDetails
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ShipsureFirst.SuiteDetails, ShipsureFirst", SuiteDetails.class, __md_methods);
	}


	public SuiteDetails ()
	{
		super ();
		if (getClass () == SuiteDetails.class)
			mono.android.TypeManager.Activate ("ShipsureFirst.SuiteDetails, ShipsureFirst", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
