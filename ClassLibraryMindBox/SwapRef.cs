using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
