using UnityEngine;

public class UIController : MonoBehaviour
{

    public AudioController _audioController;
    public SubtitleController _subtitleController;
    
    private int interactionNumber = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {    
            PlayUI();
        }
    }

    public void PlayUI()
    {
        if (!_audioController.getActive() && !_subtitleController.getActive())
        {
            interactionNumber++;
            _audioController.PlayAudio(interactionNumber);
            _subtitleController.GetSubtitles(interactionNumber);
        }
    }
}
