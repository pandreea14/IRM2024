using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    public GameObject otherCactus;
    public float triggerDistance = 0.15f;
    public float fightDuration = 10f; // Durata luptei în secunde înainte ca unul s? moar?
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
                if (!isFighting)
                {
                    isFighting = true;
                    fightTime = 0f; // Reset?m timer-ul la începutul luptei
                }

                fightTime += Time.deltaTime;

                if (fightTime >= fightDuration)
                {
                    // Unul dintre cactu?i "moare" dup? 10 secunde de lupt?
                    animator.SetTrigger("TrDie"); // Presupunem c? exist? un trigger pentru anima?ia de moarte
                    isDead = true;

                    // Face cactusul s? dispar? din scen?
                    gameObject.SetActive(false); // Dezactiveaz? obiectul (cactusul moare)
                }
                else
                {
                    animator.SetTrigger("TrAttack");
                }
            }
            else
            {
                if (isFighting)
                {
                    isFighting = false;
                    fightTime = 0f; // Reset?m timer-ul când distan?a este prea mare
                }
                animator.ResetTrigger("TrAttack");
            }
        }
    }
}
