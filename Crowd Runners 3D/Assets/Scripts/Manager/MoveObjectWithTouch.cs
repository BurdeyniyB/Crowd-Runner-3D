using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectWithTouch : MonoBehaviour
{
public static MoveObjectWithTouch instance;

void Awake()
{
    if (instance == null)
        instance = this;
}

[SerializeField] private GameObject Player;
[SerializeField] private Transform PosRight;
[SerializeField] private Transform PosLeft;

public float Lerp;
public float speed;
private float PosX;

private float radius;

bool end;

void Update()
{
    Lerp += Time.deltaTime * speed;

    if (Input.GetMouseButton(0) && !end)
    {
        if ((PosX + Input.GetAxis("Mouse X")) < (PosRight.transform.position.x - radius) && (PosX + Input.GetAxis("Mouse X")) > (PosLeft.transform.position.x + radius))
        {
            GameManager.instance.StartGame();
            PosX = PosX + Input.GetAxis("Mouse X");
        }
        Player.transform.position = Vector3.Lerp(Player.transform.position, new Vector3(PosX, transform.position.y, transform.position.z), Lerp);
    }
}

public void EndGame()
{
    end = true;
}

public void GetRadius(float r)
{
    radius = r;
}
}