using UnityEngine;

public class FigureDataCollector : MonoBehaviour
{
    private FigureData figureData;
    private void Start()
    {
        figureData = new FigureData(name, transform.rotation.x, transform.localScale);
    }

    private void OnDestroy()
    {
        Debug.Log($"Component FigureConfigurator of {name} is being destroyed.");
    }
}
