using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooter : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] bool isShooting;

    float startTime;

    [Header("Component References")]
    [SerializeField] Transform target;
    [SerializeField] Transform gun;
    [SerializeField] Image bar;
    [SerializeField] GameObject rig;




    [Header("Shooter")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPos;
    [SerializeField] float speed;
    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {      
        InvokeRepeating("Shoot", 1.0f, interval);  //in one second, start calling this function, every 2secs
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {            
            bar.fillAmount = (Time.time - startTime)/interval;
        }
    }
    public void DetachGun()
    {
        gun.parent = null;
        gun.GetComponent<Rigidbody>().useGravity = true;
        gun.GetComponent<BoxCollider>().enabled = true;
        bar.transform.parent.parent.gameObject.SetActive(false);
        rig.SetActive(false);
        CancelInvoke();
    }

    void Shoot()
    {
        isShooting = true;
        GameObject g = Instantiate(bullet, shootPos.position, Quaternion.identity);     
        Vector3 fromEnemyToPlayer = target.position - shootPos.position;
        startTime = Time.time;
        // Normalize it to length 1
        fromEnemyToPlayer.Normalize();

        // Set the speed to whatever you want:
        Vector2 velocity = fromEnemyToPlayer * speed;

        // Set the rigidbody velocity      
        g.GetComponent<Rigidbody>().velocity = velocity;
    }
}
