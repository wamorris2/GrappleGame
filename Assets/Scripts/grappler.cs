using UnityEngine;

public class grappler : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint;
    [SerializeField] private PlayerMovement playerMovement;
    public Vector2 grapplePoint;
    public bool _enabled;

    // Start is called before the first frame update
    void Start()
    {
        _enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enabled)
        {
            playerMovement.enabled = false;
            _lineRenderer.SetPosition(0, grapplePoint);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = grapplePoint;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else
        {
            playerMovement.enabled = true;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
    }

    public void setGrapplePoint()
    {
        
    }
}
