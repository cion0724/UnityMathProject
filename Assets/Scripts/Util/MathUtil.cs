using UnityEngine;
using System.Collections;

/// <summary>
/// MathUtil.cs 
/// </summary>

public struct MathUtil
{
    //inside Unity mathf Struct
    //public const float Deg2Rad = 0.0174533f;
    //public const float Epsilon = 1.4013e-045f;
    //public const float Infinity = 1.0f / 0.0f;
    //public const float NegativeInfinity = -1.0f / 0.0f;
    //public const float PI = 3.14159f;
    //public const float Rad2Deg = 57.2958f;

    public static float Deg2Rad(float degree)
    {
        return degree * Mathf.Deg2Rad;
    }

    public static float Rad2Deg(float radian)
    {
        return radian * Mathf.Rad2Deg;
    }

    /// <summary>
    /// revise DegreeValues  0 ~ 360
    /// </summary>    
    public static float ReviseDegree(float degree)
    {
        return Mathf.Abs(degree % 360.0f);
    }

    public static float[] MakeSinTable()
    {
        float[] sinTable = new float[360];
        for (int i = 0; i < 360; ++i)
        {
            sinTable[i] = Mathf.Sin(Deg2Rad((float)i));
        }
        return sinTable;
    }

    public static float[] MakeCosTable()
    {
        float[] cosTable = new float[360];
        for (int i = 0; i < 360; ++i)
        {
            cosTable[i] = Mathf.Cos(Deg2Rad((float)i));
        }
        return cosTable;
    }

    public static float[] MakeTanTable()
    {        
        float[] tanTable = new float[360];
        for (int i = 0; i < 360; ++i)
        {
            tanTable[i] = Mathf.Tan(Deg2Rad((float)i));
        }
        return tanTable;
    }

    public static float CalcAngle2D(Vector2 v1, Vector2 v2)
    {
        float angle = Mathf.Atan((v2.y - v1.y)/(v2.x - v1.x) * Mathf.Rad2Deg);

        // 1 quadrand
        if ((v2.y < v1.y && v2.x > v1.x))
            return angle;
        else if ((v2.y < v1.y && v2.x < v1.x) || (v2.y > v1.y && v2.x > v1.x))  // 2,3 quadrand
        {
            return angle + 180.0f;
        }
        else // 4 quadrant
        {
            return angle + 360.0f;
        }

        return angle;
    }

    public static float CalcAngle2D(float x1, float y1, float x2, float y2)
    {
        Vector2 v1 = new Vector2(x1, y1);
        Vector2 v2 = new Vector2(x2, y2);
        return CalcAngle2D(v1, v2);
    }

    public Vector2 GetDirection(float degree)
    {
        Vector2 v = new Vector2();
        float radian = degree * Mathf.Deg2Rad;
        v.x = Mathf.Cos(radian);
        v.y = Mathf.Sin(radian);
        return v;
    }
}
