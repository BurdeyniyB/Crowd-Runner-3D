using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    public bool shaker;
    void Update()
    {
       if(target != null && shaker){
        transform.position = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z);
        }
    }

    public void Change()
    {
       if(shaker)
       {
         shaker = false;
       }
       else
       {
         shaker = true;
       }
    }
}