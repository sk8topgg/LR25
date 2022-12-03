using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool slowTime, fastTime;
   
    public float slow;
    public bool startGame;
    public void slowTimerStart()
    {
        StartCoroutine(slowTheTime());
    }
    IEnumerator slowTheTime()
    {
        slowTime = true;
        Time.timeScale = 1 / slow;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slow;
        FindObjectOfType<BallFuctionality>().forceAppliedInUpwardDirection *= 2;
        yield return new WaitForSeconds(2 * slow);
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slow;
        FindObjectOfType<BallFuctionality>().forceAppliedInUpwardDirection /= 2;
        slowTime = false;
    }
    public void FastTimerStart()
    {
        StartCoroutine(fastTheTime());
    }
    IEnumerator fastTheTime()
    {
        fastTime = true;
        Time.timeScale = 1 * slow;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slow;
        FindObjectOfType<BallFuctionality>().forceAppliedInUpwardDirection /= 2;
        yield return new WaitForSeconds(2 * slow);
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slow;
        FindObjectOfType<BallFuctionality>().forceAppliedInUpwardDirection *= 2;
        fastTime = false;
    }
    public void StartTheGame()
    {
        startGame = true;
        FindObjectOfType<BallFuctionality>().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
