using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour

{
  private Rigidbody2D bulletRb;
  public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
      //  bulletRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        bulletRb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
