using UnityEngine;

public class ResetZone : MonoBehaviour
{
    OnTriggerEnter(Collider other)
    {
        var resettable = other.GetComponent<IResettable>();
        if (resettable != null)
        {
            resettable.ResetToCheckpoint();
        }
    }
}
