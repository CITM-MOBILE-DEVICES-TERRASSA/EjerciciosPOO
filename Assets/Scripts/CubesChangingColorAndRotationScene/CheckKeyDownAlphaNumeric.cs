using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckKeyDownAlphaNumeric : MonoBehaviour
{
    public static event Action<int> AlphaKey;
    public static event Action<int> AlphaKeyDown;
    public static event Action AlphaKeyUp;

    [Range(0, 5)][SerializeField] int keysCheck;

    private void Update()
    {
        for (int i = 0; i < keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                AlphaKeyDown?.Invoke(i);
                
            }
            if (Input.GetKeyUp(KeyCode.Alpha1 + i))
            {
                AlphaKeyUp?.Invoke();

            }
            if (Input.GetKey((KeyCode.Alpha1 + i)))
            {
                AlphaKey?.Invoke(i);
            }
        }
    }
}