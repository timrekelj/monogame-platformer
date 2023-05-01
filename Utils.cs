using System

namespace Platformer;

public class Utils {
    public static int Clamp(int value, int min, int max) {
        if (min > max) throw new ArgumentException("min cannot be greater than max");
        return (value < min) ? min : (value > max) ? max : value;
    }

    public static float Clamp(float value, float min, float max) {
        if (min > max) throw new ArgumentException("min cannot be greater than max");
        return (value < min) ? min :
            (value > max) ? max :
            value;;

namespace Platformer;

public class Utils {
    public static int Clamp(int value, int min, int max) {
        if (min > max) throw new ArgumentException("min cannot be greater than max");
        return (value < min) ? min : (value > max) ? max : value;
    }

    public static float Clamp(float value, float min, float max) {
        if (min > max) throw new ArgumentException("min cannot be greater than max");
        return (value < min) ? min :
            (value > max) ? max :
            value;
    }
}