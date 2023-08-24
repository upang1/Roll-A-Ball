using UnityEngine;

public class TiltControls : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(moveVertical * speed, 0, -moveHorizontal * speed);
        Quaternion deltaRotation = Quaternion.Euler(moveVector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }


}
