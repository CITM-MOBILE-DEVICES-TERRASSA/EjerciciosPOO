using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeyDownDestroy : MonoBehaviour
{
    public delegate void DestroyHandler();
    public static event DestroyHandler OnDestroy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("pulsa D");
            OnDestroy?.Invoke();
        }
    }
}
