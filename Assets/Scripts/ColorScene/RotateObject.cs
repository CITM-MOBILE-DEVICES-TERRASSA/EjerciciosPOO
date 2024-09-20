using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 20f;
    const int IZQUIERDA = 0;
    const int DERECHA = 1;

    public void InputToRotation(int direccion)
    {
        Vector3 direction = Vector3.zero;
        if (direccion == IZQUIERDA)
        {
            direction = Vector3.up;
        }
        else if (direccion == DERECHA)
        {
            direction = Vector3.down;
        }
        Rotate(direction);
    }
    
    private void Rotate(Vector3 direction)
    {
        transform.Rotate(direction * RotateSpeed * Time.deltaTime);
    }
}
