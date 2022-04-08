# Thesis-FinalPrototype-OculusQuest2-MR
## detection link
https://jieguann.github.io/Thesis-FinalPrototype-OculusQuest2-MR/WebcamDetection/index.html



## Oculus Quest 2 Develop in Unity Study
### Unity setup
Use the traditional 3D platform, nor URP or WURP
https://skarredghost.com/2021/10/01/how-to-passthrough-ar-oculus-quest-unity/
### Passthrough API Setup
* Add OVR Passthrough Layer in OVRCameraRig or its paraent.
  * Keep the placement of OVerlay  
  * Set the opacity to 0 (the opacity of the background, can be used to blend with the virtual background).
  * Locate the the OVRCameraRig -> Tracking Space -> Centrer EyeAnchor, set the Background Type to Solid Color, and the Backgound color to black and alpha to 0.
  * Manipulate the alpha of the Centre EyeAnchor to switch vetween vr and mr.
* For any objects would like to display in Mixed Reality, Add OVR Passthrough Layer to it or its paraent.
  * Change the Placement to Underlay
* To record the Mixed Rality experience in oculus quest 2.
  * For the privacy, Meta has block the record methord natively, and it only display black when record on the mobile phone or sidequest.
  * One of the methord is using a mobile phone and attach it inside the headset to record the experience. <br> <img src="https://user-images.githubusercontent.com/60665347/156825963-d9e56d8d-a956-4eb7-ac1f-b7c44d13bd0b.jpg" alt="drawing" width="100"/>
  * Build with Android and run in Oculus Quest 2, and stream with sideQuest.<br>https://skarredghost.com/2021/10/01/how-to-passthrough-ar-oculus-quest-unity/
  * Go to Oculus -> Tools and select OVR Performance Lint Tool. Enlarge a bit the dialog that pops up. Expand the “Quest Issues” label and click the “Fix” buttons of the following voices, in this exact order: “Optimize Scripting Backend”, “Set Android Target SDK Level”, and “Set Target Architecture to ARM64” (this as the last one). Doing this we enable IL2CPP and ARM64 support, that are also required to publish on the store nowadays
### Hand Tracking Interaction
* Basic Grab
  * Pinch Grab
  * Palm Grab
  * Combination
* Hand Pose (Gesture)
  * Stop - Open five fingers
  * Scissors - Shake hand

###  Anchor the virtual objects in the physical environemt
*  Keyborad anchord the virtual object.
*  Move the virtual planets to simulate the movement of the spaceship since it is hard to move the virtual object and the camera at the same time.
### Limitation 
*  The Mixed Reality experience is Black and White because of the limitation of the Cemera on the device.
*  Tracking, only keyboard could be used to anchor virtual object persistently. The controller will disable when put down and it can not use together with hand tracking.

### Comparare to Other device
Price

### The Interaction with the physical environment
Hand Tracking will not working due to it require a lighting environment. When the intersity of light is low, the hand Tracking will lose. Hence, using the controller is a good choise at this time.



### Spaceship Control
*  The bulb will need to attach to the top of the joystick to control the spaceship. The bulb represent a clue between virtual and physical.
*  The planets are in front of the space, and once the spaceship near one of the planet, it will land on it automatically and the physical phylip hue will turn to that color.




## Philip Hue Color Control

Similar to prototype 2, http put

rgb to xy

require a flag to trigger the light in http put
```ruby
  private void OnTriggerEnter(Collider other)
    {if(flag == true)
        {
            if (other.tag == "bulb")
            {
                turnOnLight = StartCoroutine(control.HttpPutLight(1f, 1f, 1f, 255, true));
                StopCoroutine(turnOnLight);
                flag = false;            
            }
        }
        
    }
```

## CocoSSD object detection
*  human detection, for the time on MR zone that affect the tree growing.
*  If a "teddy bear" appear, the MR Environment will showing some heart. <br/> <img src="https://user-images.githubusercontent.com/60665347/157285082-8bb4b555-f848-456b-be7e-59f51243fb37.jpg" alt="drawing" width="100"/> 
*  If a "wine glass" present, the MR Environemnt will have wine flow. <br/><img src="https://user-images.githubusercontent.com/60665347/157285875-93437da3-8647-43ea-8cdf-64b34475e101.jpg" alt="drawing" width="100"/> 

*  If a mobile phone present, fire explosion will appear.
*  Particle effect is present with https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325?locale=zh-CN in Unity
