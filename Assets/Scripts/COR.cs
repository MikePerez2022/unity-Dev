using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;

    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine("WaitAction");
    }


    void Update()
    {
        //time -= Time.deltaTime;
        //if(time <= 0 )
        //{
        //    time = 3;
        //    print("Hello");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            print("Hello");            
        }
        //yield return null;

        //Group Project exaple for finish timer

        //bool inEndRegion = true;
		//while (inEndRegion)
		//{
		//	yield return new WaitForSeconds(time);
        //    if (!inEndRegion) continue;
		//	print("Hello");
		//}
	}

    IEnumerator StoryTime()
    {
        print("Hello");
        yield return new WaitForSeconds(1);
        print("Welcome to the new world");
        yield return new WaitForSeconds(1);
        print("Time to die");
        yield return new WaitForSeconds(1);
        StopCoroutine(timerCoroutine);

        go = true;

        yield return null;
    }

    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
        print("Go");
        yield return null;
    }
}
