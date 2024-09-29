using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckKeyDownAlphaNumeric : MonoBehaviour
{
    public static event Action<int> OnAlphaKey;
    public static event Action<int> OnAlphaKeyDown;
    public static event Action OnAlphaKeyUp;

    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 0; i < keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                OnAlphaKeyDown?.Invoke(i);
                
            }
            if (Input.GetKeyUp(KeyCode.Alpha1 + i))
            {
                OnAlphaKeyUp?.Invoke();

            }
            if (Input.GetKey((KeyCode.Alpha1 + i)))
            {
                OnAlphaKey?.Invoke(i);
            }
        }
    }
}