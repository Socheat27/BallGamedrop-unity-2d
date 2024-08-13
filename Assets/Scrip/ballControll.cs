using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Music;

public class BallControll : MonoBehaviour
{
    public GameObject overGame;
    public GameObject[] heartball;
    private int heart = 2;
    public Text ballText, overBallText, bestBallText;
    public GameObject ballDeffence;
    public Animator timeDeff;
    private bool ballCon = true;
    private bool deffenceActivated = true;
    public static int ball;

    private void Start()
    {
        // Load the best ball score from PlayerPrefs
        BestBall = PlayerPrefs.GetInt("BestBall", 0);
        overGame.SetActive(false);
    }

    public void Update()
    {
        ballText.text = "SCORE : " + ball.ToString();

        if (deffenceActivated && ball % 10 == 0 && ball > 0)
        {
            StartCoroutine(WaitDeffance());
            deffenceActivated = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (ballCon)
            {
                if (heart > 0)
                {
                    music.Musics[3].Play();
                    heartball[heart].SetActive(false);
                    heart--;
                    Destroy(other.gameObject);
                }
                else
                {
                    
                    if (music.IsOn)
                    {
                        music.Musics[0].mute = true;
                    }
                    music.Musics[5].Play();
                    heartball[heart].SetActive(false);
                    Time.timeScale = 0;
                    //FalseAnimat.Play("FalseOn");
                    overGame.SetActive(true);
                    overBallText.text ="SCORE : " +ball.ToString();
                    if (BestBall < ball)
                    {
                        BestBall = ball;
                        // Save the best ball score to PlayerPrefs
                        PlayerPrefs.SetInt("BestBall", BestBall);
                        PlayerPrefs.Save();
                    }
                    bestBallText.text ="BEST : "+ BestBall.ToString();
                }
            }
        }
        else if (other.CompareTag("Feed"))
        {
            ball++;
            Destroy(other.gameObject);
            music.Musics[4].Play();
        }
    }

    public void ReplayGame()
    {
        if (music.IsOn)
        {
            music.Musics[0].mute = false;
            music.Musics[0].Play();
        }
        ball = 0;
        heart = 2;
        Time.timeScale = 1;
        overGame.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] feeds = GameObject.FindGameObjectsWithTag("Feed");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject feed in feeds)
        {
            Destroy(feed);
        }
        foreach (GameObject heartObj in heartball)
        {
            heartObj.SetActive(true);
        }
    }

    IEnumerator WaitDeffance()
    {
        ballDeffence.SetActive(true);
        timeDeff.Play("DeffOn");
        ballCon = false;
        yield return new WaitForSeconds(10f);
        ballCon = true;
        timeDeff.Play("DeffOff");
        ballDeffence.SetActive(false);
        deffenceActivated = true;
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    // Property for BestBall score
    public static int BestBall { get; private set; }
}
