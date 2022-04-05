using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Ending
    {

        public static void GetEnding(int clothCounter, Func<IEnumerator<WaitForSeconds>, Coroutine> startCoroutine)
        {
            switch (clothCounter)
            {
                case < 4:
                    startCoroutine(BadEnding());
                    break;
                case < 8:
                    startCoroutine(NeutralEnding());
                    break;
                default:
                    startCoroutine(GoodEnding());
                    break;
            }
        }

        static IEnumerator<WaitForSeconds> BadEnding()
        {
            GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_bad/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
            GameObject.Find("cutscene_bad/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
        }

        static IEnumerator<WaitForSeconds> NeutralEnding()
        {
            GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_neutral/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
            GameObject.Find("cutscene_neutral/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
        }

        static IEnumerator<WaitForSeconds> GoodEnding()
        {
            GameObject.Find("cutscene_about/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_about/3").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(2);
            GameObject.Find("cutscene_good/1").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
            GameObject.Find("cutscene_good/2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(10);
        }
    }
}