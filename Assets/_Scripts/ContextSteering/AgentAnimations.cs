using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimations : MonoBehaviour
{
    private Animator animator;
    private KeyCode previousKey;
    private GameManager gameManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(gameManager.upKey)){
            animator.SetBool("upPress", true);
        }
        if (Input.GetKeyDown(gameManager.downKey))
        {
            animator.SetBool("downPress", true);
        }
        if (Input.GetKeyDown(gameManager.leftKey))
        {
            animator.SetBool("leftPress", true);
        }
        if (Input.GetKeyDown(gameManager.rightKey))
        {
            animator.SetBool("rightPress", true);
        }



        if (Input.GetKeyUp(gameManager.upKey))
        {
            animator.SetBool("upPress", false);
        }
        if (Input.GetKeyUp(gameManager.downKey))
        {
            animator.SetBool("downPress", false);
        }
        if (Input.GetKeyUp(gameManager.leftKey))
        {
            animator.SetBool("leftPress", false);
        }
        if (Input.GetKeyUp(gameManager.rightKey))
        {
            animator.SetBool("rightPress", false);
        }
    }
}
