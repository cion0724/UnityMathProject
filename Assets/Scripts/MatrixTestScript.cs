using UnityEngine;
using System.Collections;

public class MatrixTestScript : MonoBehaviour {

	// Use this for initialization

    void Awake()
    {
        PrintTansformMatrix();
    }
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void TransposeTest()
    {
        Matrix4x4 mat4 = new Matrix4x4();
        mat4.m00 = 1; mat4.m01 = 4; mat4.m02 = 7;
        mat4.m10 = 1; mat4.m11 = 5; mat4.m12 = 8;
        mat4.m20 = 3; mat4.m21 = 6; mat4.m22 = 9;
        Debug.LogError(Matrix4x4.Transpose(mat4));
    }

    void PrintTansformMatrix()
    {
        Debug.LogError(transform.localToWorldMatrix);        
        
    }

}
