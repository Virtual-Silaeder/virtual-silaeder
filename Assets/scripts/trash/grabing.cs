using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabing : MonoBehaviour
{
    public Camera camera;
    public float distance;
    public float speed;
    public bool is_drag;
    public float range;
    public Transform obj;
    public GameObject Gpoint;
    Rigidbody Rpoint;
    private void Start()
    {
        Rpoint = Gpoint.GetComponent<Rigidbody>();
        RaycastHit hit;
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !is_drag)
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "can_open" && Vector3.Distance(Gpoint.transform.position, hit.transform.position) < range)
                {
                    is_drag = true;
                    obj = hit.transform;
                    obj.GetComponent<Rigidbody>().useGravity = false;
                    //obj.gameObject.AddComponent<SpringJoint>();
                    obj.GetComponent<SpringJoint>().connectedBody = Rpoint;
                }
            }
        }
        if (is_drag)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            var targetPoint = ray.GetPoint(distance);
            Gpoint.transform.position = targetPoint;
        }
        if (Input.GetMouseButtonUp(0) && is_drag)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<SpringJoint>().connectedBody = null;
            //Destroy(obj.gameObject.GetComponent<SpringJoint>());
            is_drag = false;
            obj = null;
        }
    }
}
