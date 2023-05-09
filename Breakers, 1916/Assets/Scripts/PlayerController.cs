using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public GameObject bulletPrefab;
  private Rigidbody2D playerRb;
  public float speed = 5.0f;
  public float leftBorder;
  public float rightBorder;
  public float topBorder;
  public float bottomBorder;


  private void StopPlayerPlaneVelocity(bool horizontal, bool vertical)
  {
    Vector2 newVelocity = playerRb.velocity;
    if (horizontal)
    {
      newVelocity.x = 0;
    }
    if (vertical)
    {
      newVelocity.y = 0;
    }
    playerRb.velocity = newVelocity;
  }

  private void SetPlayerPlanePosition(float positionX, float positionY)
  {
     Vector2 position = new Vector2(positionX, positionY);
     transform.position = position;
  }


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //Creates horizontal borders by applying velocity when player drifts away
    if ( transform.position.x < leftBorder)
      {
        StopPlayerPlaneVelocity(true, false);
        SetPlayerPlanePosition(leftBorder, transform.position.y);
      }
      if ( transform.position.x > rightBorder)
      {
        StopPlayerPlaneVelocity(true, false);
        SetPlayerPlanePosition(rightBorder, transform.position.y);
      }

      if ( transform.position.y < bottomBorder)
      {
        StopPlayerPlaneVelocity(false, true);
        SetPlayerPlanePosition(transform.position.x, bottomBorder);
      }
      if ( transform.position.y > topBorder)
      {
        StopPlayerPlaneVelocity(false, true);
        SetPlayerPlanePosition(transform.position.x, topBorder);
      }


      if (Input.GetKeyDown(KeyCode.Space))
      {
        //Launch a projectile from player
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
      }

      //Make vehicle move in accordance with keyboard push.
      float forwardInput = Input.GetAxis("Vertical");
      playerRb.AddForce(Vector2.up * speed * forwardInput);

      float sideInput = Input.GetAxis("Horizontal");
      playerRb.AddForce(Vector2.right * speed * sideInput);

      //Make the vehicle move left
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward);
      //transform.Translate(Vector3.forward * Time.deltaTime*20);
    }
}
