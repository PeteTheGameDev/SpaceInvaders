using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private InputManager input;

    public float speed;

    public Projectile laserPrefab;

    private Projectile laser;

    public void Start()
    {
        input = FindObjectOfType<InputManager>();
    }

    public void Update()
    {
        Movement();
        Fire();
    }

    private void Fire()
    {
        if (input.firePressed)
        {
            if (laser == null) 
            {
                laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private void Movement()
    {
        Vector3 position = transform.position;

        // Input
        if (input.left)
        {
            position.x -= speed * Time.deltaTime;
        }
        else if (input.right)
        {
            position.x += speed * Time.deltaTime;
        }

        // Clamp
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);

        // New position
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader")) 
        {
            GameManager.Instance.OnPlayerKilled(this);
        }
    }
}
