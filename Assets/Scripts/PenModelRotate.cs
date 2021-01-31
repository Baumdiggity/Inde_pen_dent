using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenModelRotate : MonoBehaviour
{
    public Rigidbody body;
    [SerializeField]
    Vector3 currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        // currentRotation = transform.rotation;
        // currentEulerAngles = currentRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentEulerAngles += new Vector3(0, 0, body.velocity.magnitude * Time.deltaTime);
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation; body.velocity.magnitude * 10000.0f
        */
        currentRotation = new Vector3(0, 0, Input.GetAxis("Vertical")*3.0f);
        transform.localEulerAngles -= currentRotation;
    }
}