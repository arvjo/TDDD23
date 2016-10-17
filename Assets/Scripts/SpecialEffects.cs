using UnityEngine;
using System.Collections;

public class SpecialEffects : MonoBehaviour {

    public static SpecialEffects Instance;

    public ParticleSystem fireEffect;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

   
    public void Explosion(Vector3 position)
    {      
        instantiate(fireEffect, position);
    }

    /// Instantiate a Particle system from prefab
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }

}
