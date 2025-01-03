using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 6. Shooting Fireballs! -- Just Add Enemies (Unity Tutorial)
    // https://www.youtube.com/watch?v=jjDuE7JXmIc

    public Rigidbody2D projectileRb;
    public float speed;
    //public ProjectileLaunch ProjectileLaunch;
    public float projectileLife;
    public float projectileCount;



    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed; //  projectileRb.position;
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Pew!");
        }
    }

    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2((speed), projectileRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WeakPoint")
        {
            Destroy(collision.gameObject);

        }
        Destroy(gameObject);

    }
}
