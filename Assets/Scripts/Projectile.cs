using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float speed = 20f;

    private new BoxCollider2D collider;
    private Rigidbody2D rb;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Optimized so there aren't continuous physics calculations per frame
        // Old Code:
        // private void Update()
        // transform.position += speed * Time.deltaTime * direction;

        rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();

        if (bunker == null || bunker.CheckCollision(collider, transform.position)) {
            Destroy(gameObject);
        }
    }

}
