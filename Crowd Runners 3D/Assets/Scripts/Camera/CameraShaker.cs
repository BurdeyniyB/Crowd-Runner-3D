using System;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
     [SerializeField] private Transform _camera;
     [SerializeField] private Vector3 _posStrenght;

     private static event Action Shake;

     public static void Invoke(){
        Shake?.Invoke();
     }

     private void OnEnable()
      {
        Shake += CameraShake;
      }
     private void OnDisable()
      {
        Shake -= CameraShake;
      }

     private void CameraShake()
     {
       _camera.DOComplete();
       _camera.DOShakePosition(0.5f, _posStrenght);
     }
}
