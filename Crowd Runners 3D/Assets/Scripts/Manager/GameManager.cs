using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;


	void Awake () {
        if (instance == null)
            instance = this;
	}

    public SpawnCharactersInCircle _spawnCharactersInCircle;
    public GameObject Spawn;
    public float speed = 10f;
	bool start;
	bool end;

    public void StartGame()
    {
       if(!start)
       {
         Spawn.GetComponent<Rigidbody>().velocity = transform.forward * speed;
         start = true;
         UIManager.instance.StartGame();
         _spawnCharactersInCircle.WhenGameStart();
       }
    }

    public void EndGame(string type)
    {
       if(!end)
       {
         end = true;
         CameraShaker.Invoke();
         Spawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
         UIManager.instance.EndGame(type);
         MoveObjectWithTouch.instance.EndGame();
       }
    }
}