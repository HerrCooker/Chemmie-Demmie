using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    public GameObject player;
    public float movSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;
    Collider2D m;
    bool standingOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        m = GetComponent<Collider2D>();
    }

    //Coroutine fürs warten
    IEnumerator skipDown()
    {
        m.enabled = false;
        yield return new WaitForSeconds(0.3f);
        m.enabled = true;
    }

    //Check ob Player auf einer Platform steht durch die er down skippen darf
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            standingOnPlatform = true;
        }
        else
        {
            standingOnPlatform = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 target = player.transform.position;
        Vector3 direction = target - pos;
        direction.Normalize();
        movement = direction;


        float yPos = transform.position.y;
        float yTarget = player.transform.position.y;
        float heightDiff = yTarget - yPos;
        Debug.Log(heightDiff);

        if (heightDiff < -1 && standingOnPlatform == true)
        {
                StartCoroutine(nameof(skipDown));
        }

    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (movSpeed * Time.deltaTime * dir));
    }
}
