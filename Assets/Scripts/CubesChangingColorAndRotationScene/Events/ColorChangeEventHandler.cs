using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeEventHandler : MonoBehaviour
{
    [SerializeField] private ChangeMaterialColor changeMaterialColor;
    private void Start()
    {
        CheckKeyDownAlphaNumeric.AlphaKeyDown += changeMaterialColor.SetColor;
    }

    private void OnDestroy()
    {
        CheckKeyDownAlphaNumeric.AlphaKeyDown -= changeMaterialColor.SetColor;
    }
}
