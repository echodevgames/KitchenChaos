using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSounds : MonoBehaviour
{
    private PlayerController playerController;
    private float footstepTimer;
    private float footstepTimerMax = .1f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;
            if (playerController.IsWalking()) 
            { 
                float volume = 3f;
                SoundManager.Instance.PlayFootstepsSound(playerController.transform.position, volume);
            } 
        }
    }
}
