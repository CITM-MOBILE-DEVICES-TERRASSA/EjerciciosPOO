using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownD : MonoBehaviour
{
    public static event Action DKeyDown;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DKeyDown?.Invoke();
        }
    }
}
