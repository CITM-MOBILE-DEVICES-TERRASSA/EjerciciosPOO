using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigFigure
{
    string nameFigure;
    public ConfigFigure(string nameFigure)
    {
        this.nameFigure = nameFigure;
        Debug.Log($"Set Figure {nameFigure}");
    }

    ~ConfigFigure()
    {
        Debug.Log($"ConfigFigure for {nameFigure} is being destroyed by GarbageCollector");
    }
}
