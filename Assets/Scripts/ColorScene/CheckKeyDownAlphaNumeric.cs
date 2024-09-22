using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckKeyDownAlphaNumeric : MonoBehaviour
{
    public delegate void AlphaHandler(int index);
    public static event AlphaHandler OnAlphaKey;
    public static event Action<int> OnAlphaKeyDown;
    public static event Action OnAlphaKeyUp;

    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 1; i <= keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                OnAlphaKeyDown?.Invoke(i - 1);
                
            }
            if (Input.GetKeyUp(KeyCode.Alpha0 + i))
            {
                OnAlphaKeyUp?.Invoke();

            }
            if (Input.GetKey((KeyCode.Alpha0 + i)))
            {
                OnAlphaKey?.Invoke(i - 1);
            }
        }
    }
}