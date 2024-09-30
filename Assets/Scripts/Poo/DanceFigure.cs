using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DanceFigure : MonoBehaviour
{
    [SerializeField] private DirectorGroupDance myDirectorGroupDance;
    [SerializeField] private float speedMovement = 1;
    private Vector3 destination;

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
        myDirectorGroupDance.NewDestination += OnNewDestination;
    }

    private void OnDestroy()
    {
        if (myDirectorGroupDance != null)
        {
            myDirectorGroupDance.NewDestination -= OnNewDestination;
        }
    }

    private void OnNewDestination(Vector3 destination)
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
