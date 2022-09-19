namespace SFigure.Base
{
    public class Circle : Figure
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Радиус не может быть отрицательным");

            Radius = radius;
        }

        protected sealed override double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }

    
}
