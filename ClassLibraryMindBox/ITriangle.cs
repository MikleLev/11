using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryMindBox
{
	public interface ITriangle : IFigure
	{
		double EdgeA { get; }
		double EdgeB { get; }
		double EdgeC { get; }

		bool IsRightTriangle { get; }
	}
}
