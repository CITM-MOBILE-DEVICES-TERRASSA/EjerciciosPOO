using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownAlphaNumericAcoplado : MonoBehaviour
{
    [SerializeField] ChangeMaterialColor CMCAcoplado;
    [SerializeField] RotateObject[] rotateObjects;
    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 1; i <= keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                CMCAcoplado.SetColor(i - 1);
            }
            if(Input.GetKey((KeyCode.Alpha0 + i)))
            {
                foreach (var rotateObject in rotateObjects)
                {
                    rotateObject.InputToRotation(i - 1);
                }
            }
        }
    }
}
