using System;

namespace ClassLibraryMindBox
{
	public class Triangle : ITriangle
	{
		private double eps = Constants.CalculationAccuracy;

		public double SideA { get; }
		public double SideB { get; }
		public double SideC { get; }

		private readonly Lazy<bool> _isRightTriangle;
		public bool IsRightTriangle => _isRightTriangle.Value;

		/// <exception cref="ArgumentException"></exception>
		public Triangle(double sideA, double sideB, double sideC)
		{
			if (sideA < eps)
				throw new ArgumentException("Неверно указана сторона.", nameof(sideA));

			if (sideB < eps)
				throw new ArgumentException("Неверно указана сторона.", nameof(sideB));

			if (sideC < eps)
				throw new ArgumentException("Неверно указана сторона.", nameof(sideC));

			var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
			var perimeter = sideA + sideB + sideC;
			if ((perimeter - maxSide * 2) < Constants.CalculationAccuracy)
				throw new ArgumentException("Наибольшая сторона треугольника должна быть меньше суммы других сторон");

			SideA = sideA;
			SideB = sideB;
			SideC = sideC;

			_isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
		}
		private bool GetIsRightTriangle()
		{
			double maxSide = SideA, b = SideB, c = SideC;
			if (b - maxSide > Constants.CalculationAccuracy)
				SwapRef.Swap(ref maxSide, ref b);

			if (c - maxSide > Constants.CalculationAccuracy)
				SwapRef.Swap(ref maxSide, ref c);

			return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
		}

		public double GetSquare()
		{
			var square = 0d;

			if (_isRightTriangle.Value)
            {
				double maxSide = SideA, b = SideB, c = SideC;
				if (b - maxSide > Constants.CalculationAccuracy)
					SwapRef.Swap(ref maxSide, ref b);

				if (c - maxSide > Constants.CalculationAccuracy)
					SwapRef.Swap(ref maxSide, ref c);
				square = b * c / 2;
			}
			else
            {
				var halfP = (SideA + SideB + SideC) / 2d;
				square = Math.Sqrt(
					halfP
					* (halfP - SideA)
					* (halfP - SideB)
					* (halfP - SideC)
				);
			}
			return square;
		}
	}
}
