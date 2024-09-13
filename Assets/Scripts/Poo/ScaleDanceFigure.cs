using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDanceFigure : DanceFigure
{
    [SerializeField] float duration = 2.0f;
    [SerializeField] Vector3 minimumSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 originalSize;
    private bool shrinking = true; 
    private float elapsedTime = 0.0f;

    protected override void Start()
    {
        base.Start();
        originalSize = transform.localScale;
    }

    protected override void SpecialDance()
    {
        elapsedTime += Time.deltaTime;

        if (shrinking)
        {
            Shrink();
            CheckStateChange();
        }
        else
        {
            Restore();
            CheckStateChange();
        }
    }

    void Shrink()
    {
        float factor = elapsedTime / duration;
        transform.localScale = Vector3.Lerp(originalSize, minimumSize, factor);
    }

    void Restore()
    {
        float factor = elapsedTime / duration;
        transform.localScale = Vector3.Lerp(minimumSize, originalSize, factor);
    }

    void CheckStateChange()
    {
        if (elapsedTime >= duration)
        {
            shrinking = !shrinking;
            elapsedTime = 0.0f;
        }
    }
}
