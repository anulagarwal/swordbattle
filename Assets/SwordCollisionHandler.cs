using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionHandler : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DestroySelf();
            //Destroy from enemy script
            //Remove from GameManager
            //If all removed, win game
        }

        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<SwordController>().ReduceHealth(1);
            Destroy(collision.gameObject);
        }
    }
}
