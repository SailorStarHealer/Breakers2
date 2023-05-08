using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
  public float repeatHeight = 1796.4f;
  public float scrollSpeed = 50;

    // Update is called once per frame
    void Update()
    {
      //Move the background
      transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

      //Wrap around background
        if(transform.position.y <- repeatHeight)
        {
          transform.position += Vector3.up * repeatHeight;
        }
    }
}
