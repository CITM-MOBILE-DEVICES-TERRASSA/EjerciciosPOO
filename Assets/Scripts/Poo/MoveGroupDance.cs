using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroupDance : MonoBehaviour
{
    [SerializeField] DanceFigure[] danceFigures;
    void Start()
    {
        InvokeRepeating("GenerarRandomVector3", 0.0f, 1.0f);
    }

    void GenerarRandomVector3()
    {
        int x = Random.Range(-1, 2);
        int y = Random.Range(-1, 2);
        int z = Random.Range(-1, 2);

        Vector3 randomVector = new Vector3(x, y, z);
        foreach (var danceFigure in danceFigures)
        {
            danceFigure.SetDestination(randomVector);
        }
    }
}
