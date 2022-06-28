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
    public void DestroySelf()
    {
        GameManager.Instance.RemoveActiveEnemy(this);
        anim.Play("death");
        TurnToGray();
       // Destroy(gameObject);
        //Instead grey out enemy and ragdoll
    }
}
