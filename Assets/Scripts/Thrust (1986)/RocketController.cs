using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityScript.Steps;

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

    [SerializeField] private float fuelBurntEverySecond;

    private float remainingFuel;
    [SerializeField] private float maximumFuelCapacity;

    [SerializeField] private Text fuelIndicator;
    [SerializeField] private Text noOfAstronauts;

    enum State {Alive, Dying, Transcending}
    State state = State.Alive;
    
	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        remainingFuel = maximumFuelCapacity;
    }
	
	// Update is called once per frame
    void Update()
    {
        noOfAstronauts.text = "Astronauts: " + global::State.noOfAstronauts.ToString();
       
        fuelIndicator.text = "Fuel: " + remainingFuel.ToString();

        if (remainingFuel < 10)
        {
            fuelIndicator.color = Color.red;
        }
        else
        {
            fuelIndicator.color = Color.white;
        }

        //Prevents rocket from leaving the screen

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void RespondToRotateInput()
    {
        float rotationSpeed = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && remainingFuel > 0)
        {
            rigidBody.freezeRotation = true;
            rcsRightParticles.Stop();
            transform.Rotate(Vector3.forward * rotationSpeed);
            rigidBody.freezeRotation = false;
            rcsRightParticles.Play();
        }
        else if (Input.GetKey(KeyCode.D) && remainingFuel > 0)
        {
            rigidBody.freezeRotation = true;
            rcsLeftParticles.Stop();
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
        if (Input.GetKey(KeyCode.Space) && remainingFuel > 0)
        {
            if (!IsInvoking("burnFuel"))
            {
                InvokeRepeating("burnFuel", 0f, 0.1f);
            }

            if (remainingFuel > 0)
            {
                ApplyThrust();
            }
            else
            {
                audioSource.Stop();
        
                mainEngineParticles.Stop();
                rcsLeftParticles.Stop();
                rcsRightParticles.Stop();
            }

        }
        else
        {
            CancelInvoke();
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    void burnFuel()
    {
        remainingFuel = remainingFuel - fuelBurntEverySecond;
        print("REMAINING FUEL: " + remainingFuel);
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

        print(collision.relativeVelocity.y);
        
        if (state != State.Alive) { return; }

       // switch (collision.gameObject.tag)
       // {
       //     case "Friendly":
        //        break;
        //    case "Finish":s
        //        StartSuccessSequence();
       //         break;
       //     default:
       //         StartDeathSequence();
       //         break;
      //  }

        if (collision.gameObject.CompareTag("Friendly") && collision.relativeVelocity.y < maximumSafeLandingVelocity)
        {   
            return;
        }
        else if (collision.gameObject.CompareTag("Finish") && collision.relativeVelocity.y < maximumSafeLandingVelocity)
        { 
            StartSuccessSequence();
        }
     
        else
        {
            StartDeathSequence();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fuel")) {
            remainingFuel = maximumFuelCapacity;
            Destroy(other.gameObject);
        }
    }

    private void StartDeathSequence()
    {
        state = State.Dying;
        global::State.playerDidWin = false;
        CancelInvoke();
        audioSource.Stop();
        
        mainEngineParticles.Stop();
        rcsLeftParticles.Stop();
        rcsRightParticles.Stop();
        
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(explosion);
        }

        explosionParticles.Play();
        
        global::State.investmentCost = global::State.noOfAstronauts * global::State.costToHire;
        
        global::State.noOfAstronauts = 0;
        global::State.costToHire = global::State.costToHire + 1000;
     

        Invoke("ReturnToMainGame", levelLoadDelay);
        
    }

    private void StartSuccessSequence()
    {
       
        GameController.gameStage = stageToGoTo;
        global::State.playerDidWin = true;
        
        state = State.Transcending;
        CancelInvoke();
        audioSource.Stop();
        
        mainEngineParticles.Stop();
        rcsLeftParticles.Stop();
        rcsRightParticles.Stop();
        
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(jingle);
        }

        jingleParticles.Play();
        
        global::State.money = global::State.money + global::State.noOfAstronauts * 1000000;
        global::State.returnCost = global::State.noOfAstronauts * 1000000;
        
        Invoke("ReturnToMainGame", levelLoadDelay);
    }

    private void ReturnToMainGame()
    {
        SceneManager.LoadScene(0);
    }

    //private void RestartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
   
}
