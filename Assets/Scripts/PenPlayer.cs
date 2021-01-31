using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenPlayer : MonoBehaviour
{
    public const int MaxThrottle = 10;
    public const float SmoothMovement = 0.5f;
    public const float SmoothTurning = 2f;

    private float movePos = 0f;
    private float moveRot = 0f;
    private Rigidbody tankRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePos = Input.GetAxis("Vertical") * 20f;
        movePos = (movePos > MaxThrottle) ? MaxThrottle : movePos;
        float roundedLeftThrottle = Mathf.Round(movePos);
        if (Mathf.Abs(roundedLeftThrottle - movePos) < 0.02f)
        {
            movePos = roundedLeftThrottle;
        }
        else if (roundedLeftThrottle > movePos)
        {
            movePos += 0.01f;
        }
        else if (roundedLeftThrottle < movePos)
        {
            movePos -= 0.01f;
        }

        moveRot = Input.GetAxis("Horizontal") * 20f;
        moveRot = (moveRot > MaxThrottle) ? MaxThrottle : moveRot;
        float roundedRightThrottle = Mathf.Round(moveRot);
        if (Mathf.Abs(roundedRightThrottle - moveRot) < 0.02f)
        {
            moveRot = roundedRightThrottle;
        }
        else if (roundedRightThrottle > moveRot)
        {
            moveRot += 0.01f;
        }
        else if (roundedRightThrottle < moveRot)
        {
            moveRot -= 0.01f;
        }

        // Move the tank.
        Vector3 movement = transform.forward * (movePos / 2f) * SmoothMovement * Time.deltaTime;
        tankRigidbody.MovePosition(tankRigidbody.position + movement);

        // Turn the tank.
        float turn = (moveRot) * SmoothTurning * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(turn, 0f, 0f);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
    }
}
