using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private SkinManager skinManager;
  private Vector3 velocity = Vector3.zero;
  private Vector3 direction;
  private Renderer playerBody;
  private const string SelectedSkin = "SelectedSkin";

  void Start()
  {
    playerBody = GetComponent<Renderer>();
    Debug.Log(" skinManager.GetSelectedSkin().material = " + skinManager.GetSelectedSkin().material);
    playerBody.material = skinManager.GetSelectedSkin().material;
  }

  void Update()
  {
      playerBody.material = skinManager.GetSelectedSkin().material;
  }
}
