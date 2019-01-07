using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildingController : MonoBehaviour 
{
    
    //Todo: RENAME VARIABLES AND FUNCTIONS

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
        
        RemoveBuildingsFromView();
        
        ShowBuildings();
    }

    private void ShowBuildings()
    {
        if (GameController.gameStage > 0)
        {
            SetFirstFirstGenBuildingActive();
        }
        if (GameController.gameStage > 1)
        {
            SetFirstSecondGenBuildingActive();
        }
        if (GameController.gameStage > 2)
        {
            SetFirstThirdGenBuildingActive();
        }
        if (GameController.gameStage > 3)
        {
            SetSecondFirstGenBuildingActive();
        }
        if (GameController.gameStage > 4)
        {
            SetSecondSecondGenBuildingActive();
        }
        if (GameController.gameStage > 5)
        {
            SetSecondThirdGenBuildingActive();
        }
    }

    private void RemoveBuildingsFromView()
    {
        
        firstFirstGenBuilding.SetActive(false);
        firstSecondGenBuilding.SetActive(false);
        firstThirdGenBuilding.SetActive(false);

        secondFirstGenBuilding.SetActive(false);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(false);
    }

    private void SetSecondFirstGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(true);
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(true);
        secondSecondGenBuilding.SetActive(false);
        secondThirdGenBuilding.SetActive(false);
       

        if (!upgradeParticles2Gen1Played)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }
            upgradeParticles2Gen1.Play();
            upgradeParticles2Gen1Played = true;

        }

    }
    
    private void SetSecondSecondGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(true);
        secondSecondGenBuilding.SetActive(true);
        secondThirdGenBuilding.SetActive(false);
       
        if (!upgradeParticles2Gen2Played)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }

            upgradeParticles2Gen2.Play();
            upgradeParticles2Gen2Played = true;
        }

    }

    private void SetSecondThirdGenBuildingActive()
    {
        firstThirdGenBuilding.SetActive(true);
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(true);
        secondFirstGenBuilding.SetActive(true);
        secondSecondGenBuilding.SetActive(true);
        secondThirdGenBuilding.SetActive(true);

        if (!upgradeParticles2Gen3Played)
        {
            //print("playing particle effect");
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }
            upgradeParticles2Gen3.Play();
            upgradeParticles2Gen3Played = true;
        }
    }

    private void SetFirstFirstGenBuildingActive()
    {
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(false);
        firstThirdGenBuilding.SetActive(false);
       
        if (!upgradeParticles1Gen1Played)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }

            upgradeParticles1Gen1.Play();
            upgradeParticles1Gen1Played = true;
        }
    }
    private void SetFirstSecondGenBuildingActive()
    {
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(true);
        firstThirdGenBuilding.SetActive(false);
        

        if (!upgradeParticles1Gen2Played)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }
            upgradeParticles1Gen2.Play();
            upgradeParticles1Gen2Played = true;
        }
        
    }
    private void SetFirstThirdGenBuildingActive()
    {
        firstFirstGenBuilding.SetActive(true);
        firstSecondGenBuilding.SetActive(true);
        firstThirdGenBuilding.SetActive(true);
       

        if (!upgradeParticles1Gen3Played)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(hydraulicSoundEffect);
            }
            upgradeParticles1Gen3.Play();
            upgradeParticles1Gen3Played = true;
        }
    }
}
