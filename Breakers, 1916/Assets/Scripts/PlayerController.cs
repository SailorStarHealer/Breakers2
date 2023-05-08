using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public Camera myCamera;
  public RectTransform bottomLeftCorner;
  public RectTransform topRightCorner;

  public GameObject bulletPrefab;
  private Rigidbody2D playerRb;
  public float speed = 5.0f;


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

      Vector3 bottomLeftCornerInScene = myCamera.ScreenToWorldPoint(bottomLeftCorner.position - Vector3.forward*myCamera.transform.position.z);
      Vector3 topRightCornerInScene = myCamera.ScreenToWorldPoint(topRightCorner.position - Vector3.forward*myCamera.transform.position.z);

      if ( transform.position.x < bottomLeftCornerInScene.x )
      {
        StopPlayerPlaneVelocity(true, false);
        SetPlayerPlanePosition(bottomLeftCornerInScene.x, transform.position.y);
      }
      if ( transform.position.x > topRightCornerInScene.x )
      {
        StopPlayerPlaneVelocity(true, false);
        SetPlayerPlanePosition(topRightCornerInScene.x, transform.position.y);
      }

      if ( transform.position.y < bottomLeftCornerInScene.y )
      {
        StopPlayerPlaneVelocity(false, true);
        SetPlayerPlanePosition(transform.position.x, bottomLeftCornerInScene.y);
      }
      if ( transform.position.y > topRightCornerInScene.y )
      {
        StopPlayerPlaneVelocity(false, true);
        SetPlayerPlanePosition(transform.position.x, topRightCornerInScene.y);
      }

/*      if ( Mathf.Abs(transform.position.x) > 10 )
       {
         playerRb.velocity = Vector2.zero;
         Vector2 position = transform.position;
         position.x = 10 * Mathf.Sign(transform.position.x);
         transform.position = position;
       }

       //Creates vertical borders by applying velocity when player drifts away

       if ( Mathf.Abs(transform.position.y) > 30 )
        {
          playerRb.velocity = Vector2.zero;
          Vector2 position = transform.position;
          position.y = 30 * Mathf.Sign(transform.position.y);
          transform.position = position;
        }

*/

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
