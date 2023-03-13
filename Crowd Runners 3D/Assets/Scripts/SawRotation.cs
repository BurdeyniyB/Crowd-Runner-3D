using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
public float rotationSpeed = 10f; 

void Update()
{
    float currentRotation = transform.rotation.eulerAngles.y;

    float newRotation = currentRotation + rotationSpeed * Time.deltaTime;

    Quaternion rotation = Quaternion.Euler(0f, newRotation, 0f);

    transform.rotation = rotation;
}

}
