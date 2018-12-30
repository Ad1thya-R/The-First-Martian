using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    [SerializeField] GameObject firstGenBuilding;
    [SerializeField] GameObject secondGenBuilding;
    [SerializeField] GameObject thirdGenBuilding;

    [SerializeField] ParticleSystem upgradeParticlesGen1;
    [SerializeField] ParticleSystem upgradeParticlesGen2;
    [SerializeField] ParticleSystem upgradeParticlesGen3;

    [SerializeField] AudioClip hydraulicSoundEffect;

    AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        
        firstGenBuilding.SetActive(false);
        secondGenBuilding.SetActive(false);
        thirdGenBuilding.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey("1"))
        {
            SetFirstGenBuildingActive();
        } else if(Input.GetKey("2"))
        {
            SetSecondGenBuildingActive();
        }
        else if(Input.GetKey("3"))
        {
            SetThirdGenBuildingActive();
        }
    }

    private void SetFirstGenBuildingActive()
    {
        firstGenBuilding.SetActive(true);
        secondGenBuilding.SetActive(false);
        thirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }
        upgradeParticlesGen1.Play();
    }
    private void SetSecondGenBuildingActive()
    {
        firstGenBuilding.SetActive(false);
        secondGenBuilding.SetActive(true);
        thirdGenBuilding.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }
        upgradeParticlesGen2.Play();
    }
    private void SetThirdGenBuildingActive()
    {
        firstGenBuilding.SetActive(false);
        secondGenBuilding.SetActive(false);
        thirdGenBuilding.SetActive(true);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(hydraulicSoundEffect);
        }
        upgradeParticlesGen3.Play();
    }
}
