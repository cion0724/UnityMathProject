using UnityEngine;
using System.Collections;

public class VectorUtil
{
    // mathf에 정의 되어 있는 디파인 값들 
    //inside Unity mathf Struct
    //public const float Deg2Rad = 0.0174533f;
    //public const float Epsilon = 1.4013e-045f;
    //public const float Infinity = 1.0f / 0.0f;
    //public const float NegativeInfinity = -1.0f / 0.0f;
    //public const float PI = 3.14159f;
    //public const float Rad2Deg = 57.2958f;

    #region 삼각함수 테이블들 
    private float[] sinTable = MakeSinTable();
    public float[] SinTable
    {
        get { return sinTable; }
    }

    private float[] cosTable = MakeCosTable();
    public float[] CosTable
    {
        get { return cosTable; }
    }

    private float[] tanTable = MakeTanTable();
    public float[] TanTable
    {
        get { return tanTable; }
    }
    #endregion

    #region public functions 
    public static float Deg2Rad(float degree)
    {
        return degree * Mathf.Deg2Rad;
    }

    public static float Rad2Deg(float radian)
    {
        return radian * Mathf.Rad2Deg;
    }

    // 0보다 작거나 360보다 큰 값을 0 ~ 360 사이 각으로 보정 시켜 줌
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

    // 두점을 바탕으로 한 방향 벡터의 각을 구함 
    public static float CalcAngle2D(Vector2 v1, Vector2 v2)
    {
        return Mathf.Atan2(v2.y - v1.y,v2.x - v1.x) * Mathf.Rad2Deg;
    }
    
    public static float CalcAngle2D(float x1, float y1, float x2, float y2)
    {
        Vector2 v1 = new Vector2(x1, y1);
        Vector2 v2 = new Vector2(x2, y2);
        return CalcAngle2D(v1, v2);
    }

    // 두 벡터 사이에 끼인 각을 구함 
    public static float AngleBetween2DVectors(Vector2 v1, Vector2 v2)
    {
        return Mathf.Acos(Vector2.Dot(v1, v2) / (v1.magnitude * v2.magnitude)) * Mathf.Rad2Deg;
    }

    public static float AngleBetween3DVectors(Vector3 v1, Vector3 v2)
    {
        return Mathf.Acos(Vector3.Dot(v1, v2) / (v1.magnitude * v2.magnitude)) * Mathf.Rad2Deg;
    }
    
    public Vector2 GetDirection2D(float degree)
    {
        Vector2 v = new Vector2();
        float radian = degree * Mathf.Deg2Rad;
        v.x = Mathf.Cos(radian);
        v.y = Mathf.Sin(radian);
        return v;
    }

    public static eVectorDotResult Dot2D(Vector2 v1, Vector2 v2)
    {
        float dotValue = Vector2.Dot(v1, v2);
        
        if (dotValue < 0)
        {
            return eVectorDotResult.OverThan90;
        }
        else if (dotValue > 0)
        {
            return eVectorDotResult.LessThan90;
        }

        return eVectorDotResult.Same90;
    }
    #endregion
}

