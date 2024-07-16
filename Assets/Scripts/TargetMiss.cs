using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMiss : MonoBehaviour
{

  private GameManager gameManager;
  
  void Awake()
  {

    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

  }

  private void OnTriggerEnter(Collider other)
  {

    if(other.CompareTag("CannonBall"))
    {

      Debug.Log("Trigger entered by : " + other.gameObject.name);
      gameManager.score--;
      gameManager.UpdateScore();

    }
  }
}
