using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    [SerializeField] private grappler grappler;
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool pointInCircle(Vector2 point, Vector2 center)
    {
        return Vector2.Distance(point, center) < radius;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (pointInCircle(mousePos, transform.position))
            {
                grappler.grapplePoint = transform.position;
                grappler._enabled = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            grappler._enabled = false;
        }
    }
}
