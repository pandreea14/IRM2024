using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public GameObject otherCactus;
    public float triggerDistance = 0.15f;
    public float fightDuration = 20f; // duration of fight before one cactus dies
    private float fightTime = 0f;
    private bool isFighting = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null && otherCactus != null && !isDead)
        {
            float distance = Vector3.Distance(transform.position, otherCactus.transform.position);

            if (distance < triggerDistance)
            {
                animator.SetTrigger("TrAttack");
                    
                //if (!isFighting)
                //{
                //    isFighting = true;
                //    fightTime = 0f; // reset fight timer when the fight starts
                //}

                //fightTime += Time.deltaTime;

                //if (fightTime >= fightDuration)
                //{
                //    // au luptat timp de 20s
                //    animator.SetTrigger("TrDeath"); // Set TrDeath trigger for the death animation -> back to idle
                //    isDead = true;

                //    // cactusul e mort
                //    //gameObject.SetActive(false); // The cactus disappears from the scene
                //}
            }
            else
            {
                //if (isFighting)
                //{
                //    isFighting = false;
                //    fightTime = 0f; // Reset the timer if they're not close enough to fight
                //}
                animator.ResetTrigger("TrAttack");
            }
        }
    }
}
