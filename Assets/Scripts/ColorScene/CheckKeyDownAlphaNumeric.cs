using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownAlphaNumeric : MonoBehaviour
{
    public delegate void AlphaHandler(int index);
    public static event AlphaHandler OnAlphaKeyDown;
    public static event AlphaHandler OnAlphaKey;

    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 1; i <= keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                OnAlphaKeyDown?.Invoke(i - 1);
            }
            if (Input.GetKey((KeyCode.Alpha0 + i)))
            {
                OnAlphaKey?.Invoke(i - 1);
            }
        }
    }
}
