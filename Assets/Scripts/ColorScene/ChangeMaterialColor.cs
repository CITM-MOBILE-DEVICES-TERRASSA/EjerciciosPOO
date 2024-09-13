using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] Material myMaterial;
    [SerializeField] Color[] colors;
    private void Start()
    {
        CheckKeyDownAlphaNumeric.OnColorChange += SetColor;
    }

    void OnDestroy()
    {
        CheckKeyDownAlphaNumeric.OnColorChange -= SetColor;
        myMaterial.color = Color.white;
    }

    public void SetColor(int index)
    {
        if(index < colors.Length)
        {
            myMaterial.color = colors[index];
        }
        else
        {
            Debug.LogWarning("Index out of range.");
        }
    }
}
