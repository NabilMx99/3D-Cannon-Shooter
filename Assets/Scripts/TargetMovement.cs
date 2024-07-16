using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float xRange = 3.0f;
    [SerializeField] private float moveSpeed;
    public bool movingLeft = true;
    private GameManager gameManager;

    void Awake()
    {

      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {

      MoveTarget();
    
    }

    void MoveTarget()
    {
        if(movingLeft && !gameManager.isGameOver)
        {

          transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

          if(transform.position.x <= -xRange)
          {

            movingLeft = false;

          }

        } else {

          if(!gameManager.isGameOver)
          {

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if(transform.position.x >= xRange)
            {

              movingLeft = true;

            }
          }
        }
    }
}
