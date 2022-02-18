using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    [SerializeField] private grappler grappler;

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grappler.setGrapplePoint(transform.position);
            grappler.setEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            grappler.setEnabled(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
