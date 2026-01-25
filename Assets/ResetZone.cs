using UnityEngine;

public class ResetZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CheckpointManager.TeleportPlayerToCheckpoint(other.gameObject);
        }
    }
}
