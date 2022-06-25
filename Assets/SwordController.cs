using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float timeScale;
    [SerializeField] float throwForce;


    [Header("Component References")]
    [SerializeField] GameObject arrow;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = timeScale;
            arrow.SetActive(true);
            //Start direction shoot

        }

        if (Input.GetMouseButton(0))
        {
            print(UIManager.Instance.GetJoystick().Horizontal);
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //print(dir);

            float angle = Mathf.Atan2(UIManager.Instance.GetJoystick().Vertical, UIManager.Instance.GetJoystick().Horizontal) * Mathf.Rad2Deg;
            arrow.transform.position = new Vector2(transform.position.x, transform.position.y);
            arrow.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Set direction

        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            arrow.SetActive(false);
            rb.velocity = Vector3.zero;

            rb.AddForce(transform.right * throwForce, ForceMode.Impulse);
            //Shoot on direction
        }
    }
}
