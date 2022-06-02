using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos_Fast : MonoBehaviour
{
    public Transform obj;
    public bool ps = true;
    public bool rot = true;
    public float px, py, pz;
    public float rx, ry, rz;
    void Update()
    {
        if (ps)
        {
            transform.position = new Vector3(obj.position.x + px, obj.position.y + py, obj.position.z + pz);
        }
        if (rot)
        {
            transform.localRotation = obj.localRotation;
            //transform.rotation = Quaternion.Euler(obj.rotation.x+rx, obj.rotation.y+ ry, obj.rotation.z+ rz);
        }
    }
}
