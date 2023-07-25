using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed = 5;
    float horizontalInput;
    Plane myPlane;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Vertical");
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
