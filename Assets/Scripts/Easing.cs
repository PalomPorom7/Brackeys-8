using UnityEngine;
public enum EasingType
{
    Linear,
    SineIn,     SineOut,    SineInOut,
    QuadIn,     QuadOut,    QuadInOut,
    CubicIn,    CubicOut,   CubicInOut,
    QuartIn,    QuartOut,   QuartInOut,
    QuintIn,    QuintOut,   QuintInOut,
    ExpoIn,     ExpoOut,    ExpoInOut,
    CircIn,     CircOut,    CircInOut,
    BackIn,     BackOut,    BackInOut,
    ElasticIn,  ElasticOut, ElasticInOut,
    BounceIn,   BounceOut,  BounceInOut
}

public static class Easing
{
    private const float PI = 3.14159f;
    private const float c1 = 1.70158f;
    private const float c2 = c1 * 1.525f;
    private const float c3 = c1 + 1;
    private const float c4 = (2 * PI) / 3;
    private const float c5 = (2 * PI) / 4.5f;
    private const float n1 = 7.5625f;
    private const float d1 = 2.75f;

    public static float Ease(float x, EasingType e)
    {
        float value;
        //if we can do this without a switch, please do. Thnx uwu
        switch(e)
        {
            case EasingType.Linear:
                value = Easing.Linear(x);
                break;
            case EasingType.SineIn:
                value = Easing.SineIn(x);
                break;
            case EasingType.SineOut:
                value = Easing.SineOut(x);
                break;
            case EasingType.SineInOut:
                value = Easing.SineInOut(x);
                break;
            case EasingType.QuadIn:
                value = Easing.QuadIn(x);
                break;
            case EasingType.QuadOut:
                value = Easing.QuadOut(x);
                break;
            case EasingType.QuadInOut:
                value = Easing.QuadInOut(x);
                break;
            case EasingType.CubicIn:
                value = Easing.CubicIn(x);
                break;
            case EasingType.CubicOut:
                value = Easing.CubicOut(x);
                break;
            case EasingType.CubicInOut:
                value = Easing.CubicInOut(x);
                break;
            case EasingType.QuartIn:
                value = Easing.QuartIn(x);
                break;
            case EasingType.QuartOut:
                value = Easing.QuartOut(x);
                break;
            case EasingType.QuartInOut:
                value = Easing.QuartInOut(x);
                break;
            case EasingType.QuintIn:
                value = Easing.QuintIn(x);
                break;
            case EasingType.QuintOut:
                value = Easing.QuintOut(x);
                break;
            case EasingType.QuintInOut:
                value = Easing.QuintInOut(x);
                break;
            case EasingType.ExpoIn:
                value = Easing.ExpoIn(x);
                break;
            case EasingType.ExpoOut:
                value = Easing.ExpoOut(x);
                break;
            case EasingType.ExpoInOut:
                value = Easing.ExpoInOut(x);
                break;
            case EasingType.CircIn:
                value = Easing.CircIn(x);
                break;
            case EasingType.CircOut:
                value = Easing.CircOut(x);
                break;
            case EasingType.CircInOut:
                value = Easing.CircInOut(x);
                break;
            case EasingType.BackIn:
                value = Easing.BackIn(x);
                break;
            case EasingType.BackOut:
                value = Easing.BackOut(x);
                break;
            case EasingType.BackInOut:
                value = Easing.BackInOut(x);
                break;
            case EasingType.ElasticIn:
                value = Easing.ElasticIn(x);
                break;
            case EasingType.ElasticOut:
                value = Easing.ElasticOut(x);
                break;
            case EasingType.ElasticInOut:
                value = Easing.ElasticInOut(x);
                break;
            case EasingType.BounceIn:
                value = Easing.BounceIn(x);
                break;
            case EasingType.BounceOut:
                value = Easing.BounceOut(x);
                break;
            case EasingType.BounceInOut:
                value = Easing.BounceInOut(x);
                break;
            default:
                value = x;
                break;
        }
        return value;
    }

    public static float Linear(float x)
    {
        return x;
    }

    public static float SineIn(float x)
    {
        return 1 - Mathf.Cos((x * PI) / 2);
    }

    public static float SineOut(float x)
    {
        return Mathf.Sin((x * PI) / 2);
    }
    
    public static float SineInOut(float x)
    {
        return -(Mathf.Cos(PI * x) - 1) / 2;
    }

    public static float QuadIn(float x)
    {
        return x * x;
    }

    public static float QuadOut(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }

    public static float QuadInOut(float x)
    {
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }
    
    public static float CubicIn(float x)
    {
        return x * x * x;
    }

    public static float CubicOut(float x)
    {
        return 1 - Mathf.Pow(1 - x, 3);
    }

    public static float CubicInOut(float x)
    {
        return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }
    
    public static float QuartIn(float x)
    {
        return x * x * x * x;
    }

    public static float QuartOut(float x)
    {
        return 1 - Mathf.Pow(1 - x, 4);
    }

    public static float QuartInOut(float x)
    {
        return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
    }

    public static float QuintIn(float x)
    {
        return x * x * x * x * x;
    }

    public static float QuintOut(float x)
    {
        return 1 - Mathf.Pow(1 - x, 5);
    }

    public static float QuintInOut(float x)
    {
        return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
    }
    
    public static float ExpoIn(float x)
    {
        return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
    }

    public static float ExpoOut(float x)
    {
        return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
    }

    public static float ExpoInOut(float x)
    {
        return x == 0
            ? 0
            : x == 1
            ? 1
            : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
            : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
    }
    
    public static float CircIn(float x)
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
    }

    public static float CircOut(float x)
    {
        return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
    }

    public static float CircInOut(float x)
    {
        return x < 0.5
          ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
          : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
    }
    
    public static float BackIn(float x)
    {
        return c3 * x * x * x - c1 * x * x;
    }

    public static float BackOut(float x)
    {
        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }

    public static float BackInOut(float x)
    {
        return x < 0.5
          ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2
          : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
    }
    
    public static float ElasticIn(float x)
    {
        return x == 0
          ? 0
          : x == 1
          ? 1
          : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
    }

    public static float ElasticOut(float x)
    {
        return x == 0
          ? 0
          : x == 1
          ? 1
          : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    public static float ElasticInOut(float x)
    {
        return x == 0
          ? 0
          : x == 1
          ? 1
          : x < 0.5
          ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
          : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
    }
    
    public static float BounceIn(float x)
    {
        return 1 - BounceOut(1 - x);
    }

    public static float BounceOut(float x)
    {
        if (x < 1 / d1) {
            return n1 * x * x;
        } else if (x < 2 / d1) {
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        } else if (x < 2.5 / d1) {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        } else {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }

    public static float BounceInOut(float x)
    {
        return x < 0.5
          ? (1 - BounceOut(1 - 2 * x)) / 2
          : (1 + BounceOut(2 * x - 1)) / 2;
    }
}
