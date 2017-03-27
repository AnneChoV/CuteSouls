using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed;
    public Player player;
    public float rotationSpeed;
    public int damageToGive;

    private Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        myRigidbody = GetComponent<Rigidbody2D>();

        if (player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        myRigidbody.angularVelocity = rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // do damage to player
            Debug.Log("Hit player");
            Destroy(gameObject);
        }
    }
}
