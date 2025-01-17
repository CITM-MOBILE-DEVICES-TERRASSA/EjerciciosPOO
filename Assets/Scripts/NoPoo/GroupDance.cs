using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDance : MonoBehaviour
{
    [SerializeField]private float velocity = 1;
    [SerializeField] private GameObject[] danceFigures;
    private Vector3[] destinationFigures;
    [SerializeField] private DanceType[] danceTypeFigures;
    private Vector3 rotateSpeed = new Vector3(0, 100, 0);

    [SerializeField] private float scaleDuration = 2.0f;
    [SerializeField] private Vector3 scaleMinimunSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3[] originalSize;
    private bool[] shrinking;
    private float[] elapsedTime;

    public enum DanceType
    {
        Rotate,
        Scale
    }

    private void Start()
    {
        initFigures();
        InvokeRepeating("GenerarRandomVector3", 0.0f, 1.0f);
    }

    private void initFigures()
    {
        destinationFigures = new Vector3[danceFigures.Length];
        originalSize = new Vector3[danceFigures.Length];
        shrinking = new bool[danceFigures.Length];
        elapsedTime = new float[danceFigures.Length];
        for (int i = 0; i < danceFigures.Length; i++)
        {
            destinationFigures[i] = danceFigures[i].transform.position;
            originalSize[i] = danceFigures[i].transform.localScale;
            shrinking[i] = true;
            elapsedTime[i] = 0.0f;
        }
    }

    private void GenerarRandomVector3()
    {
        int x = UnityEngine.Random.Range(-1, 2);
        int y = UnityEngine.Random.Range(-1, 2);
        int z = UnityEngine.Random.Range(-1, 2);

        Vector3 randomVector = new Vector3(x, y, z);
        for (int i = 0; i < danceFigures.Length; i++)
        {
            destinationFigures[i] += randomVector;
        }
    }

    private void Update()
    {
        SpecialDance();
        MoveFigure();
    }

    private void MoveFigure()
    {
        for (int i = 0; i < danceFigures.Length; i++)
        {
            danceFigures[i].transform.position = Vector3.MoveTowards(danceFigures[i].transform.position, destinationFigures[i], velocity * Time.deltaTime);
        }
    }

    protected void SpecialDance()
    {
        for (int i = 0; i < danceFigures.Length; i++)
        {
            if (danceTypeFigures[i] == DanceType.Rotate)
            {
                danceFigures[i].transform.Rotate(rotateSpeed * Time.deltaTime);
            }
            else if(danceTypeFigures[i] == DanceType.Scale)
            {
                elapsedTime[i] += Time.deltaTime;

                if (shrinking[i])
                {
                    Shrink(i);
                    CheckStateChange(i);
                }
                else
                {
                    Restore(i);
                    CheckStateChange(i);
                }
            }
        }
    }
    private void Shrink(int i)
    {
        float factor = elapsedTime[i] / scaleDuration;
        danceFigures[i].transform.localScale = Vector3.Lerp(originalSize[i], scaleMinimunSize, factor);
    }

    private void Restore(int i)
    {
        float factor = elapsedTime[i] / scaleDuration;
        danceFigures[i].transform.localScale = Vector3.Lerp(scaleMinimunSize, originalSize[i], factor);
    }

    private void CheckStateChange(int i)
    {
        if (elapsedTime[i] >= scaleDuration)
        {
            shrinking[i] = !shrinking[i];
            elapsedTime[i] = 0.0f;
        }
    }
}
