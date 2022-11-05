using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShooter : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    float timer = 0;




    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position;
        Vector3 start = transform.position;
        Vector3 direction = (target - start).normalized;


        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer = 0;
            GameObject bullet = Instantiate(projectile, start, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(direction * 600);
        }
    }
}
