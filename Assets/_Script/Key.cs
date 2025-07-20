using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private LockedDoor doorToUnlock;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            doorToUnlock.Unlock();
            Destroy(gameObject);
        }
    }
}
