using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckKeyDownDestroy.OnDestroy += SelfDestroy;
    }

    void OnDestroy()
    {
        CheckKeyDownDestroy.OnDestroy -= SelfDestroy;
        Debug.Log($"AutoDestroy: {gameObject.name} is being destroyed.");
    }

    public void SelfDestroy()
    {
        Debug.Log($"{gameObject.name} is going to be destroyed.");
        Destroy(gameObject);
    }
}
