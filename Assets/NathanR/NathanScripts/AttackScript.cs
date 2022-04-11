using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackScript : MonoBehaviour
{

    public float AttackDamage;
    public Animator PlayerAnimator;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    //public GameObject scoreTracker;
    //public ScoreTrackingScript scoreScript;

    public AudioSource biteSound;
    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        //scoreTracker = GameObject.Find("ScoreTracker");
        //scoreScript = scoreTracker.GetComponent<ScoreTrackingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("attack");
        //play anim
        PlayerAnimator.SetTrigger("Attack");
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayer);
        //do damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealthScript>().TakeHit(AttackDamage);
            Debug.Log("Hit" + enemy.name);
            //GetComponent<PlayerHealth>().getHealed();

            //biteSound.Play();

            //score bonus
            //scoreScript.points += 10;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null) return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
