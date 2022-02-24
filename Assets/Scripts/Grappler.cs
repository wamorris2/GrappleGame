using UnityEngine;

public class Grappler : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Vector2 grapplePoint;
    [SerializeField] private float slowBy;
    [SerializeField] private bool pulling;
    [SerializeField] private bool grappling;
    [SerializeField] private float pullSpeed;

    // Start is called before the first frame update
    void Start()
    {
        grappling = false;
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && grappling)
        {
            grappling = true;

            _lineRenderer.SetPosition(0, grapplePoint);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = grapplePoint;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            grappling = false;
            playerMovement.grappling = false;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
            pulling = true;
        if (Input.GetKeyUp(KeyCode.Mouse1))
            pulling = false;

        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(0, grapplePoint);
            _lineRenderer.SetPosition(1, transform.position);
            float dist = Vector2.Distance(transform.position, grapplePoint);
            if (dist != _distanceJoint.distance)
            {
                _distanceJoint.distance = dist;
            }
        }
    }

    private void FixedUpdate()
    {
        if (grappling && pulling)
        {
            _distanceJoint.distance -= pullSpeed;
        }


    }

    public void Propel()
    {
        Vector2 dir = _distanceJoint.connectedAnchor;
        dir.Normalize();
        playerMovement.Propel(dir);
    }

    public bool isGrappling()
    {
        return grappling;
    }

    public void setGrapplePoint(Vector2 point)
    {
        grapplePoint = point;
        grappling = true;
    }
}