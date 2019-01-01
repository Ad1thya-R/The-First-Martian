using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundController : MonoBehaviour
{

	private AudioSource _audioSource;

	[SerializeField] private Button _button;
	[SerializeField] private Sprite _musicOff;
	[SerializeField] private Sprite _musicOn;
	
	// Use this for initialization
	void Start ()
	{
		_audioSource = GetComponent<AudioSource>();
		_button.onClick.AddListener(BtnClicked);

		if (State.musicIsPlaying)
		{
			_audioSource.Play();
		}
		else
		{
			_audioSource.mute = true;
			_audioSource.Play();
			_button.image.overrideSprite = _musicOff;
		}
	}

	void BtnClicked()
	{
		_audioSource.mute = State.musicIsPlaying;

		if (State.musicIsPlaying)
		{
			_button.image.overrideSprite = _musicOff;
		}
		else
		{
			_button.image.overrideSprite = _musicOn;
		}

		State.musicIsPlaying = !State.musicIsPlaying;

	}
}
