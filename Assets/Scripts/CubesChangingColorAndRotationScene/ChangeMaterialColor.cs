using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private Color[] colors;

    private void OnDestroy()
    {
        myMaterial.color = Color.white;
    }

    public void SetColor(int index)
    {
        if (index >= 0 && index < colors.Length)
        {
            myMaterial.color = colors[index];
        }
        else
        {
            Debug.LogWarning("Index out of range.");
        }
    }
}
