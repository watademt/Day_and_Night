using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private PlayerShooting playerShooting;
    private Animator animator;

    private float animationHorizontal = 0f;
    private float animationVertical = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        MovementAnimations();
        AimingAnimations();
    }

    private void AimingAnimations()
    {
        if (Input.GetMouseButton(0))
        {
            if(playerShooting.IsReadyToShoot == false && playerShooting.IsStretching == true)
            {
                animator.SetBool("IsStretchingBow", true);
            }
            if(playerShooting.IsStretching == false && playerShooting.IsReadyToShoot == true)
            {
                animator.SetBool("IsStretchingBow", false);
                animator.SetBool("IsReadyToShoot", true);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsReadyToShoot", false);
        }
    }

    private void MovementAnimations()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (inputVertical > 0)
        {
            animationVertical += 0.1f;
        }
        else if (inputVertical < 0)
        {
            animationVertical += -0.1f;
        }

        if (inputHorizontal > 0)
        {
            animationHorizontal += 0.1f;
        }
        else if (inputHorizontal < 0)
        {
            animationHorizontal += -0.1f;
        }

        if (animationVertical > 1)
        {
            animationVertical = 1;
        }
        if (animationVertical < -1)
        {
            animationVertical = -1;
        }
        if (animationHorizontal > 1)
        {
            animationHorizontal = 1;
        }
        if (animationHorizontal < -1)
        {
            animationHorizontal = -1;
        }

        if (animationVertical != 0)
        {
            if (inputVertical == 0 && animationVertical > 0)
            {
                animationVertical += -0.1f;
            }
            else if (inputVertical == 0 && animationVertical < 0)
            {
                animationVertical += 0.1f;
            }
        }

        if (animationHorizontal != 0)
        {
            if (inputHorizontal == 0 && animationHorizontal > 0)
            {
                animationHorizontal += -0.1f;
            }
            else if (inputHorizontal == 0 && animationHorizontal < 0)
            {
                animationHorizontal += 0.1f;
            }
        }

        animationVertical = (float)Math.Round((decimal)animationVertical, 2);
        animationHorizontal = (float)Math.Round((decimal)animationHorizontal, 2);

        animator.SetFloat("vert", animationVertical);
        animator.SetFloat("horizont", animationHorizontal);
    }
}
