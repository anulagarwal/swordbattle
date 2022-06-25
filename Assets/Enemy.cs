using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float health;
    [SerializeField] bool isShooting;
    [SerializeField] bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DestroySelf()
    {
        GameManager.Instance.RemoveActiveEnemy(this);
        Destroy(gameObject);
        //Instead grey out enemy and ragdoll
    }
}
