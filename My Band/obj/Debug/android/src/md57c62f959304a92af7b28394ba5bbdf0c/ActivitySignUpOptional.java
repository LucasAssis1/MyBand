package md57c62f959304a92af7b28394ba5bbdf0c;


public class ActivitySignUpOptional
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("My_Band.Activities.ActivitySignUpOptional, My Band, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivitySignUpOptional.class, __md_methods);
	}


	public ActivitySignUpOptional () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivitySignUpOptional.class)
			mono.android.TypeManager.Activate ("My_Band.Activities.ActivitySignUpOptional, My Band, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
