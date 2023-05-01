using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameOver()
    {
      gameoverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
