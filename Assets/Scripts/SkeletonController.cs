using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class SkeletonController : MonoBehaviour
{
    [SerializeField] private AnimationClip walk, attack;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float radius ;
    [SerializeField] private PlayerController player;
    [SerializeField] private MenuManager menuManager;
    private Animator animator => GetComponent<Animator>();
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();
    private bool isSaw, caughtPlayer;


    private void Start()
    {
        caughtPlayer = false;
    }

    private void Update()
    {
        if (!caughtPlayer)
        {
            isSaw = Physics.CheckSphere(transform.position, radius, playerLayer);
            if (isSaw)
            {
                agent.SetDestination(player.transform.position);
                animator.Play(walk.name);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            caughtPlayer = true;
            agent.SetDestination(transform.position);
            StartCoroutine(WaitAttackDone());
        }
    }

    

    private IEnumerator WaitAttackDone ()
    {
        animator.Play(attack.name);
        yield return new WaitForSeconds(attack.length);
        menuManager.ShowLostMenu();
    }
}
