using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDanceFigure : DanceFigure
{
    private Vector3 rotateSpeed = new Vector3(0, 100, 0);
    protected override void SpecialDance()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }
}
