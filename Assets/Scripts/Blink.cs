using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // список потому что у нас на сцене голова и тело 
    public Renderer[] Renderers;

    // функция
    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect(){

        for (float t = 0; t < 1 ; t+=Time.deltaTime)
        {   
            // переберает список голову и тело
            for (int i = 0; i < Renderers.Length; i++)
            {
                // перебирает все материлы на объекте 
                for (int m = 0; m < Renderers[i].materials.Length; m++)
                {
                    // обращаемся к Emission и с помощью колебаний меняем цвет на красный
                    Renderers[i].materials[m].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));

                }
            }
            yield return null;
        }
    }
}
