using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float BackgroundSpeed = 0.669f;
    public static float CameraSpeed = 12;
    public Text ResultLabel;
    public Text StartGameLabel;
    public AudioSource AudioSource;
    static float startBackgroundSpeed;
    static float startCameraSpeed;
    float timeSpan = 2f;
    float timeBetweenSeedUp = 0.5f;

    static int resultCounter = 0;
    float timeBetweenResultIncrement = 1f;
    float counterTime = 0;
    public static bool GameStarted;
    public static bool GameFinished = true;

    // Start is called before the first frame update
    void Start()
    {
        startBackgroundSpeed = BackgroundSpeed;
        startCameraSpeed = CameraSpeed;
        BackgroundSpeed = 0;
        CameraSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (GameStarted == false)
        {
            StartGameLabel.enabled = true;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameFinished = false;
                StartGameLabel.enabled = false;
                GameStarted = true;
                BackgroundSpeed = startBackgroundSpeed;
                CameraSpeed = startCameraSpeed;
                StartGameLabel.enabled = false;
                AudioSource.enabled = true;
            }
            else
            {
                return;
            }
        }

        if (GameFinished && Input.GetKey(KeyCode.R))
        {
            GameManager.RestartGame();
        }
        if (GameFinished)
        {
            AudioSource.enabled = false;
            return;
        }

        if (Time.time > timeSpan)
        {
            var backgroundPercent = 0.005f;/// BackgroundSpeed;
            BackgroundSpeed += BackgroundSpeed * backgroundPercent;
            //var cameraNewValue = CameraSpeed * backgroundPercent;
            CameraSpeed += CameraSpeed * backgroundPercent;
            timeSpan = Time.time + timeBetweenSeedUp;
        }
        if (Time.time > counterTime)
        {
            resultCounter++;
            ResultLabel.text = resultCounter.ToString();
            counterTime = Time.time + timeBetweenResultIncrement;
        }
    }

    public static void FinishGame()
    {
        GameFinished = true;
        BackgroundSpeed = CameraSpeed = 0;
       
    }
    public static void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        BackgroundSpeed = startBackgroundSpeed;
        CameraSpeed = startCameraSpeed;
        GameFinished = false;
        resultCounter = 0;
        GameStarted=false;
    }
}
