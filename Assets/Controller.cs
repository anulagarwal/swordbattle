using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [Header ("Component References")]
    [SerializeField] private List<Vector2> followPath = new List<Vector2>();
    [SerializeField] bool isDrawn;
    [SerializeField] bool isMoved;

    public int currentWayPoint = 0;
    public Vector3 targetWayPoint;

    public float speed = 4f;


    public static Controller Instance = null;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            // check if we have somewere to walk
            if (currentWayPoint < followPath.Count)
            {
                if (targetWayPoint == null)
                    targetWayPoint = followPath[currentWayPoint];
                walk();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMoved)
            {
                DrawingManager.Instance.TriggerMouseUp();
                SwordController.Instance.gameObject.SetActive(false);
                isMoved = true;
            }
        }
        if (Input.GetMouseButton(0) && isMoved)
        {
            walk();
        }
    }

    void walk()
    {
        // rotate towards the target
      //  transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);

        if (transform.position == targetWayPoint)
        {
            currentWayPoint++;
            targetWayPoint = followPath[currentWayPoint];
        }
    }
    public void AddFollowPath(List<Vector2> follow)
    {
        followPath.Clear();
        followPath = follow;
        targetWayPoint = followPath[0];
    }
}
