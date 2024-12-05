using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


// 6. Shooting Fireballs! -- Just Add Enemies (Unity Tutorial)
// Night Run Studio 
// https://www.youtube.com/watch?v=jjDuE7JXmIc


public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;
    public float speed;

    private bool facingRight = true;
    private float moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;

    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.Alpha1)) // (Input.GetButtonDown("Fire1")) && shootCounter <= 0)
        {
            Shoot(); // Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            Debug.Log("Pew!" + launchPoint.position.x);
        }

        shootCounter -= Time.deltaTime;
    }

    void Shoot()
    {

        Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);  // transform.rotation);
        // projectilePrefab = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        // Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
        // rb.AddForce(launchPoint.right * speed, ForceMode2D.Impulse);
    }
}
