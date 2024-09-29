using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownDestroy : MonoBehaviour
{
    public static event Action OnDestroy;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnDestroy?.Invoke();
        }
    }
}
