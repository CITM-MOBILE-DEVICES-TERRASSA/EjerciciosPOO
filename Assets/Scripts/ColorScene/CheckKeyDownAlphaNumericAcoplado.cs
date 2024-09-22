using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckKeyDownAlphaNumericAcoplado : MonoBehaviour
{
    [SerializeField] UnityEvent<int> OnAlphaKey;
    #region gameEvent no se usa
    [SerializeField] GameEvent gameEvent;
    #endregion
    [SerializeField] RotateObject[] rotateObjects;
    [Range(0, 5)][SerializeField] int keysCheck;

    void Update()
    {
        for (int i = 1; i <= keysCheck; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                #region gameEvent no se usa
                //gameEvent!.TriggerEvent(i - 1);
                #endregion
                OnAlphaKey!.Invoke(i - 1);
            }
            if (Input.GetKeyUp(KeyCode.Alpha0 + i))
            {
                foreach (var rotateObject in rotateObjects)
                {
                    rotateObject.StopToRotation();
                }       
            }
            if (Input.GetKey((KeyCode.Alpha0 + i)))
            {
                foreach (var rotateObject in rotateObjects)
                {
                    rotateObject.InputToRotation(i - 1);
                }
            }
        }
    }
}
