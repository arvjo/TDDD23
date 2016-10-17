using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

    public static SoundEffects Instance;

    public AudioClip explosionSound;
    public AudioClip ShotSound;
   

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound(Vector3 pos)
    {
        MakeSound(explosionSound, pos);
    }

    public void MakePlayerShotSound(Vector3 pos)
    {
        MakeSound(ShotSound,pos);
    }

    
    /// Play a given sound
 
    private void MakeSound(AudioClip originalClip, Vector3 pos )
    {     
        AudioSource.PlayClipAtPoint(originalClip, pos);
    }
}
