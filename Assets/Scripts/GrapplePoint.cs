using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    [SerializeField] private Grappler grappler;

    private void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grappler.setGrapplePoint(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
        }
    }

    private void OnMouseUp()
    {

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
