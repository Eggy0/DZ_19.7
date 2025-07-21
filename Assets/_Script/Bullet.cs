using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    private Rigidbody rb;
    private (float current, float max) lifetime = (0f, 3f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * shootSpeed;
    }

    private void Update()
    {
        lifetime.current += Time.deltaTime;
        if (lifetime.current >= lifetime.max || GameManager.player == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Bullet collision with {collision.gameObject.name}");
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("With enemy");
            Destroy(gameObject);
        }
    }
}

