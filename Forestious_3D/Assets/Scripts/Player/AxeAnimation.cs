using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimation : MonoBehaviour
{
    public GameObject Sword;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwingAxeAnimation());
        }
    }

    IEnumerator SwingAxeAnimation()
    {
        Sword.GetComponent<Animator>().Play("AxeAnimation");
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("New State");
    }
}
