using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private Vector3[] directions = { Vector3.up, Vector3.down };
    private Rigidbody rigidBody;
    private bool mustRotate = false;
    private Vector3 direction = Vector3.zero;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void InputToRotation(int direction)
    {
        if (direction < directions.Length)
        {
            this.direction = directions[direction];
            mustRotate = true;
        }
    }

    public void StopToRotation()
    {
        mustRotate = false;
        if (rigidBody != null && !rigidBody.isKinematic)
        {
            rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void Update()
    {
        if (rigidBody == null && mustRotate)
        {
            RotateKinematicTransform(direction);
        }
    }

    private void FixedUpdate()
    {
        if (rigidBody != null && mustRotate)
        {
            if (rigidBody.isKinematic)
            {
                RotateKinematicRigidBody(direction);
            }
            else
            {
                RotateDynamic(direction);
            }
        }
    }

    private void RotateKinematicTransform(Vector3 direction)
    {
        transform.Rotate(direction * rotateSpeed * Time.deltaTime);
    }

    private void RotateKinematicRigidBody(Vector3 direction)
    {
        Quaternion deltaRotation = Quaternion.Euler(direction * rotateSpeed * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }

    private void RotateDynamic(Vector3 direction)
    {
        rigidBody.AddTorque(direction * rotateSpeed);
    }
}
