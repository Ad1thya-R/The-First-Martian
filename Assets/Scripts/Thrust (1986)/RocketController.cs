using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainEngineThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip jingle;

    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem jingleParticles;
    [SerializeField] ParticleSystem rcsLeftParticles;
    [SerializeField] ParticleSystem rcsRightParticles;

    [SerializeField] int stageToGoTo;
    [SerializeField] private float maximumSafeLandingVelocity;

    enum State {Alive, Dying, Transcending}
    State state = State.Alive;
    
	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        //Prevents rocket from leaving the screen
        
        //Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
        
        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
	}

    private void RespondToRotateInput()
    {
        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationSpeed);
            rigidBody.freezeRotation = false;
            rcsRightParticles.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody.freezeRotation = true;
            transform.Rotate(-Vector3.forward * rotationSpeed);
            rigidBody.freezeRotation = false;
            rcsLeftParticles.Play();
        }
        else
        {
            rcsLeftParticles.Stop();
            rcsRightParticles.Stop();
        }
    }

    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();

        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void ApplyThrust()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }

        mainEngineParticles.Play();

        float speed = mainEngineThrust;
        rigidBody.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; }

       // switch (collision.gameObject.tag)
       // {
       //     case "Friendly":
        //        break;
        //    case "Finish":
        //        StartSuccessSequence();
       //         break;
       //     default:
       //         StartDeathSequence();
       //         break;
      //  }

        if (collision.gameObject.CompareTag("Friendly") && rigidBody.velocity.magnitude < maximumSafeLandingVelocity * Time.deltaTime)
        {
            return;
        } else if (collision.gameObject.CompareTag("Finish") && rigidBody.velocity.magnitude < maximumSafeLandingVelocity * Time.deltaTime)
        {
            StartSuccessSequence();
        }
        else
        {
            StartDeathSequence();
        }
        
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        audioSource.Stop();
        mainEngineParticles.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(explosion);
        }

        explosionParticles.Play();

        Invoke("RestartLevel", levelLoadDelay);
        
    }

    private void StartSuccessSequence()
    {
        GameController.gameStage = stageToGoTo;
        state = State.Transcending;
        audioSource.Stop();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(jingle);
        }

        jingleParticles.Play();
        Invoke("ReturnToMainGame", levelLoadDelay);
    }

    private void ReturnToMainGame()
    {
        SceneManager.LoadScene(0);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
