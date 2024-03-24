using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f; // In Unity, public member variables appear in the Inspector window and can therefore be tweaked.
    //You’ve also used camelCase (rather than PascalCase, with its m_ prefix). This is because the variable is public, and the Unity naming convention uses this format for public member variables.  Naming conventions can be very useful, but there’s no technical reason for this.
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;

    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
        //OnAnimatorMove is actually going to be called in time with physics, and not with rendering like your Update method.  
        //The movement vector and rotation are set in Update.If OnAnimatorMove gets called first then you will have a problem, because a Quaternion without a value set doesn’t make any sense.
        //To make sure the movement vector and rotation are set in time with OnAnimatorMove, change your Update method to a FixedUpdate
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        //hasHorizontalInput is true when horizontal is non-zero.
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        //if hasHorizontalInput or hasVerticalInput are true then isWalking is true, and otherwise it is false. (Input means the user player pressing controls)
        m_Animator.SetBool("IsWalking", isWalking);
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        //Quaternions are a way of storing rotations; they get around some of the problems with storing rotations as a 3D vector. 
        m_Rotation = Quaternion.LookRotation(desiredForward); //This line simply calls the LookRotation method and creates a rotation looking in the direction of the given parameter.  
    }
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        //First, you’re using your reference to the Rigidbody component to call its MovePosition method, and passing in a single parameter: its new position.The new position starts off at the Rigidbody’s current position, and then you’ve add a change to that — the movement vector multiplied by the magnitude of the Animator’s deltaPosition.  But what does that mean?
        //The Animator’s deltaPosition is the change in position due to root motion that would have been applied to this frame.You’re taking the magnitude of that(the length of it) and multiplying by the movement vector which is in the actual direction we want the character to move.

        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
