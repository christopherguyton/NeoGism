using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    private BoxCollider col;
    public AudioSource completeSound;
    public Text completeText;
    void Start()
    {
        completeText.gameObject.SetActive(false);
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(LevelFinished());
            
        }
    }

    IEnumerator LevelFinished()
    {

        completeText.gameObject.SetActive(true);
        completeSound.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndScreen_");
    }
}
