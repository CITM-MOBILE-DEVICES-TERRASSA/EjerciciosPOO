using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEventHandler : MonoBehaviour
{
    [SerializeField] private RotateObject rotateObject;
    private void Start()
    {
        CheckKeyDownAlphaNumeric.AlphaKey += rotateObject.InputToRotation;
        CheckKeyDownAlphaNumeric.AlphaKeyUp += rotateObject.StopToRotation;
    }

    private void OnDestroy()
    {
        CheckKeyDownAlphaNumeric.AlphaKey -= rotateObject.InputToRotation;
        CheckKeyDownAlphaNumeric.AlphaKeyUp -= rotateObject.StopToRotation;
    }
}
