using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownAlphaNumeric : MonoBehaviour
{
    public delegate void ColorChangeHandler(int index);
    public static event ColorChangeHandler OnColorChange;
    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 1; i <= keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                OnColorChange?.Invoke(i - 1);
            }
        }
    }
}
