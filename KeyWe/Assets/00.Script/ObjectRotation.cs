using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    #region public º¯¼ö
    public Vector3 rotationPos;
    public float   speed;
    #endregion


    void Update()
    {
        transform.Rotate(new Vector3(rotationPos.x * speed * Time.deltaTime, rotationPos.y * speed * Time.deltaTime, rotationPos.z * speed * Time.deltaTime));
    }
}
