using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class RandomDestinationRange
{
    private int minValue, maxValue;
    public RandomDestinationRange(int min, int max)
    {
        this.minValue = min;
        this.maxValue = max;
    }

    public Vector3 NewRandomDestination
    {
        get
        {
            return new Vector3(
                Random.Range(minValue, maxValue),
                Random.Range(minValue, maxValue),
                Random.Range(minValue, maxValue)
            );
        }
    }
}

public class DirectorGroupDance : MonoBehaviour
{
    [SerializeField] private RandomDestinationRange randomDestinationRange = new RandomDestinationRange(-1, 2);
    public event Action<Vector3> NewDestination;

    private void Start()
    {
        InvokeRepeating("DestinationToDance", 0.0f, 1.0f);
    }

    private void DestinationToDance()
    {
        NewDestination?.Invoke(randomDestinationRange.NewRandomDestination);
    }
}
