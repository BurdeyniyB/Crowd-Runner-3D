using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCharactersInCircle : MonoBehaviour
{
   public static SpawnCharactersInCircle instance;
	void Awake () {
        if (instance == null)
            instance = this;
	}

    public GameObject characterPrefab;
    public List<GameObject> child;
    public int numberOfCharacters;
    public float spawnRadius;
    bool start;
    bool finish;
    public float deltaY;
    public TextMeshProUGUI CountCharacters;

    void Start()
    {
        numberOfCharacters--;
        SpawnCharactersCircle(numberOfCharacters);
        SpawnCharacterAtCenter();
    }

    void Update()
    {
       numberOfCharacters = child.Count;
       CountCharacters.text = child.Count.ToString();

       RemoveFromList();
       End();
       CoinManager.instance.SetCoin(child.Count);
    }

    void SpawnCharacterAtCenter()
    {
        child.Add(Instantiate(characterPrefab, transform.position, Quaternion.identity, transform));
        numberOfCharacters++;
    }

    void SpawnCharactersCircle(int Characters)
    {
        Vector3 center = transform.position;

        // создаем заданное количество персонажей
        for (int i = 0; i < Characters; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            Vector3 characterPosition = new Vector3(center.x + randomPosition.x, center.y, center.z + randomPosition.y);

            child.Add(Instantiate(characterPrefab, characterPosition, Quaternion.identity, transform));
            if(start)
           {
             child[child.Count-1].GetComponent<Animator>().Play("run");
           }
        }

        MoveObjectWithTouch.instance.GetRadius(spawnRadius);
    }

    public void AddCharacter(string type, int count)
    {
       if(type == "addition")
       {
          SpawnCharactersCircle(count);
          numberOfCharacters += count;
       }

       if(type == "multiplication")
       {
          SpawnCharactersCircle(numberOfCharacters * count - numberOfCharacters);
          numberOfCharacters = numberOfCharacters * count;
       }
    }

    public void WhenGameStart()
    {
      start = true;
      foreach(GameObject go in child)
      {
        go.GetComponent<Animator>().Play("run");
      }
    }

    public void WhenGameEnd()
    {
//      foreach(GameObject go in child)
//      {
//        go.GetComponent<Animator>().Play("Idle");
//      }

        finish = true;
        CountCharacters.gameObject.SetActive(false);

        for(int i = 0; i < child.Count; i++)
        {
          child[i].transform.position += new Vector3(-child[i].transform.position.x, deltaY * i, 0);
          child[i].transform.position = new Vector3(transform.position.x, child[i].transform.position.y, transform.position.z);
        }
    }

    void RemoveFromList()
    {
       for(int i = 0; i < child.Count; i++)
       {
         if(child[i] == null)
         {
           child.RemoveAt(i);
         }
       }
    }

    void End()
    {
       if(child.Count <= 0)
       {
         if(start && !finish)
         {
           GameManager.instance.EndGame("Lose");
         }

         Destroy(this.gameObject);
       }

       if(transform.childCount <= 1)
       {
           if(start && finish)
           {
             GameManager.instance.EndGame("Win");
           }
       }
    }

}
