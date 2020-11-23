using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LaneChanger laneChanger = null;
    [SerializeField] private GameObject gameOver;
    private Animator animator;
    private float isHurtTimer = 5.0f;
    private float hurtTimer = 5.0f;
    public bool isHurt;
    public bool isDead;
    float speed = 20.0f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        isHurt = false;
        isDead = false;
    }

    void Update()
    {
        if(!isDead)
        {
            #region mobile input check
            if (MobileInput.Instance.SwipeRight)
            {
                laneChanger.GoRight();
            }
            if (MobileInput.Instance.SwipeLeft)
            {
                laneChanger.GoLeft();
            }
            if (MobileInput.Instance.SwipeUp)
            {
                if (!isHurt)
                {
                    animator.SetTrigger("Jump");
                }
                else if (isHurt)
                {
                    animator.SetTrigger("InjuredJump");
                }
            }
            if (MobileInput.Instance.SwipeDown)
            {
                animator.SetTrigger("Roll");
            }
            #endregion

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (isHurt == true)
            {
                Debug.Log("isHurt");
                animator.SetBool("isInjured", true);
                isHurtTimer -= Time.deltaTime;
                if (isHurtTimer <= 0)
                {
                    isHurt = false;
                    isHurtTimer = hurtTimer;
                    animator.SetBool("isInjured", false);
                }
            }
        }
        else
        {
            //game Over
            FindObjectOfType<AudioManager>().Play("Death");
            gameOver.SetActive(true);
            animator.Play("Death");
        }
    }
}