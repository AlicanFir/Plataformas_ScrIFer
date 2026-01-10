using System;
using System.Collections;
using UnityEngine;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            MakeTransition();
        }
    }

    public void MakeTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
    }
}
