using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void FadeScreen()
    {
        animator.SetTrigger("FadeOutTrigger");
    }
    public void FadeInScreen()
    {
        animator.SetTrigger("FadeInTrigger");
    }


}
