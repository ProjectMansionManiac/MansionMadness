using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotationComponent : MonoBehaviour
{
    [SerializeField] Transform rotationCenter = null;
    [SerializeField] float rotationDistance = 5.0f;
    [SerializeField] float rotationSpeed = 1.0f;

    float currentAngle;
    
	void Update ()
    {
        // make space for a rotation vector
        Vector2 rotation;

        // increase the angle
        currentAngle += rotationSpeed * Time.deltaTime;

        // calculate a rotation vector
        rotation.x = (transform.up.x * Mathf.Cos(currentAngle)) - (transform.up.y * Mathf.Sin(currentAngle));
        rotation.y = (transform.up.x * Mathf.Sin(currentAngle)) + (transform.up.y * Mathf.Cos(currentAngle));
        // increase the size of the rotation
        rotation *= rotationDistance;

        // set the position of this object to
        // the position of the rotation around the rotationCenter
        this.gameObject.transform.position = rotationCenter.position + new Vector3(rotation.x, rotation.y, 0);
    }
}
