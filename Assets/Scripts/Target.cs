using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  private float rotationTime = 1.0f;
  private float metalHitVolume = 0.3f;
  private AudioSource audioSource;
  public AudioClip metalHit;
  private GameManager gameManager;

  void Awake()
  {

    audioSource = GetComponent<AudioSource>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

  }

  private void OnCollisionEnter(Collision collision)
  {

    if(collision.gameObject.CompareTag("CannonBall"))
    {
           
      Debug.Log("Target has collided with : " + collision.gameObject.name);
      PlayMetalHitSound();
      StartCoroutine(LiftTarget());
      gameManager.score++;
      gameManager.UpdateScore();

    }
  }

  void PlayMetalHitSound()
  {

    audioSource.PlayOneShot(metalHit, metalHitVolume);

  }

  IEnumerator LiftTarget()
  {

    transform.rotation = Quaternion.Euler(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);

    yield return new WaitForSeconds(rotationTime);

    transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, transform.eulerAngles.z);

  }
}
