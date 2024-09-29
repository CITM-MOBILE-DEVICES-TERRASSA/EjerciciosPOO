using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DanceFigure : MonoBehaviour
{
    [SerializeField] DirectorGroupDance myDirectorGroupDance;
    [SerializeField] float speedMovement = 1;
    Vector3 destination;

    protected virtual void Start()
    {
        destination = transform.position;
        myDirectorGroupDance.OnNewDestination += SetDestination;
    }

    private void OnDestroy()
    {
        myDirectorGroupDance.OnNewDestination -= SetDestination;
    }

    private void SetDestination(Vector3 destination)
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
        transform.position = Vector3.MoveTowards(transform.position, destination, speedMovement * Time.deltaTime);
    }

    protected abstract void SpecialDance();
}
