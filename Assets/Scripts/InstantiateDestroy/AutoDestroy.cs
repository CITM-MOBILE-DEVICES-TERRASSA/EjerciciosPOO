using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Start()
    {
        CheckKeyDownD.DKeyDown += SelfDestroy;
    }

    private void OnDestroy()
    {
        CheckKeyDownD.DKeyDown -= SelfDestroy;
        Debug.Log($"Component AutoDestroy of {name} is being destroyed.");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
