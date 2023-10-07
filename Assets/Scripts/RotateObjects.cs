using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public float speedRotationObjects = 10.0f;

    void Update()
    {
        transform.Rotate(Vector3.up * speedRotationObjects * Time.deltaTime);
    }
}
