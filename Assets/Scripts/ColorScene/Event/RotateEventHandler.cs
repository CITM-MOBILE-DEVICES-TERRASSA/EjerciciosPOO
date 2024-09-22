using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEventHandler : MonoBehaviour
{
    [SerializeField] RotateObject[] rotateObjects;
    void Start()
    {
        foreach (var rotateObject in rotateObjects)
        {
            CheckKeyDownAlphaNumeric.OnAlphaKey += rotateObject.InputToRotation;
            CheckKeyDownAlphaNumeric.OnAlphaKeyUp += rotateObject.StopToRotation;
        }
    }
}
