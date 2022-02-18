using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    [SerializeField] private grappler grappler;

    private void OnMouseDown()
    {
        grappler.setGrapplePoint(transform.position);
        grappler._enabled = true;
    }

    private void OnMouseUp()
    {
        grappler._enabled = false;
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
