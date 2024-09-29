using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InitialFinalScale
{
    public Vector3 initialValue { get; private set; }
    public Vector3 finalValue = new Vector3(0.5f, 0.5f, 0.5f);

    public InitialFinalScale(Vector3 initialValue)
    {
        this.initialValue = initialValue;
    }

    public void FlipValues()
    {
        (initialValue, finalValue) = (finalValue, initialValue);
    }
}

public class ScaleDanceFigure : DanceFigure
{
    [SerializeField] InitialFinalScale initialFinalScale;
    [SerializeField] float timeScaling = 2.0f;
    private float elapsedTime = 0.0f;
    

    protected override void Start()
    {
        base.Start();
        initialFinalScale = new InitialFinalScale(transform.localScale);
    }

    protected override void SpecialDance()
    {
        elapsedTime += Time.deltaTime;
        transform.localScale = Vector3.Lerp(initialFinalScale.initialValue, initialFinalScale.finalValue, (elapsedTime / timeScaling));
        CheckEndTimeScaling();
    }

    void CheckEndTimeScaling()
    {
        if (elapsedTime >= timeScaling)
        {
            initialFinalScale.FlipValues();
            elapsedTime = 0.0f;
        }
    }
}
