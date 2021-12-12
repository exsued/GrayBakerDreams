using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class babyAI : NPC
{

    public Transform[] wayPoints = null;
    public float eyeAngle = 45f;
    public float moveSpeed = 3.5f;
    public float runSpeed = 8f;
    public float searchTime = 8f;
    public float playerCatchDist = 2f;
    public float stepLength = 3f;

    Animator animator;

    public AudioClip babyStep;
    public AudioClip wantToMom, walk;
    private float timer;
    float searchTimer = 0f;
    bool playerSpotted;
    NavMeshAgent agent;
    RaycastHit hit;
    int i = 0;

    public AudioSource src;

    public float VoiceCondition { get; private set; }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        WalkCondition();
    }
    private void Update()
    {
        RefreshStates();
        if (!playerSpotted)
        {
            searchTimer -= Time.deltaTime;
            if(searchTimer <= 0)
                Patrol();
            else
            {
                AttackPlayer();
            }
        }
        else
        {
            AttackPlayer();
        }
    }
    private void TryPlayFootstep(float speed)
    {
        if (timer < Time.time)
        {
            PlayFootstep(speed);
            timer = Time.time + stepLength / moveSpeed;
        }
    }
    private void PlayFootstep(float speed)
    {
        src.PlayOneShot(babyStep);
    }
    void RefreshStates()
    {
        SeePlayer();
    }
    void SeePlayer()
    {
        var dirOnPlayer = Player.instance.transform.position - transform.position;
        var angle = Vector3.Angle(transform.forward, dirOnPlayer);
        Physics.Raycast(transform.position, (Player.instance.transform.position + Vector3.up) - transform.position, out hit);
        print(hit.transform != null? hit.transform.tag : "Empty");
        playerSpotted = hit.transform != null && hit.transform.tag == "Player" &&
            angle <= eyeAngle;
        print(hit.transform);
    }
    void WalkCondition()
    {
        if (src.clip != walk)
        {
            src.Stop();
            src.clip = walk;
            src.Play();
        }
    }
    void AttackCondition()
    {
        if (src.clip != wantToMom)
        {
            src.Stop();
            src.clip = wantToMom;
            src.Play();
        }
    }
    void Patrol()
    {
        if (state != NPCState.Patrol)
        {
            ControllerNPC.OnRelax(this);
            agent.speed = moveSpeed;
            state = NPCState.Patrol;
            animator.SetBool("IsAgr", false);
            if (src.clip != walk)
            {
                src.Stop();
                src.clip = walk;
                src.Play();
            }
        }
        if (Vector3.Distance(transform.position, wayPoints[i].position) < 3f)
        {
            i++;
            if (i >= wayPoints.Length)
                i = 0;
        }
        TryPlayFootstep(moveSpeed);
        agent.SetDestination(wayPoints[i].position);
    }
    void AttackPlayer()
    {
        if (state != NPCState.Attack)
        {
            ControllerNPC.OnAgression(this);
            agent.speed = runSpeed;
            state = NPCState.Attack;
            searchTimer = searchTime;
            animator.SetBool("IsAgr", true);
            if (src.clip != wantToMom)
            {
                src.Stop();
                src.clip = wantToMom;
                src.Play();
            }
        }
        if (Vector3.Distance(Player.instance.transform.position, transform.position) <= playerCatchDist)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TryPlayFootstep(runSpeed);
        agent.SetDestination(Player.instance.transform.position);
    }
    private void OnDrawGizmos()
    {
        if(Player.instance)
            Gizmos.DrawRay(transform.position, Player.instance.transform.position - transform.position);
    }
}
