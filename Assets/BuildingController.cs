using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingController : MonoBehaviour 
{

    [SerializeField] GameObject firstFirstGenBuilding;
    [SerializeField] GameObject firstSecondGenBuilding;
    [SerializeField] GameObject firstThirdGenBuilding;
    
    [SerializeField] GameObject secondFirstGenBuilding;
    [SerializeField] GameObject secondSecondGenBuilding;
    [SerializeField] GameObject secondThirdGenBuilding;

    [SerializeField] ParticleSystem upgradeParticles1Gen1;
    [SerializeField] ParticleSystem upgradeParticles1Gen2;
    [SerializeField] ParticleSystem upgradeParticles1Gen3;
    
    [SerializeField] ParticleSystem upgradeParticles2Gen1;
    [SerializeField] ParticleSystem upgradeParticles2Gen2;
    [SerializeField] ParticleSystem upgradeParticles2Gen3;

    [SerializeField] AudioClip hydraulicSoundEffect;

    AudioSource audioSource;

    public static bool upgradeParticles1Gen1Played = false;
    public static bool upgradeParticles1Gen2Played = false;
    public static bool upgradeParticles1Gen3Played = false;
    
    public static bool upgradeParticles2Gen1Played = false;
    public static bool upgradeParticles2Gen2Played = false;
    public static bool upgradeParticles2Gen3Played = false;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        
        firstFirstGenBuilding.SetActive(false);
        firstSecondGenBuilding.SetActive(false);
        firstThirdGenBuilding.SetActive(false);
        
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(false);
        
        if(GameController.gameStage == 1)
        {
            SetFirstFirstGenBuildingActive();
        } 
        else if(GameController.gameStage == 2)
        {
            SetFirstSecondGenBuildingActive();
        }
        else if(GameController.gameStage == 3)
        {
            SetFirstThirdGenBuildingActive();
        }
        else if(GameController.gameStage == 4)
        {
            SetSecondFirstGenBuildingActive();
        }
        else if(GameController.gameStage == 5)
        {
            SetSecondSecondGenBuildingActive();

        }
        else if(GameController.gameStage == 6)
        {
            SetSecondThirdGenBuildingActive();

        }
    }

    private void SetSecondThirdGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(true);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles2Gen3)
        {
            upgradeParticles2Gen3.Play();
            upgradeParticles2Gen3Played = !upgradeParticles2Gen3Played;
        }
    }

    private void SetSecondSecondGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(true);
        secondThirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles2Gen2Played)
        {
            upgradeParticles2Gen2.Play();
            upgradeParticles2Gen2Played = !upgradeParticles2Gen2Played;
        }

    }

    private void SetSecondFirstGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles2Gen1Played)
        {
            upgradeParticles2Gen1.Play();
            upgradeParticles2Gen1Played = !upgradeParticles2Gen1Played;

        }

    }

    private void SetFirstFirstGenBuildingActive()
    {
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(false);
        firstThirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles1Gen1Played)
        {
            upgradeParticles1Gen1.Play();
            upgradeParticles1Gen1Played = !upgradeParticles1Gen1Played;
        }
    }
    private void SetFirstSecondGenBuildingActive()
    {
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        firstFirstGenBuilding.SetActive(false);
        firstSecondGenBuilding.SetActive(true);
        firstThirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles1Gen2Played)
        {
            upgradeParticles1Gen2.Play();
            upgradeParticles1Gen2Played = !upgradeParticles1Gen2Played;
        }
        
    }
    private void SetFirstThirdGenBuildingActive()
    {
        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(false);
        firstFirstGenBuilding.SetActive(false);
        firstSecondGenBuilding.SetActive(false);
        firstThirdGenBuilding.SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }

        if (!upgradeParticles1Gen3Played)
        {
            upgradeParticles1Gen3.Play();
            upgradeParticles1Gen3Played = !upgradeParticles1Gen3Played;
        }
    }
}
