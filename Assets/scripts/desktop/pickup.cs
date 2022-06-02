using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public Camera camera;
    public float distance;
    public float speed;
    public bool is_drag;
    public Transform obj;
    public float offset;
    bool active;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            active = !active;
        }
        if (active && !is_drag)
        {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "can_pick")
                {
                    is_drag = true;
                    obj = hit.transform;
                    obj.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    obj.gameObject.layer = 2;
                    obj.parent = gameObject.transform;
                }
            }
        }
        if (is_drag && obj != null)
        {
            
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
            var targetPoint = ray.GetPoint(distance);
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(gameObject.transform.position, hit.point) < distance+0.3)
                {
                    var end_pos = new Vector3(hit.point.x, hit.point.y+obj.transform.localScale.y/2, hit.point.z);
                    obj.position = Vector3.Lerp(obj.position, end_pos, speed * Time.deltaTime);
                }
                else
                {
                    obj.position = Vector3.Lerp(obj.position, targetPoint, speed * Time.deltaTime);
                }
            }
            else
            {
                obj.position = Vector3.Lerp(obj.position, targetPoint, speed * Time.deltaTime);
            }
            if (Vector3.Distance(obj.transform.position, targetPoint) > offset)
            {
                obj.gameObject.GetComponent<Rigidbody>().useGravity = true;
                obj.gameObject.layer = 0;
                is_drag = false;
                obj.parent = null;
                obj = null;
            }
        }
        if (!active && is_drag)
        {
            obj.gameObject.GetComponent<Rigidbody>().useGravity = true;
            obj.gameObject.layer = 0;
            is_drag = false;
            obj.parent = null;
            obj = null;
        }
    }
}
