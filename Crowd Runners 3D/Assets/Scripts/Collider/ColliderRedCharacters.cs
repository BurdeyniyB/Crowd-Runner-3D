using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRedCharacters : MonoBehaviour
{
 public bool Yet_no_called;

 void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player" && !Yet_no_called && !col.gameObject.GetComponent<BlueColliderControler>().Yet_no_called)
      {
          Yet_no_called = true;
          col.gameObject.GetComponent<BlueColliderControler>().Yet_no_called = true;
          Destroy(col.gameObject);
          Destroy(this.gameObject);
      }
    }
}
