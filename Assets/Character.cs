using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] Transform character;
    [SerializeField] Transform charPos;

    [SerializeField] GameObject rig;
    [SerializeField] Animator anim;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rig.SetActive(true);
            anim.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {

            transform.position = Vector3.Lerp(transform.position, charPos.position, speed);

        }

        if (Input.GetMouseButtonUp(0))
        {
            //Disable Rig
            //Disable Animator
            rig.SetActive(false);
            anim.enabled = false;
        }
    }
}
