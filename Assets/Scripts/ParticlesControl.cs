using UnityEngine;

public class ParticlesControl : MonoBehaviour
{
    [SerializeField]  ParticleSystem _explodeParticlePrefab;
    public void SetStartDelay()
    {

        _explodeParticlePrefab = GetComponent<ParticleSystem>();
        _explodeParticlePrefab.Stop();

        var particleMainSettings = _explodeParticlePrefab.main;
        particleMainSettings.startDelay = 1f;
        _explodeParticlePrefab.Play();
        Debug.Log("testing"+ _explodeParticlePrefab);
    }
}
