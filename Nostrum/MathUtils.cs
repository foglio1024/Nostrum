using Point = System.Windows.Point;

namespace Nostrum
{
    public static class MathUtils
    {
        /// <summary>
        /// Maps a 0-1 value to a 0-360 angle. The result can be scaled by using the multiplier argument.
        /// </summary>
        /// <param name="value">the 0-1 input value</param>
        /// <param name="multiplier">the multiplier</param>
        /// <returns>the mapped angle value in degrees</returns>
        public static double FactorToAngle(double value, double multiplier = 1)
        {
            return value * (359.9 / multiplier);
        }

        /// <summary>
        /// Calculates a 0-1 value by dividing the input value for the max value. Result is capped at 1.
        /// </summary>
        /// <param name="input">the input value</param>
        /// <param name="max">the max value</param>
        /// <returns>input/max if max is greater than 0; 1 if the result if greater than 1</returns>
        public static double FactorCalc(double input, double max)
        {
            return max > 0
                ? input / max > 1
                    ? 1
                    : input / max
                : 1;
        }

        /// <summary>
        /// Subtracts the center point coordinates from the input point coordinates to obtain the input point's coordinates relative to the center point.
        /// </summary>
        /// <param name="inputX">input X coordinate</param>
        /// <param name="inputY">input Y coordinate</param>
        /// <param name="centerX">center X coordinate</param>
        /// <param name="centerY">center Y coordinate</param>
        /// <returns>the input points with coordinates relative to the center point</returns>
        public static Point GetRelativePoint(double inputX, double inputY, double centerX, double centerY)
        {
            return new Point(inputX - centerX, inputY - centerY);
        }
    }
}