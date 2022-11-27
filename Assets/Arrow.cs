using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float posYOffset;
    [SerializeField] private float maxPower = 5f;
    [SerializeField] private float minPower = 1.5f;



    [Header("Component References")]
    [SerializeField] private GameObject arrowHead;
    [SerializeField] private GameObject arrowBody;

    Vector3 baseOriginalScale;
    Vector3 baseOriginalPos;


    // Start is called before the first frame update
    void Start()
    {
        baseOriginalScale = arrowBody.transform.localScale;
        baseOriginalPos = arrowBody.transform.localPosition;
        transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetArrowPower(float power)
    {

        //Resize(arrowBody.transform, 5f, new Vector3(0f, 0f, 1f)); // You can use Vector3.forward instead
        transform.localPosition = new Vector3(1.5f + (power*maxPower * 0.7f), transform.localPosition.y, transform.localPosition.z);

        arrowBody.transform.localScale = new Vector3(baseOriginalScale.x, Mathf.Abs(baseOriginalScale.y*power*maxPower), baseOriginalScale.z);

        arrowBody.transform.localPosition = new Vector3(baseOriginalPos.x, -(arrowBody.transform.localScale.y * 2f) + (baseOriginalScale.y * 2) + (arrowBody.transform.localScale.y * 0.4f), baseOriginalPos.z);
    }

    public void Resize(Transform t, float amount, Vector3 direction)
    {
        transform.position += direction * amount / 2; // Move the object in the direction of scaling, so that the corner on ther side stays in place
        transform.localScale += direction * amount; // Scale object in the specified direction
    }
}
