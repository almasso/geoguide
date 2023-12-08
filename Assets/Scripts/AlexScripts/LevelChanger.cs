using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeScreen()
    {
        animator.SetTrigger("FadeOutTrigger");
    }
}
