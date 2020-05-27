using UnityEngine;

public class UIController : MonoBehaviour
{

    public AudioManager _AudioManager;
    public VoiceoverManager _VoiceoverManager;
    public SubtitleManager _SubtitleManager;
    
    private int interactionNumber = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayVoiceoverAndSubtitles();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            _AudioManager.PauseSound();
            _AudioManager.PlaySound("Weather/Wind");
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            _AudioManager.PauseSound();
            _AudioManager.PlaySound("Water/Underwater");
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            _AudioManager.PauseSound();
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _AudioManager.UnPauseSound();
        }
    }

    public void PlayVoiceoverAndSubtitles()
    {
        if (!_VoiceoverManager.GetActive() && !_SubtitleManager.GetActive())
        {
            interactionNumber++;
            _VoiceoverManager.PlayVoiceover(interactionNumber);
            _SubtitleManager.GetSubtitles(interactionNumber);
        }
    }
}
