using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float playerRange;

    public GameObject enemyProjectile;

    public Player player;

    public Transform launchPoint;

    public float waitInbetween;
    private float shotCounter;

    private void OnValidate()
    {
        player = FindObjectOfType<Player>();

        shotCounter = waitInbetween;
    }

    // Update is called once per frame
    void Update () {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
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
}
