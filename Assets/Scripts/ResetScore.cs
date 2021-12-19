using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text scoreText = GetComponent<Text>();
        scoreText.text = string.Format("Score:0");

    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     print("Collision Enter");
    //     if (collision.gameObject.CompareTag("Block"))
    //     {
    //         score += 100;
    //     }
    //     setScore();
    // }
    // private void setScore()
    // {
    //     scoreText.text = string.Format("Score:{0}", score);
    // }
}
