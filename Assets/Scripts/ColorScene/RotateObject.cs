using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 20f;
    const int IZQUIERDA = 0;
    const int DERECHA = 1;
    private Rigidbody rigidBody;
    bool mustRotate = false;
    Vector3 direction = Vector3.zero;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void InputToRotation(int direccion)
    {
        if (direccion == IZQUIERDA)
        {
            direction = Vector3.up;
        }
        else if (direccion == DERECHA)
        {
            direction = Vector3.down;
        }
        mustRotate = true;
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
        Debug.Log(this.name + " RotateKinematicTransform");
        transform.Rotate(direction * RotateSpeed * Time.deltaTime);
    }

    private void RotateKinematicRigidBody(Vector3 direction)
    {
        Debug.Log(this.name + " RotateKinematicRigidBody");
        Quaternion deltaRotation = Quaternion.Euler(direction * RotateSpeed * Time.deltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }

    private void RotateDynamic(Vector3 direction)
    {
        Debug.Log(this.name + " RotateDynamic");
        rigidBody.AddTorque(direction * RotateSpeed);
    }
}
