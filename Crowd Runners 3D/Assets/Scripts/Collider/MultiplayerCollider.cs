using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplayerCollider : MonoBehaviour
{
  public int multiCount;
  public TextMeshProUGUI Count;

  void Start()
  {
    Count.text = "x " + multiCount.ToString();
  }

  void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.tag == "Player")
      {
         CoinManager.instance.Multiplayer(multiCount);
         col.gameObject.transform.SetParent(transform);
      }
    }
}
