using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureFigure : MonoBehaviour
{
    ConfigFigure myConfigFigure;
    void Start()
    {
        myConfigFigure = new ConfigFigure(gameObject.name);
    }
    void OnDestroy()
    {
        Debug.Log($"ConfigureFigure: {gameObject.name} is being destroyed.");
    }
}
