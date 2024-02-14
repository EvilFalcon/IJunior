using System;
using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1;
    [SerializeField] private float _incrementVolume = 0.2f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.clip = _audioClip;
        _audioSource.loop = true;
    }

    public void UpVolume()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DownVolume()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator ChangeVolume(float alarmVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (Math.Abs(_audioSource.volume - alarmVolume) > Mathf.Epsilon)
        {
            _audioSource.volume = Mathf.MoveTowards(
                _audioSource.volume,
                alarmVolume,
                _incrementVolume * Time.deltaTime
                );

            yield return null;
        }

        if (_audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
            StopCoroutine();
        }
    }
}