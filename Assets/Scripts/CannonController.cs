using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CannonController : MonoBehaviour
{

  private float moveSpeed = 5.5f;
  private float initialXPos = 0.0f;
  private float initialYPos = 0.56f;  
  private float initialZPos = -25.1f;
  private float xRange = 3.0f;
  private float xInput;
  private float cannonBlastVolume = 0.5f;  
  private bool isShooting;
  private AudioSource audioSource;
  public AudioClip cannonBlast;
  private Rigidbody cannonRb;
  private CannonBallLauncher launcher;
  private GameManager gameManager;

  void Awake()
  {

    audioSource = GetComponent<AudioSource>();
    cannonRb = GetComponent<Rigidbody>();
    launcher = GameObject.Find("CannonBallLauncher").GetComponent<CannonBallLauncher>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

  }
    
  void Start()
  {

    transform.position = new Vector3(initialXPos, initialYPos, initialZPos);

    cannonRb.mass = 1000.0f;
    cannonRb.isKinematic = true;
    cannonRb.constraints = RigidbodyConstraints.FreezeRotation;
    cannonRb.interpolation = RigidbodyInterpolation.Interpolate;
        
  }
  void FixedUpdate()
  {

    if(!gameManager.isGameOver)
    {
  
      MoveCannon();

    }
  }

  void Update()
  {
    KeepCannonInBounds();

    if(Input.GetMouseButtonDown(0) && !gameManager.isGameOver)
    {

      isShooting = true;
      PlayCannonBlastSound();
      launcher.LaunchCannonBall();

    }
    if(Input.GetMouseButtonUp(0))
    {

      isShooting = false;

    }
  }

  void MoveCannon()
  {

    xInput = Input.GetAxisRaw("Horizontal");
    Vector3 newPosition = new Vector3(xInput, 0.0f, 0.0f);

    cannonRb.MovePosition(transform.position + newPosition * moveSpeed * Time.fixedDeltaTime); 

  }

  void PlayCannonBlastSound()
  {

    audioSource.pitch = 1.4f;
    audioSource.PlayOneShot(cannonBlast, cannonBlastVolume);
  
  }
  void KeepCannonInBounds()
  {

    if(transform.position.x >= xRange)
    {

      transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

    }
    if(transform.position.x <= -xRange)
    {

      transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

    }
  }
}
