using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeLerp : MonoBehaviour {

    public float LerpSpeed;
    public bool isLerpingOpaque;
    Text currentText;
    Image currentImage;
    float alphaAmount;

    // Use this for initialization
    void Start () {
        currentText = GetComponentInParent<Text>();
        currentImage = GetComponentInParent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (isLerpingOpaque == true)
        {
            if (currentText != null)
            {
                alphaAmount = Mathf.Lerp(alphaAmount, 1, LerpSpeed);
                currentText.color = new Color(currentText.color.r, currentText.color.g, currentText.color.b, alphaAmount);
            }
            if (currentImage != null)
            {
                alphaAmount = Mathf.Lerp(alphaAmount, 1, LerpSpeed);
                Color c = currentImage.color;
                c.a = alphaAmount;
                currentImage.color = c;
                //currentImage.color = new Color(currentText.color.r, currentText.color.g, currentText.color.b, alphaAmount);
            }
            
        }
        else //Its becoming invis
        {
            if (currentText != null)
            {
                alphaAmount = Mathf.Lerp(alphaAmount, 0, LerpSpeed);
                currentText.color = new Color(currentText.color.r, currentText.color.g, currentText.color.b, alphaAmount);
            }
            if (currentImage != null)
            {
                alphaAmount = Mathf.Lerp(alphaAmount, 0, LerpSpeed);
                Color c = currentImage.color;
                c.a = alphaAmount;
                currentImage.color = c;

            }
        }		
	}

    public void TextLerpToOpaque()
    {
        isLerpingOpaque = true;
    }

    public void TextLerpToInvisible()
    {
        isLerpingOpaque = false;
    }

}
