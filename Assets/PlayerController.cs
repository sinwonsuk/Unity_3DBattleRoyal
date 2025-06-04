using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public int speed = 100;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
    }

    Rigidbody rigidbody;
}
