using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text text;

    public float fadeDuration = 1.0f;
    public float delayBetweenFades = 0.5f;

    private IEnumerator Start()
    {
        Color originalColor = text.color;

        while (true)
        {
            yield return FadeInOutText(originalColor, fadeDuration);
            yield return new WaitForSeconds(delayBetweenFades);
        }
    }

    private IEnumerator FadeInOutText(Color baseColor, float duration)
    {
        float startTime = Time.time;

        // 나타나는 코드 
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(0f, 1f, t);
            text.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // 가장 선명한 색을 나타내는 색깔 
        text.color = new Color(baseColor.r, baseColor.g, baseColor.b, 1f);

        yield return new WaitForSeconds(delayBetweenFades);

        startTime = Time.time;

        // 사라지게 하는 코드 
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            float alpha = Mathf.Lerp(1f, 0f, t);
            text.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        // 글자를 투명하게 하는 부분 
        text.color = new Color(baseColor.r, baseColor.g, baseColor.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    IEnumerator StartText()
    {

        int count = 0;

        while (count < 2)
        {
            float fadeCount = 1;

            while (fadeCount < 2.0f)
            {
                fadeCount -= 0.1f;
                yield return new WaitForSeconds(0.01f);
                text.color = new Color(0, 0, 0, fadeCount);
            }

            while (fadeCount > 1f)
            {
                fadeCount += 0.1f;
                yield return new WaitForSeconds(0.01f);
                text.color = new Color(0, 0, 0, fadeCount);
            }

            count++;
        }



        #region
        //float time = 0;

        //Color origninColor = text.color;

        //yield return new WaitForSeconds(0.5f);
        //// 투명해지기 전까지만 반복.
        //while (text.color.a != 0)
        //{
        //    // 1초마다 서서히 바뀌는것
        //    time += Time.deltaTime;
        //    //RGB에 4개를 가지고 있어서 벡터4를 씀 

        //    //2초만에 투명해지는 코드 
        //    text.color = Vector4.Lerp(origninColor, new Vector4(origninColor.r, origninColor.g, origninColor.b, 0), time / 1);

        //    yield return null; //한 프레임을 쉬기. 
        //}
        #endregion
    }
}
