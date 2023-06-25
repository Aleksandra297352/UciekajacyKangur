using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameFinished && GameManager.GameStarted)
        {
            this.GetComponent<Text>().enabled = true;
        }
    }
}
