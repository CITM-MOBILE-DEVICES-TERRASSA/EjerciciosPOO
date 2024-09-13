using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DanceFigure : MonoBehaviour
{
    [SerializeField] float velocity = 1;
    Vector3 destination;

    protected virtual void Start()
    {
        destination = transform.position;
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination += destination;
    }

    private void Update()
    {
        SpecialDance();
        MoveFigure();
    }

    private void MoveFigure()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, velocity * Time.deltaTime);
    }

    protected abstract void SpecialDance();
}
