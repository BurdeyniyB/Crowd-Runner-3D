using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderBoxCountPlus : MonoBehaviour
{
   private SpawnCharactersInCircle _spawnCharactersInCircle;
   public ColliderBoxCountPlus _colliderBoxCountPlus;
   public bool addition;
   public bool multiplication;
   public int Count;
   public string BlockCountString;
   public TextMeshProUGUI TextMPro;
   private bool called;

   void Start()
   {
     _spawnCharactersInCircle = GameObject.Find("Spawn blue characters").GetComponent<SpawnCharactersInCircle>();
     TextMPro.text = BlockCountString;
   }

     void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player" && !called)
      {
        called = true;
        
        if(addition)
        {
          Debug.Log("addition");
          _spawnCharactersInCircle.AddCharacter("addition", Count);
          Destroy(_colliderBoxCountPlus);
          Destroy(this.gameObject);
        }

        if(multiplication)
        {
          Debug.Log("multiplication");
          _spawnCharactersInCircle.AddCharacter("multiplication", Count);
          Destroy(_colliderBoxCountPlus);
          Destroy(this.gameObject);
        }
      }
    }
}
