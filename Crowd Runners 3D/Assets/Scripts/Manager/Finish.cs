using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
 public SpawnCharactersInCircle _spawnCharactersInCircle;

 void Start()
 {
   _spawnCharactersInCircle = GameObject.Find("Spawn blue characters").GetComponent<SpawnCharactersInCircle>();
 }

 void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player")
      {
//          GameManager.instance.EndGame("Win");
          _spawnCharactersInCircle.WhenGameEnd();
      }
    }
}
