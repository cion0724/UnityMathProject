using UnityEngine;
using System.Collections;
using System.Text;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Awake()
    {
        //Debug.LogError(MathUtil.Rad2Deg(Mathf.Atan(4)));
        //PrintSinCosTanValue(30.0f);
        //TestAngleCalc();                
	}

    void TestRadDegree()
    {
        Debug.LogError(VectorUtil.Deg2Rad(360.0f));
        Debug.LogError(VectorUtil.Rad2Deg(2.0f));
        Debug.LogError(VectorUtil.Rad2Deg(6.283185f));        
    }


    void PrintSinCosTanValue(float increaseValue = 1.0f)
    {
        StringBuilder sb = new StringBuilder();
        for (float degree = 0; degree <= 360.0f; degree += increaseValue)
        {
            float radian = VectorUtil.Deg2Rad(degree);
            sb.AppendFormat("Degree : {0}  sin {1}  cos {2}  tan {3} \n", degree, Mathf.Sin(radian), Mathf.Cos(radian), Mathf.Tan(radian));
        }
        Debug.LogError(sb.ToString());
    }

    void TestAngleCalc()
    {
        Vector2 v1 = new Vector2(0, 0);
        Vector2 v2 = new Vector2(-1, 0);
        Debug.LogError(VectorUtil.CalcAngle2D(v1, v2));
    }

    void TestAngleBetween()
    {
        Debug.LogError(VectorUtil.AngleBetween3DVectors(new Vector3(5, -2, 0), new Vector3(1, 2, 3)));
    }
}
