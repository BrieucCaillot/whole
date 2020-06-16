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

### Credits

- [Serge Bocancea](https://fr.linkedin.com/in/serge-bocancea-70868a152) 👨‍💻
- [Brieuc Caillot](https://www.linkedin.com/in/brieuccaillot/) 👨‍💻
- [Léo Mouraire](https://fr.linkedin.com/in/l%C3%A9o-mouraire-5b53b8143) 👨‍💻
- [Pauline Fuchs](https://fr.linkedin.com/in/pauline-fuchs) 👩‍💻
- [Emma Rimbert](https://fr.linkedin.com/in/emma-rimbert-09470319b) 👩‍💻
