using System;


namespace ClassLibraryMindBox
{
	public static class SwapRef
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}
	}
}
