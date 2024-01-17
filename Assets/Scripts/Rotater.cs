using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField][Range(-360, 360)] float angle;

    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(angle * Time.deltaTime, Vector3.up);
    }
}
