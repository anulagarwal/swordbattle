using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float health;
    [SerializeField] bool isShooting;
    [SerializeField] bool isActive;

    [Header("Component References")]
    [SerializeField] List<SkinnedMeshRenderer> meshes;
    SkinnedMeshRenderer[] m;
    [SerializeField] Animator anim;

    
    

    // Start is called before the first frame update
    void Start()
    {
        m = GetComponentsInChildren<SkinnedMeshRenderer>();

        for(int i = 0; i< m.Length; i++)
        {
            meshes.Add(m[i]);
        }
    }
    private void OnEnable()
    {
        GetComponent<Shooter>().enabled = true;
    }

    private void OnDisable()
    {
        GetComponent<Shooter>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnToGray()
    {
        for (int i = 0; i < m.Length; i++)
        {
            m[i].material.color = Color.gray;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TurnToGray();
        DestroySelf();
    }
    public void DestroySelf()
    {
        GameManager.Instance.RemoveActiveEnemy(this);
        //anim.Play("death");
        Destroy(GetComponent<BoxCollider>());
        Destroy(anim);
        TurnToGray();
       // GetComponent<Shooter>().DetachGun();
       // Destroy(gameObject);
        //Instead grey out enemy and ragdoll
    }
}
