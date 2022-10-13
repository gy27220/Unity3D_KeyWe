using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
    float rotationY;
    float speed = 3.0f;

    void Start()
    {
        rotationY = 0;
    }


    void Update()
    {
        rotationY += speed * Time.deltaTime;

        if (rotationY >= 360)
            rotationY = 0;

        RenderSettings.skybox.SetFloat("_Rotation", rotationY);
    }
}
