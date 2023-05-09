using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (GetComponent<Camera>().orthographicSize * Screen.width / Screen.height - 226) * Vector3.right + transform.position.z * Vector3.forward;

    }
}
