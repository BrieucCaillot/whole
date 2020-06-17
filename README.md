# 🐳 WHOLE

Narrative and immersive experience made with Unity and Kinect v1 in 2019-2020 at Gobelins School.

![Language](https://img.shields.io/badge/Language-C%23-brightgreen.svg)
![Language](https://img.shields.io/badge/Program-Unity-blue.svg)
![Language](https://img.shields.io/badge/Detection-Kinect-black.svg)

![Demo](Assets/Resources/Images/logo.gif)

---

### Architectures

```
Projet
│    README.md
│    .gitignore
│
└─── Assets
│    └─── 3DObjects                    # All 3D Objects
│    └─── Fonts                        # Fonts used with Text Component
│    └─── Librairies
│    │    │   Cinemachine               # Cinemachine
│    │    │   Demigiant                 # DOTween
│    │    │   Kinect                    # Kinect v1 library
│    │
│    └─── Materials
│    │    │   Sea                       # Sea scene's materials
│    │    │   Sky                       # Sky scene's materials
│    │
│    └─── Packages
│    │    │   UnityFBXExporter          # Export GameObject to FBX
│    │
│    └─── Plugins
│    │    │   Github                    # Github interface for Unity
│    │
│    └─── PPProfiles                    # Post-processing profiles
│    │    │   SkyPPProfile
│    │    │   WaterPPProfile
│    │
│    └─── Prefabs
│    │    │   PrefabsAnimations
│    │    │   Sea
│    │    │   Sky
│    │    │   UI
│    │
│    └─── Resources
│    │    └─── Animations
│    │    │    └─── Loader
│    │    │    └─── Positions
│    │    │    │
│    │    └─── Images
│    │
│    └─── Scenes
│    │    │   StartupScene              # First scene - Logo
│    │    │   Birds                     # Second scene - Birds
│    │    │   Boids                     # Last scene - Birds
│    │
│    └─── Scripts
│    │    └─── Camera                   # Camera's scripts
│    │    └─── General                  # General scripts
│    │    └─── Helpers                  # Helpers scripts
│    │    └─── Interactions             # Interactions's scripts
│    │    │    └─── Gestures
│    │    │    │    │   Gesture.cs                      # Handle Kinect's gestures status (Completed - Progress - Canceled)
│    │    │    │    │   PsiGesture.cs                   # Kinect Psi position
│    │    │    │    │   SquatGesture.cs                 # Kinect Squat position
│    │    │    │    │   TPoseGesture.cs                 # Kinect T position
│    │    │    │    │   UserDetectedInteraction.cs      # Triggered when users detected by Kinect
│    │    │    │    │   UserKinectPosition.cs           # Get position of users
│    │    │    │
│    │    │    └─── prefabScripts (Check how it works below)
│    │    │    │    │   DefaultInteracton.prefab
│    │    │    │    │   PsiInteraction.prefab
│    │    │    │    │   SpacebarInteraction.prefab
│    │    │    │    │   SquatInteraction.prefab
│    │    │    │    │   TPoseInteraction.prefab
│    │    │    │    │   UserDetectedInteraction.prefab
│    │    │    │    │   UserKinectPosition.prefab
│    │    │    │
│    │    │    └─── Scripts
│    │    │    │    │   DefaultInteracton.cs
│    │    │    │    │   PsiInteraction.cs
│    │    │    │    │   SpacebarInteraction.cs
│    │    │    │    │   SquatInteraction.cs
│    │    │    │    │   TPoseInteraction.cs
│    │    │    │    │   UserDetectedInteraction.cs
│    │    │    │    │   UserKinectPosition.cs
│    │    │    │
│    │    └─── Sea
│    │    │    └─── Boid
│    │    │    │    │   ...
│    │    │    │
│    │    │    └─── Camera
│    │    │    │    │   ...
│    │    │    │
│    │    │    └─── CurvedLines(SeaCurrents)
│    │    │    │    │   ...
│    │    │    │
│    │    └─── Sea
│    │    │    └─── BezierRoutes
│    │    │    │    │   ...
│    │    │    │
│    │    │    └─── Helpers
│    │    │    │    │   ...
│    │    │    │
│    │    └─── UI
│    │    │    │    AudioManager.cs                   # Manage Ambiant Sound
│    │    │    │    InteractionsList.cs               # List all interactions
│    │    │    │    IntroManager.cs                   # Manage Intro screen
│    │    │    │    PictoLoadingManager.cs            # Manage loader progress
│    │    │    │    PictosPositionsManager.cs         # Manage picto inside loader
│    │    │    │    SubtitleManager.cs                # Manage subtitles
│    │    │    │    VoiceoverManager.cs               # Manage voiceovers
│    │    │
│    └─── Shaders
│    │    └─── Sea
│    │
│    └─── Standard Assets
│    │    └─── Effects
│    │    │    └─── Projectors
│    │    └─── Environement
│    │    │    └─── Water
│    │
│    └─── Streaming Assets
│    │    └─── Audio
│    │    │    └─── Sounds                            # Ambient sounds
│    │    │    └─── Voiceover                         # Voiceover audios
│    │    │    └─── Voiceover                         # Voiceover audios
│    │    └─── Subtitles                              # Json subtitles
│    │
│    └─── Textures
│    │    └─── Sea
│    │    │    └─── Corals
│    │    │    └─── Currents
│    │    │    └─── Fishs
│    │    │    └─── Ground
│    │    │    └─── Rock
│    │    └─── Sky
│    │    │    └─── Mountains
│    │    │    └─── Ocean
│    │    │
│    └─── Timelines


```

---

### Scenes managment

You can run each scene separatly for development purposes. But the production scene is "StartupScene" which uses the kinect manager and load every scene asynchronously depending on the users interactions.

### Interaction Managment

If you want to use interactions outside of the StartupScene, you will need to create a GameManager and InteractionManager. but you will have to remove it for development and use the GameManager and InteractionManager in the StartupScene. 

To add a new interaction in the interactionManager, you will need to create a GameObject, and add the script with the interaction you want to use. If the interaction you want does not exist yet, you can create your own script and extend it with Interactions.cs. it just need to return true in the Listen function when the interaction is completed. When the gameObject is created you can drag it to the interaction list in the interaction manager. 

Each interaction GameObject should have an string "action" that triggers a function in the GameManager, is defined. if the interaction have a pictogram attached and audio, you have to select the InteractionKey corresponding to the audio/picto defined in InteractionList.cs and enable "hasPicto".

To prevent the interaction to abort too soon, you can enter the audio duration in the GameObject and add an additional delay if needed. 

If you want to trigger the onComplete event somewhere outside of the interaction script, you can uncheck "Handle on Complete". 

Each interaction is enabled one after the other depending on the order of the interactions array, when the complete function is called.

### Kinect managment

If you are working without the kinect device, you can still run the scenes just by removing every interaction using the kinect, you might have warnings but you can just ignore them.

To make the kinect work : ??

If you want to create a new kind of interaction with the kinect you will need to create a KinectGesture GameObject linked to a new GestureScript that you need to create.

### Credits

- [Serge Bocancea](https://fr.linkedin.com/in/serge-bocancea-70868a152) 👨‍💻
- [Brieuc Caillot](https://www.linkedin.com/in/brieuccaillot/) 👨‍💻
- [Léo Mouraire](https://leomouraire.com) 👨‍💻
- [Pauline Fuchs](https://fr.linkedin.com/in/pauline-fuchs) 👩‍💻
- [Emma Rimbert](https://fr.linkedin.com/in/emma-rimbert-09470319b) 👩‍💻
