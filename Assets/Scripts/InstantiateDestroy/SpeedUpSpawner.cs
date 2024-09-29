
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpeedUpSpawner : MonoBehaviour
{
    const float MAXTIMETOSPAWN = 1.0f;
    const int NUMBEROFINTANCES = 20;
    const float MAXROTATION = 360f;
    const float MINSCALE = 0.5f;
    const float MAXSCALE = 2.0f;

    [SerializeField] GameObject GameobjectToInstantiate;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        float timeToSpawn = MAXTIMETOSPAWN / NUMBEROFINTANCES;
        for (int i = 0; i < NUMBEROFINTANCES; i++)
        {
            SetObject(i, InstantiateObject(i));
            yield return new WaitForSeconds(timeToSpawn * (NUMBEROFINTANCES - i));
        }
    }

    GameObject InstantiateObject(int index)
    {
        float positionX = Mathf.Lerp(-NUMBEROFINTANCES, NUMBEROFINTANCES, ((float)index / (NUMBEROFINTANCES - 1)));
        var rotation = new Vector3(Random.Range(0, MAXROTATION), 0, 0);
        return Instantiate(
            GameobjectToInstantiate,
            new Vector3(positionX, 0, 0),
            Quaternion.Euler(rotation));
    }

    void SetObject(int index, GameObject tempObject)
    {
        tempObject.name = tempObject.name.Replace("(Clone)", " ") + index;
        tempObject.transform.localScale = new Vector3(Random.Range(MINSCALE, MAXSCALE), Random.Range(MINSCALE, MAXSCALE), Random.Range(MINSCALE, MAXSCALE));
    }

    #region InstantiatePrimitive no lo uso
    GameObject InstantiatePrimitive(int index)
    {
        float positionX = Mathf.Lerp(-NUMBEROFINTANCES, NUMBEROFINTANCES, ((float)index / (NUMBEROFINTANCES - 1)));
        var rotation = new Vector3(Random.Range(0, MAXROTATION), 0, 0);
        GameObject tempObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tempObject.transform.position = new Vector3(positionX, 0, 0);
        tempObject.transform.rotation = Quaternion.Euler(rotation);
        tempObject.AddComponent<AutoDestroy>();
        tempObject.AddComponent<FigureDataCollector>();
        return tempObject;
    }
    #endregion
}