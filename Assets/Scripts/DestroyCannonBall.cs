using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonBall : MonoBehaviour
{
    
  private float zRange = 150.0f;
  private float destroyTime = 0.5f;

  void Update()
  {

    if(transform.position.z >= zRange)
    {
 
      Destroy(gameObject);

    } else {

      Destroy(gameObject, destroyTime);

    }
  }
}
