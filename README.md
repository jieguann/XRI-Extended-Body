# Thesis-FinalPrototype-OculusQuest2-MR

## Oculus Quest 2 Develop in Unity Study
### Passthrough API Setup
* Add OVR Passthrough Layer in OVRCameraRig or its paraent.
  * Keep the placement of OVerlay  
  * Set the opacity to 0 (the opacity of the background, can be used to blend with the virtual background).
  * Locate the the OVRCameraRig -> Tracking Space -> Centrer EyeAnchor, set the Background Type to Solid Color, and the Backgound color to black and alpha to 0.
* For any objects would like to display in Mixed Reality, Add OVR Passthrough Layer to it or its paraent.
  * Change the Placement to Underlay
* To record the Mixed Rality experience in oculus quest 2.
  * For the privacy, Meta has block the record methord natively, and it only display black when record on the mobile phone or sidequest.
  * The only method I find is using a mobile phone and attach it inside the headset to record the experience.
<img src="https://user-images.githubusercontent.com/60665347/156825963-d9e56d8d-a956-4eb7-ac1f-b7c44d13bd0b.jpg" alt="drawing" width="200"/>

### Hand Tracking Interaction

### Limitation 
Black and white
Tracking, only keyboard to anchor virtual object, the controller disable when put down
