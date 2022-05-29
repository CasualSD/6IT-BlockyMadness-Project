using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask isGrappleable;
    public Transform grappleTip, Camera, player;
    private bool grappling = false;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private float _spring = 4.5f;
    [SerializeField] private float _damper = 7f;
    [SerializeField] private float _massScale = 4.5f;
    private SpringJoint joint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

        if (Input.GetMouseButton(0) && grappling)
        {
            GrappleStamina.instance.UseStamina(1);
        }
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin: Camera.position, direction: Camera.forward, out hit, maxDistance, isGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(a: player.position, b: grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = _spring;
            joint.damper = _damper;
            joint.massScale = _massScale;

            lr.positionCount = 2;

            grappling = true;
        }
    }

    void DrawRope()
    {
        if (!joint)
        {
            return;
        }
        lr.SetPosition(index: 0, grappleTip.position);
        lr.SetPosition(index: 1, grapplePoint);
    }

    public void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
        grappling = false;
    }

    public bool IsGrappling()
    {
        return joint != null;
    }
    
    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

}
