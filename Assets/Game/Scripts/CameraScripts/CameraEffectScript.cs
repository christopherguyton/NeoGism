using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraEffectScript : MonoBehaviour
{
    //BlackOut UI Object Variables
    public GameObject blackOutSquare;
    public float faderSpeed;
    public bool fadingOut = false;


    //UI Reference
    public GameObject UICanvas;

    //PlayerScript Reference
    private PlayerScript playerScript;


    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
   
    }

    public void Update()
    {

        StartCoroutine(FadeBlackOutSquare(fadingOut, faderSpeed));


        if (blackOutSquare.GetComponent<Image>().color.a <= 0)
        {
            UICanvas.SetActive(true);
            playerScript.inputScript.enabled = true;
        } else
        {
            UICanvas.SetActive(false);
            playerScript.inputScript.enabled = false;
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack, float fadeSpeed)
    {
        
        faderSpeed = fadeSpeed;
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }

            
        } else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
               
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

}

  

