using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private GameObject notificationText;
    [SerializeField] [HideInInspector] private bool canOpen;
    [SerializeField] [HideInInspector] private bool inTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Unlock()
    {
        canOpen = true;
        Debug.Log($"Door {gameObject.name} can be opened now");
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        Debug.Log("Enter door trigger");
        if (other.gameObject.TryGetComponent(out Player player) && canOpen)
        {
            notificationText.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && inTrigger)
        {
            transform.Rotate(0, 70, 0);
            notificationText.SetActive(false);
            canOpen = false; //Because it's already open
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        Debug.Log("Exit door trigger");
        if (notificationText.activeSelf)
        {
            notificationText.SetActive(false);
        }

    }
}
