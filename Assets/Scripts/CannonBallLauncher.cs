using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLauncher : MonoBehaviour
{

   private float explosionForce = 155.0f;
   private float spawnX;
   private float spawnY = 0.95f;
   private float spawnZ = -23.5f;
   private GameObject cannon;
   public GameObject cannonBallPrefab;
   public GameObject muzzleFlashPrefab;
   void Awake()
   {

      cannon = GameObject.FindWithTag("Player");

   }

   public void LaunchCannonBall()
   {

      spawnX = cannon.transform.position.x; // Get the current x position of the cannon

      Vector3 shootingPoint = new Vector3(spawnX, spawnY, spawnZ);

      GameObject cannonBall = Instantiate(cannonBallPrefab, shootingPoint, Quaternion.identity);

      Rigidbody cannonBallRb = cannonBall.GetComponent<Rigidbody>();

      cannonBall.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
      cannonBallRb.useGravity = true;
      cannonBallRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
      cannonBallRb.interpolation = RigidbodyInterpolation.Interpolate;

      cannonBallRb.AddForce(Vector3.forward * explosionForce, ForceMode.Impulse);

      GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, shootingPoint, Quaternion.identity);

      ParticleSystem muzzleFlashEffect = muzzleFlash.GetComponent<ParticleSystem>();

      muzzleFlashEffect.Play();

      Destroy(muzzleFlash, muzzleFlashEffect.main.duration);

   }
}
