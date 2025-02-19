﻿using System;

namespace ClassLibraryMindBox
{
	public interface ITriangle : IFigure
	{
		double SideA { get; }
		double SideB { get; }
		double SideC { get; }

		bool IsRightTriangle { get; }
	}
}
