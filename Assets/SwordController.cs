using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwordController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float timeScale;
    [SerializeField] float throwForce;
    [SerializeField] int maxHealth;

    int health;


    [Header("Component References")]
    [SerializeField] GameObject arrow;
    [SerializeField] Arrow arr;
    [SerializeField] Rigidbody rb;
    [SerializeField] Image bar;
    [SerializeField] Controller c;


    public static SwordController Instance = null;


    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            arrow.SetActive(true);
            //Start direction shoot

        }

        if (Input.GetMouseButton(0))
        {
            Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //print(dir);

            float angle = Mathf.Atan2(UIManager.Instance.GetJoystick().Vertical, UIManager.Instance.GetJoystick().Horizontal) * Mathf.Rad2Deg;
            arrow.transform.position = new Vector2(transform.position.x, transform.position.y);
            arrow.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arr.SetArrowPower(Mathf.Abs(UIManager.Instance.GetJoystick().Vertical) + Mathf.Abs(UIManager.Instance.GetJoystick().Horizontal));
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //arr.transform.localPosition = new Vector3();
            //Set direction

        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1f;
            rb.isKinematic = false;
            arrow.SetActive(false);
            rb.velocity = Vector3.zero;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

            DrawingManager.Instance.TriggerMouseDown();
            rb.AddForce(transform.right * throwForce, ForceMode.Impulse);
            c.enabled = true;
            this.enabled = false;
           // gameObject.SetActive(false);
            //Shoot on direction
        }
    }

    public void ReduceHealth(int val)
    {
        health =  health -val;
        float g = ((float)health /(float) maxHealth);
        print(health);
        print(g);
        bar.fillAmount = g;
        if (health <= 0)
        {
            //Update Canvas

            //GameOver
        }
    }
}
