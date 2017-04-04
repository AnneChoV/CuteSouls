using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public int damageToGive;

    public Vector3 UserPosition;
    public Transform UserTransform;
    public Vector3 targetPosition;
    public float projectileSpeed;

    public float damage;    //Needs to be set somewhere.

    private Rigidbody2D myRigidbody;

    SpriteRenderer spriteRenderer;
    Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        
        UserTransform = transform.parent.parent.GetComponent<Transform>();
        UserPosition = UserTransform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();

        velocity = (targetPosition - transform.position);
        velocity.Normalize();
        Debug.Log("velocity x: " + velocity.x);
        if (velocity.x < 0)
        {
            spriteRenderer.flipX = true;    //CHANGE THIS TO FLIP IT
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = velocity * 30.0f;
        myRigidbody.angularVelocity = rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag.Equals(transform.parent.parent.tag)))
        {
            CharacterStats colliderStats = collision.GetComponent<CharacterStats>();
            if (colliderStats)
            {
                colliderStats.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}
