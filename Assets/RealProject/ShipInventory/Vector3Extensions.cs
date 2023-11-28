using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Vector3Extensions
{ 
    public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3( x ?? vector.x, y ?? vector.y, z ?? vector.z); 
    }

    public static Vector3 Add(this Vector3 vector3, float x = 0f, float y = 0f, float z = 0f)
    {
        return new Vector3(vector3.x +x, vector3.y + y, vector3.z + z);
    }

    public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
    {
        float x  = vector.x < min.x ? min.x : (vector.x > max.x ? max.x : vector.x);
        float y = vector.y < min.y ? min.y : (vector.y > max.y ? max.y : vector.y);
        float z = vector.z < min.z ? min.z : (vector.z > max.z ? max.z : vector.z);

        return new Vector3(x, y, z);
    }
}
