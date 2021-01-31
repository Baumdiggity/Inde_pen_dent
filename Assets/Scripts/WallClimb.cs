using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    public bool wallClimb = false;
    public bool vertEnabled;
    float distToGround;
    public PenPlayer horMove;
    BoxCollider _col;
    Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponentInParent<BoxCollider>();
        _body = GetComponentInParent<Rigidbody>();
        distToGround = _col.bounds.extents.y;
        vertEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        horMove.enabled = isGrounded();
        if(vertEnabled)
        {
            _body.useGravity = false;
            _body.MovePosition(new Vector3(_body.position.x, _body.position.y + Input.GetAxis("Vertical") * Time.deltaTime, _body.position.z));
            //_body.position += new Vector3(0, Input.GetAxis("Vertical") * Time.deltaTime, 0);
            if(!isGrounded())
            {
                _body.isKinematic = true;
            }
        }
        else
        {
            _body.useGravity = true;
            _body.isKinematic = false;
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(new Vector3(transform.position.x,transform.position.y + distToGround,transform.position.z), -Vector3.up, distToGround + 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        if (wallClimb && other.gameObject.CompareTag("Climbable"))
        { 
            vertEnabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (wallClimb && other.gameObject.CompareTag("Climbable"))
        {
            vertEnabled = false;
        }
    }
}


