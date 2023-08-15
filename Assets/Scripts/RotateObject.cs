using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationAxis;
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
