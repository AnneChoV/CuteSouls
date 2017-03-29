using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [Header("Player")]
    [ReadOnly] public Player player;
    public float playerRange;

    [Header("Enemy")]
    public Transform launchPoint;
    public GameObject enemyProjectile;
    public float moveSpeed;
    [ReadOnly] public bool moveRight;


    [Header("Enemy Wallcheck")]
    public Transform wallCheck;
    public Transform edgeCheck;
    public LayerMask Wall;
    public float wallCheckRadius;

    private bool hittingWall;
    private bool notAtEdge;

    [Header("Projectile")]
    public float waitInbetween; // Delay between each projectile
    private float shotCounter; // Counter for the delay


    private void OnValidate()
    {
       player = FindObjectOfType<Player>();
       shotCounter = waitInbetween;
    }

    // Update is called once per frame
    void Update () {
        PatrolBehaviour();
        ShootAtPlayer();
	}

    void OnSeePlayer()
    {

    }

    void DistanceFromPlayer()
    {

    }

    void PatrolBehaviour()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, Wall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, Wall);

        if (hittingWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void ChaseBehaviour()
    {

    }

    void ShootAtPlayer()
    {
        // Create debug line to see range (Only in Scene Mode)
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        // Tick tock
        shotCounter -= Time.deltaTime;

        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x
            && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            shotCounter = waitInbetween;
        }

        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x
            && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            shotCounter = waitInbetween;
        }
    }

    void MeleeHitPlayer()
    {

    }


}
