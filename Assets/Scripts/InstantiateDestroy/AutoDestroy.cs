using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        CheckKeyDownDestroy.OnDestroy += SelfDestroy;
    }

    void OnDestroy()
    {
        CheckKeyDownDestroy.OnDestroy -= SelfDestroy;
        Debug.Log($"Component AutoDestroy of {name} is being destroyed.");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
