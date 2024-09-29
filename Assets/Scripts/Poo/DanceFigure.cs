using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DanceFigure : MonoBehaviour
{
    [SerializeField] DirectorGroupDance myDirectorGroupDance;
    [SerializeField] float speedMovement = 1;
    Vector3 destination;

    private void Awake()
    {
        if (myDirectorGroupDance == null)
        {
            Debug.LogError($"The GameObject '{gameObject.name}' does not have a DirectorGroupDance assigned. It will be destroyed.");
            Destroy(gameObject); // Destruye el GameObject si el componente necesario es nulo
        }
    }

    protected virtual void Start()
    {
        destination = transform.position;
        myDirectorGroupDance.OnNewDestination += SetDestination;
    }

    private void OnDestroy()
    {
        if (myDirectorGroupDance != null)
        {
            myDirectorGroupDance.OnNewDestination -= SetDestination;
        }
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
