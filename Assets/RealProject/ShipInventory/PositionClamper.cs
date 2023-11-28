using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    public Vector3 maxPosition;
    public Vector3 minPosition;

    void LateUpdate()
    {
        transform.position = transform.position.Clamp(minPosition, maxPosition);
    }
}
