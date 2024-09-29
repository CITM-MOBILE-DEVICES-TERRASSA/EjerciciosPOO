using UnityEngine;

public class FigureData
{
    public string name { get; private set; }
    public float rotationX { get; private set; }
    public Vector3 randomScale { get; private set; }

    public FigureData(string name, float rotationX, Vector3 randomScale)
    {
        this.name = name;
        this.rotationX = rotationX;
        this.randomScale = randomScale;
        Debug.Log($"Figure Data for {this.name} are created");
    }

    ~FigureData()
    {
        Debug.Log($"Figure Data for {name} are destroyed by the GarbageCollector");
    }
}
