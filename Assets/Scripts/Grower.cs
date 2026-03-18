using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform Tree;
    public Transform Apple;

    Coroutine doTheGrowingCoroutine;
    Coroutine growTheTreeCoroutine;
    Coroutine growTheAppleCoroutine;
    void Start()
    {
        Tree.localScale = Vector2.zero;
        Apple.localScale = Vector2.zero;
    }

    public void StartTreeGrowing()
    {
        if (doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if (growTheTreeCoroutine != null)
        {
            StopCoroutine(growTheTreeCoroutine);
        }
        if (growTheAppleCoroutine != null)
        {
            StopCoroutine(growTheAppleCoroutine);
        }
        doTheGrowingCoroutine = StartCoroutine(DoTheGrowing());
    }

    IEnumerator DoTheGrowing()
    {
        // yield return StartCoroutine(GrowTree());
        yield return growTheTreeCoroutine = StartCoroutine(GrowTree());
        // yield return StartCoroutine(GrowApple());
        yield return growTheAppleCoroutine = StartCoroutine(GrowApple());

    }
    IEnumerator GrowTree()
    {
        Debug.Log("started growing tree");
        Tree.localScale = Vector2.zero;
        Apple.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            Tree.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("finished growing tree");
    }

    IEnumerator GrowApple()
    {
        Debug.Log("started growing apple");
        Apple.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            Apple.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("finished growing apple");
    }
}
