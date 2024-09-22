using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeEventHandler : MonoBehaviour
{
    [SerializeField] ChangeMaterialColor changeMaterialColor;
    void Start()
    {
        CheckKeyDownAlphaNumeric.OnAlphaKeyDown += changeMaterialColor.SetColor;
    }

    void OnDestroy()
    {
        CheckKeyDownAlphaNumeric.OnAlphaKeyDown -= changeMaterialColor.SetColor;
    }
}
