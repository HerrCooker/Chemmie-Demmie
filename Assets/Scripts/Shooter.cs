using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 start = transform.position;
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //WICHTIG!! camera.main für Verweis auf Hauptkamera
            Vector3 direction = (target - start).normalized;    //normalized setzt Richtungsvektor auf 1



            Vector3 pos = start + direction;
            GameObject g = Instantiate(Projectile, pos, Quaternion.identity);
            g.GetComponent<Rigidbody>().AddForce(direction * 800);

        

        }
    }
}
