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
        if (Input.GetKeyDown(gameManager.upKey) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("upPress", true);
        }
        if (Input.GetKeyDown(gameManager.downKey) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("downPress", true);
        }
        if (Input.GetKeyDown(gameManager.leftKey) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("leftPress", true);
        }
        if (Input.GetKeyDown(gameManager.rightKey) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("rightPress", true);
        }



        if (Input.GetKeyUp(gameManager.upKey) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("upPress", false);
        }
        if (Input.GetKeyUp(gameManager.downKey) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("downPress", false);
        }
        if (Input.GetKeyUp(gameManager.leftKey) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("leftPress", false);
        }
        if (Input.GetKeyUp(gameManager.rightKey) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("rightPress", false);
        }
    }
}
