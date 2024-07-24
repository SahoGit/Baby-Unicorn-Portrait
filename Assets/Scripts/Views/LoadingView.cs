using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{
    public Image LoadingFilled;
    // Start is called before the first frame update
    void Start()
    {
        LoadingFilled.fillAmount = 0;
        LoadingBgActive();
    }

    private void LoadingBgActive()
    {
        StartCoroutine(FillAction(LoadingFilled));
        //Invoke("LoadingFull", 4.0f);
    }

    IEnumerator FillAction(Image img)
    {
        if (img.fillAmount < 1)
        {
            img.fillAmount = img.fillAmount + 0.009f;
            yield return new WaitForSeconds(0.02f);
            StartCoroutine(FillAction(img));
        }
        else if (img.color.a >= 1f)
        {
            StopCoroutine(FillAction(img));
        }
    }
}
