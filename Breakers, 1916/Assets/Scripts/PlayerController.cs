using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
  public GameObject bulletPrefab;
  private Rigidbody2D playerRb;
  public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

      if ( Mathf.Abs(transform.position.x) > 5 )
       {
         playerRb.velocity = Vector2.zero;
         Vector2 position = transform.position;
         position.x = 5 * Mathf.Sign(transform.position.x);
         transform.position = position;
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
