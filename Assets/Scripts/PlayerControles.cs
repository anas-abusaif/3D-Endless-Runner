using UnityEngine;

public class PlayerControles : MonoBehaviour
{
    public float DodgeSpeed = 5f;
    public float CurrentLane = Lanes.Middle;
    private Rigidbody Rigidbody;
    public float FWDspeed;
    Animator Animator;
    float Direction;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        Physics.gravity = Vector3.down * 15;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = -1;

            if (CurrentLane == Lanes.Right)
            {
                CurrentLane = Lanes.Middle;
            }
            else
            {
                CurrentLane = Lanes.Left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = 1;

            if (CurrentLane == Lanes.Left)
            {
                CurrentLane = Lanes.Middle;
            }
            else
            {
                CurrentLane = Lanes.Right;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                Animator.SetTrigger("Jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!Animator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            {
                Rigidbody.AddForce(Vector3.down * 5, ForceMode.Impulse);
                Animator.SetTrigger("Slide");
            }
        }
    }
    private void FixedUpdate()
    {
        Rigidbody.position += FWDspeed * Time.fixedDeltaTime * Vector3.forward;
        Rigidbody.position += Direction * DodgeSpeed * Time.fixedDeltaTime * Vector3.right;

        if (CurrentLane == Lanes.Left)
        {
            Rigidbody.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, Lanes.Left, Lanes.Middle), Rigidbody.position.y, Rigidbody.position.z);
        }

        if (CurrentLane == Lanes.Right)
        {
            Rigidbody.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, Lanes.Middle, Lanes.Right), Rigidbody.position.y, Rigidbody.position.z);
        }

        if (CurrentLane == Lanes.Middle && Direction == -1)
        {
            Rigidbody.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, Lanes.Middle, Lanes.Right), Rigidbody.position.y, Rigidbody.position.z);
        }

        if (CurrentLane == Lanes.Middle && Direction == 1)
        {
            Rigidbody.position = new Vector3(Mathf.Clamp(Rigidbody.position.x, Lanes.Left, Lanes.Middle), Rigidbody.position.y, Rigidbody.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Collided");
        }
    }
}

