using UnityEngine;

public class grappler : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Vector2 grapplePoint;
    [SerializeField] private float slowBy;
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
            playerMovement.grappling = true;
            _lineRenderer.SetPosition(0, grapplePoint);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = grapplePoint;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else
        {
            playerMovement.grappling = false;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
    }

    public void setGrapplePoint(Vector2 point)
    {
        grapplePoint = point;
    }
}
