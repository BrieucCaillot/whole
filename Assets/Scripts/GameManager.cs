public class GameManager : Singleton<GameManager>
{
    public static int SceneNumber = 0;
    public static int InteractionNumber = 0;

    public static void NewInteraction()
    {
        if (!VoiceoverManager.Instance.IsPlaying() && !SubtitleManager.Instance.IsActive())
        {
            InteractionNumber++;
            VoiceoverManager.Instance.PlayVoiceover();
            SubtitleManager.Instance.GetSubtitles();
        }
    }

    // public Dictionary<string, Action> actions = new Dictionary<string, Action>()
    // {
    //     {"vPosition", () => BirdsBehavior.vPosition() },
    //     {"dive", () => BirdsBehavior.dive() }
    // };


    // public InteractionManager interactionManager;
    // public BirdsBehavior birdsBehavior;
    //
    // public void InteractionHandler(Interaction interaction)
    // {
    //     // actions[interaction.action]();
    // }
    //
    // void InteractionCompleteHandler()
    // {
    //     // int currentIndex = InteractionManager.GetIndex();
    //     // InteractionManager.SetIndex(currentIndex + 1);
    // }
}