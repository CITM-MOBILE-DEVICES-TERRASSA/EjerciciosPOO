using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEventHandler : MonoBehaviour
{
    [SerializeField] RotateObject rotateObject;
    void Start()
    {
        CheckKeyDownAlphaNumeric.OnAlphaKey += rotateObject.InputToRotation;
        CheckKeyDownAlphaNumeric.OnAlphaKeyUp += rotateObject.StopToRotation;
    }

    void OnDestroy()
    {
        CheckKeyDownAlphaNumeric.OnAlphaKey -= rotateObject.InputToRotation;
        CheckKeyDownAlphaNumeric.OnAlphaKeyUp -= rotateObject.StopToRotation;
    }
}
