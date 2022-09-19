namespace SFigure.Base
{
    public class Triangle : Figure
    {
        private readonly Lazy<bool> _isRightAngled;
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide < 0 || secondSide < 0 || thirdSide < 0)
                throw new ArgumentOutOfRangeException("Сторона не может быть отрицательной");

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            _isRightAngled = new Lazy<bool>(CheckIsRightAngled);
        }

        private bool CheckIsRightAngled()
        {
            var maxSide = new[] { FirstSide, SecondSide, ThirdSide }.Max();
            var maxSideSqr = maxSide * maxSide;
            return maxSideSqr + maxSideSqr == FirstSide * FirstSide + SecondSide * SecondSide + ThirdSide * ThirdSide;
        }

        protected sealed override double CalculateSquare()
        {
            var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

            var firstSideCoefficient = semiPerimeter - FirstSide;
            var secondSideCoefficient = semiPerimeter - SecondSide;
            var thirdSideCoefficient = semiPerimeter - ThirdSide;

            return Math.Sqrt(semiPerimeter * firstSideCoefficient * secondSideCoefficient * thirdSideCoefficient);
        }

    }
}
