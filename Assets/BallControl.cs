using UnityEngine;
using System.Collections;

public class BallControl: MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 vel;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void ResetBall()
    {
        vel = Vector2.zero;
        rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0.4f, -0.4f));
        }
        else
        {
            rb2d.AddForce(new Vector2(-0.4f, 0.4f));
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }

    }
}
