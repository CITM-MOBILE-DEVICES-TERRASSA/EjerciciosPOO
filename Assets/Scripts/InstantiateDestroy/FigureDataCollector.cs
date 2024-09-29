using UnityEngine;

public class FigureDataCollector : MonoBehaviour
{
    FigureData figureData;
    void Awake()
    {
        figureData = new FigureData(name, transform.rotation.x, transform.localScale);
    }

    void OnDestroy()
    {
        Debug.Log($"Component FigureConfigurator of {name} is being destroyed.");
    }
}
