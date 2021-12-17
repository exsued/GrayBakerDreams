using UnityEngine;
using System.Collections;

public enum PlayerPosState
{
    Crouch,
    Walk,
    Run
}

[System.Serializable]
public class StepType
{
    public string groundTag;
    public AudioClip[] steps;
}

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public static Player instance = null;
    public GameObject playerCanvas;
    //Eyes
    public Light nightVision = null;

    //Movement
    public CharacterController controller { get; private set; }
    public Vector3 moveDirection { get; private set; }
    public PlayerPosState states { get; private set; } = PlayerPosState.Walk;

    public float walkSpeed = 5f,
                 runSpeed = 8f,
                 crouchSpeed = 3f;
    public LayerMask groundMask;
    public LayerMask ceilingMask;
    public LayerMask interactableMask;

    public float maxInteractDistance = 4f;
    public float StandHeight => standHeight;
    public float CrouchHeight => crouchHeight;

    private float standHeight, crouchHeight, stepLength;
    private float timer;
    private AudioSource foostepsSource;

    public StepType[] runFoosteps;
    public StepType[] walkFoosteps;
    public StepType[] crouchFoosteps;
    RaycastHit stepHit;
    RaycastHit interactHit;

    public bool CanUseComputer = true;

    public Transform Feet;

    public PlayerCam alignCamera { get; private set; }
    public Camera handCam;
    public bool cctvMode = false;
    private void OnDisable()
    {
        states = PlayerPosState.Walk;
        moveDirection = Vector3.zero;
        controllerHeight = standHeight;
    }
    private void OnEnable()
    {
        states = PlayerPosState.Walk;
        if(alignCamera != null)
        alignCamera.XLockRotate = false;
    }
    public float controllerHeight
    {
        get => controller.height;
        set
        {
            controller.center = Vector3.up * value / 2f;
            controller.height = value;
        }
    }

    private void PlayFootstep()
    {
        if (stepHit.transform == null)
            return;
        StepType[] types = null;
        switch (states)
        {
            case PlayerPosState.Walk:
                types = walkFoosteps;
                break;
            case PlayerPosState.Run:
                types = runFoosteps;
                break;
            case PlayerPosState.Crouch:
                types = crouchFoosteps;
                break;
        }
        var type = findByTag(types, stepHit.transform.tag);
        if(type != null)
            foostepsSource.PlayOneShot(type.steps[Random.Range(0, type.steps.Length)]);
    }
    StepType findByTag(StepType[] types, string tag)
    {
        for (int i = 0; i < types.Length; i++)
        {
            if (types[i].groundTag == tag)
                return types[i];
        }
        return null;
    }
    private void TryPlayFootstep(float curSpeed)
    {
        if (timer < Time.time)
        {
            PlayFootstep();
            timer = Time.time + stepLength / curSpeed;
        }
    }
    private void Start()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        standHeight = controllerHeight;
        crouchHeight = controllerHeight / 2f;
        stepLength = walkSpeed * 0.8f;  //Ширина шага
        playerCanvas.SetActive(true);
        alignCamera = GetComponentInChildren<PlayerCam>();
        foostepsSource = Feet.GetComponent<AudioSource>();
    }
    public void ToCCTV()
    {
        var player = Player.instance;
        var cam = player.alignCamera;
        handCam.enabled = false;
        cam.enabled = false;
        cam.GetComponent<Camera>().enabled = false;
        player.enabled = false;
        cam.GetComponent<AudioListener>().enabled = false;
        cctvMode = true;
    }
    public void ToDefault()
    {
        var player = Player.instance;
        var cam = player.alignCamera;
        handCam.enabled = true;
        cam.enabled = true;
        cam.GetComponent<Camera>().enabled = true;
        player.enabled = true;
        cam.GetComponent<AudioListener>().enabled = true;
        cctvMode = false;
    }
    private bool CanCrouch()
    {
        RaycastHit hit2;
        Physics.Raycast(Feet.position, Vector3.down, out hit2, standHeight, groundMask);

        return !(hit2.transform == null || hit2.point.y - transform.position.y > crouchHeight);
    }
    private bool CanStand()
    {
        var r = !Physics.Raycast(transform.position, Vector3.up, standHeight, ceilingMask);
        return r;
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(Feet.position, Vector3.down, out stepHit, controllerHeight, groundMask);
    }
    private void Update()
    {
        MoveUpdate();
        InteractUpdate();
    }
    private void CheckPosState()
    {
        if (Input.GetButton("Crouch") && CanCrouch())
            states = PlayerPosState.Crouch;
        else
        {
            if (states == PlayerPosState.Crouch)
                if (!CanStand()) return;
            if (Input.GetButton("Run"))
                states = PlayerPosState.Run;
            else
                states = PlayerPosState.Walk;
        }
    }
    private void MoveUpdate()
    {
        CheckPosState();
        //Falling system
        IsGrounded();
        controller.Move(Physics.gravity * Time.deltaTime);

        var motion = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(motion).normalized;    //From world to local space

        float curSpeed = 0f;
        switch (states)
        {
            case PlayerPosState.Walk:
                curSpeed = walkSpeed;
                controllerHeight = standHeight;
                break;
            case PlayerPosState.Crouch:
                curSpeed = crouchSpeed;
                controllerHeight = crouchHeight;
                break;
            case PlayerPosState.Run:
                curSpeed = runSpeed;
                controllerHeight = standHeight;
                break;
        }
        controller.Move(moveDirection * curSpeed * Time.deltaTime);
        var curVel = controller.velocity.magnitude;
        if (curVel > curSpeed / 2f)
            TryPlayFootstep(curSpeed * curVel / curSpeed);
    }
    private void InteractUpdate()
    {
        var camTrans = alignCamera.transform;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out interactHit, maxInteractDistance, interactableMask))
        {
            var interactable = interactHit.transform.GetComponent<Interactable>();
            if (interactable == null)
                return;
            if (Input.GetKeyDown(KeyCode.F))
                interactable.Interact();
        }
    }

    public void GetElectricDamage(Transform source, float force = 1f)
    {
        alignCamera.Shake(0.1f, 0.3f);
        controller.Move((transform.position - source.position).normalized * force);
    }
    public IEnumerator TranslateAtPosition(Transform point, float lerpSpeed = 10f, float epsilon = 0.1f)
    {
        while (Vector3.Distance(transform.position, point.position) > epsilon)
        {
            transform.position = Vector3.Lerp(transform.position, point.position, Time.deltaTime * lerpSpeed);
            yield return new WaitForEndOfFrame();
        }
        transform.position = point.position;
    }
    public IEnumerator TranslateAtPosition(Vector3 pos, float lerpSpeed = 10f, float epsilon = 0.1f)
    {
        while (Vector3.Distance(transform.position, pos) > epsilon)
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * lerpSpeed);
            yield return new WaitForEndOfFrame();
        }
        transform.position = pos;
    }
}
