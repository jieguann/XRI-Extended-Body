using UnityEngine;
using System.Collections;

public class AnimationDemo : MonoBehaviour
{
	public GameObject spaceship;
	public GameObject cannon01;
	public GameObject cannon02A;
	public GameObject cannon02B;
	public GameObject cannon03A;
	public GameObject cannon03B;
    public GameObject wallElectronics001;
    public GameObject console;
    public GameObject bunkBed;
    public GameObject locker1;
    public GameObject locker2;
	
	public GameObject[]  cameras;
	
	private bool landingGears = false;
	private bool engines = false;
	private bool cockpitDoors = false;
	private bool exteriorHatch = false;
	private bool interiorHatch = false;
	private bool gunnerSeat = false;
	private bool pilotSeat = false;
	private bool ladder = false;
    private bool boxLeverAnim = false;
    private bool consoleAnim = false;
    private bool bunkBedAnim = false;
    private bool lockersAnim = false;
	private int cameraSelection = 1;
	
	void Start ()
	{
		spaceship.GetComponent<Animation>()["LandingGears"].layer = 1;
		spaceship.GetComponent<Animation>()["Engines"].layer = 2;
		spaceship.GetComponent<Animation>()["CockpitDoors"].layer = 3;
		spaceship.GetComponent<Animation>()["ExteriorHatch"].layer = 4;
		spaceship.GetComponent<Animation>()["InteriorHatch"].layer = 5;
		spaceship.GetComponent<Animation>()["GunnerSeat"].layer = 6;
		spaceship.GetComponent<Animation>()["PilotSeat"].layer = 7;
		spaceship.GetComponent<Animation>()["Ladder"].layer = 8;

        locker1.GetComponent<Animation>()["LockerDoor"].layer = 1;
        locker1.GetComponent<Animation>()["LockerDrawer"].layer = 2;
        locker2.GetComponent<Animation>()["LockerDoor"].layer = 1;
        locker2.GetComponent<Animation>()["LockerDrawer"].layer = 2;

        bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].layer = 1;
        bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].layer = 2;
        bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].layer = 3;
        bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].layer = 4;
    }
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(20, 20, 100, 30),"Switch Camera"))
		{
			if (cameraSelection == 0)
			{
				cameras[cameras.Length - 1].SetActive(false);
			}
			else
			{
				cameras[cameraSelection - 1].SetActive(false);
			}
			
			cameras[cameraSelection].SetActive(true);
			cameraSelection++;
			
			if (cameraSelection >= cameras.Length)
			{
				cameraSelection = 0;
			}
		}
		
		if (GUI.Button(new Rect(20, 80, 100, 30),"Landing Gears"))
		{
			if (!landingGears)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("LandingGears"))
				{
					spaceship.GetComponent<Animation>()["LandingGears"].speed = 1;
					spaceship.GetComponent<Animation>()["LandingGears"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("LandingGears");
					
					landingGears = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("LandingGears"))
				{
					spaceship.GetComponent<Animation>()["LandingGears"].speed = -1;
					spaceship.GetComponent<Animation>()["LandingGears"].time = spaceship.GetComponent<Animation>()["LandingGears"].length;
				
					spaceship.GetComponent<Animation>().Play("LandingGears");
					
					landingGears = false;
				}
			}
		}
		
		
		if (GUI.Button(new Rect(20, 120, 100, 30),"Engines"))
		{
			if (!engines)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("Engines"))
				{
					spaceship.GetComponent<Animation>()["Engines"].speed = 1;
					spaceship.GetComponent<Animation>()["Engines"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("Engines");
					
					engines = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("Engines"))
				{
					spaceship.GetComponent<Animation>()["Engines"].speed = -1;
					spaceship.GetComponent<Animation>()["Engines"].time = spaceship.GetComponent<Animation>()["Engines"].length;
				
					spaceship.GetComponent<Animation>().Play("Engines");
					
					engines = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 160, 100, 30),"Recoil"))
		{
			if (!cannon01.GetComponent<Animation>().isPlaying && !cannon02A.GetComponent<Animation>().isPlaying && !cannon02B.GetComponent<Animation>().isPlaying && !cannon03A.GetComponent<Animation>().isPlaying && !cannon03B.GetComponent<Animation>().isPlaying)
			{
				cannon01.GetComponent<Animation>().Play();
				cannon02A.GetComponent<Animation>().Play();
				cannon02B.GetComponent<Animation>().Play();
				cannon03A.GetComponent<Animation>().Play();
				cannon03B.GetComponent<Animation>().Play();
			}
		}
		
		if (GUI.Button(new Rect(20, 220, 100, 30),"Cockpit Doors"))
		{
			if (!cockpitDoors)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("CockpitDoors"))
				{
					spaceship.GetComponent<Animation>()["CockpitDoors"].speed = 1;
					spaceship.GetComponent<Animation>()["CockpitDoors"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("CockpitDoors");
					
					cockpitDoors = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("CockpitDoors"))
				{
					spaceship.GetComponent<Animation>()["CockpitDoors"].speed = -1;
					spaceship.GetComponent<Animation>()["CockpitDoors"].time = spaceship.GetComponent<Animation>()["CockpitDoors"].length;
				
					spaceship.GetComponent<Animation>().Play("CockpitDoors");
					
					cockpitDoors = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 260, 100, 30),"Exterior Hatch"))
		{
			if (!exteriorHatch)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("ExteriorHatch"))
				{
					spaceship.GetComponent<Animation>()["ExteriorHatch"].speed = 1;
					spaceship.GetComponent<Animation>()["ExteriorHatch"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("ExteriorHatch");
					
					exteriorHatch = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("ExteriorHatch"))
				{
					spaceship.GetComponent<Animation>()["ExteriorHatch"].speed = -1;
					spaceship.GetComponent<Animation>()["ExteriorHatch"].time = spaceship.GetComponent<Animation>()["ExteriorHatch"].length;
				
					spaceship.GetComponent<Animation>().Play("ExteriorHatch");
					
					exteriorHatch = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 300, 100, 30),"Interior Hatch"))
		{
			if (!interiorHatch)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("InteriorHatch"))
				{
					spaceship.GetComponent<Animation>()["InteriorHatch"].speed = 1;
					spaceship.GetComponent<Animation>()["InteriorHatch"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("InteriorHatch");
					
					interiorHatch = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("InteriorHatch"))
				{
					spaceship.GetComponent<Animation>()["InteriorHatch"].speed = -1;
					spaceship.GetComponent<Animation>()["InteriorHatch"].time = spaceship.GetComponent<Animation>()["InteriorHatch"].length;
				
					spaceship.GetComponent<Animation>().Play("InteriorHatch");
					
					interiorHatch = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 340, 100, 30),"Gunner Seat"))
		{
			if (!gunnerSeat)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("GunnerSeat"))
				{
					spaceship.GetComponent<Animation>()["GunnerSeat"].speed = 1;
					spaceship.GetComponent<Animation>()["GunnerSeat"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("GunnerSeat");
					
					gunnerSeat = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("GunnerSeat"))
				{
					spaceship.GetComponent<Animation>()["GunnerSeat"].speed = -1;
					spaceship.GetComponent<Animation>()["GunnerSeat"].time = spaceship.GetComponent<Animation>()["GunnerSeat"].length;
				
					spaceship.GetComponent<Animation>().Play("GunnerSeat");
					
					gunnerSeat = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 380, 100, 30),"Pilot Seat"))
		{
			if (!pilotSeat)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("PilotSeat"))
				{
					spaceship.GetComponent<Animation>()["PilotSeat"].speed = 1;
					spaceship.GetComponent<Animation>()["PilotSeat"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("PilotSeat");
					
					pilotSeat = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("PilotSeat"))
				{
					spaceship.GetComponent<Animation>()["PilotSeat"].speed = -1;
					spaceship.GetComponent<Animation>()["PilotSeat"].time = spaceship.GetComponent<Animation>()["PilotSeat"].length;
				
					spaceship.GetComponent<Animation>().Play("PilotSeat");
					
					pilotSeat = false;
				}
			}
		}
		
		if (GUI.Button(new Rect(20, 420, 100, 30),"Ladder"))
		{
			if (!ladder)
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("Ladder"))
				{
					spaceship.GetComponent<Animation>()["Ladder"].speed = 1;
					spaceship.GetComponent<Animation>()["Ladder"].time = 0;
				
					spaceship.GetComponent<Animation>().Play("Ladder");
					
					ladder = true;
				}
			}
			else
			{
				if (!spaceship.GetComponent<Animation>().IsPlaying("Ladder"))
				{
					spaceship.GetComponent<Animation>()["Ladder"].speed = -1;
					spaceship.GetComponent<Animation>()["Ladder"].time = spaceship.GetComponent<Animation>()["Ladder"].length;
				
					spaceship.GetComponent<Animation>().Play("Ladder");
					
					ladder = false;
				}
			}
		}

        if (GUI.Button(new Rect(130, 220, 100, 30), "Box Lever"))
        {
            if (!boxLeverAnim)
            {
                if (!wallElectronics001.GetComponent<Animation>().IsPlaying("WallElectronics_001_Lever"))
                {
                    wallElectronics001.GetComponent<Animation>()["WallElectronics_001_Lever"].speed = 1;
                    wallElectronics001.GetComponent<Animation>()["WallElectronics_001_Lever"].time = 0;

                    wallElectronics001.GetComponent<Animation>().Play("WallElectronics_001_Lever");

                    boxLeverAnim = true;
                }
            }
            else
            {
                if (!wallElectronics001.GetComponent<Animation>().IsPlaying("WallElectronics_001_Lever"))
                {
                    wallElectronics001.GetComponent<Animation>()["WallElectronics_001_Lever"].speed = -1;
                    wallElectronics001.GetComponent<Animation>()["WallElectronics_001_Lever"].time = wallElectronics001.GetComponent<Animation>()["WallElectronics_001_Lever"].length;

                    wallElectronics001.GetComponent<Animation>().Play("WallElectronics_001_Lever");

                    boxLeverAnim = false;
                }
            }
        }

        if (GUI.Button(new Rect(130, 260, 100, 30), "Console"))
        {
            if (!consoleAnim)
            {
                if (!console.GetComponent<Animation>().IsPlaying("Console"))
                {
                    console.GetComponent<Animation>()["Console"].speed = 1;
                    console.GetComponent<Animation>()["Console"].time = 0;

                    console.GetComponent<Animation>().Play("Console");

                    consoleAnim = true;
                }
            }
            else
            {
                if (!console.GetComponent<Animation>().IsPlaying("Console"))
                {
                    console.GetComponent<Animation>()["Console"].speed = -1;
                    console.GetComponent<Animation>()["Console"].time = console.GetComponent<Animation>()["Console"].length;

                    console.GetComponent<Animation>().Play("Console");

                    consoleAnim = false;
                }
            }
        }

        if (GUI.Button(new Rect(130, 300, 100, 30), "Lockers"))
        {
            if (!lockersAnim)
            {
                if (!locker1.GetComponent<Animation>().IsPlaying("LockerDoor"))
                {
                    locker1.GetComponent<Animation>()["LockerDoor"].speed = 1;
                    locker1.GetComponent<Animation>()["LockerDoor"].time = 0;
                    locker1.GetComponent<Animation>()["LockerDrawer"].speed = 1;
                    locker1.GetComponent<Animation>()["LockerDrawer"].time = 0;

                    locker2.GetComponent<Animation>()["LockerDoor"].speed = 1;
                    locker2.GetComponent<Animation>()["LockerDoor"].time = 0;
                    locker2.GetComponent<Animation>()["LockerDrawer"].speed = 1;
                    locker2.GetComponent<Animation>()["LockerDrawer"].time = 0;

                    locker1.GetComponent<Animation>().Play("LockerDoor");
                    locker1.GetComponent<Animation>().Play("LockerDrawer");
                    locker2.GetComponent<Animation>().Play("LockerDoor");
                    locker2.GetComponent<Animation>().Play("LockerDrawer");

                    lockersAnim = true;
                }
            }
            else
            {
                if (!console.GetComponent<Animation>().IsPlaying("LockerDoor"))
                {
                    locker1.GetComponent<Animation>()["LockerDoor"].speed = -1;
                    locker1.GetComponent<Animation>()["LockerDoor"].time = locker1.GetComponent<Animation>()["LockerDoor"].length;
                    locker1.GetComponent<Animation>()["LockerDrawer"].speed = -1;
                    locker1.GetComponent<Animation>()["LockerDrawer"].time = locker1.GetComponent<Animation>()["LockerDrawer"].length;

                    locker2.GetComponent<Animation>()["LockerDoor"].speed = -1;
                    locker2.GetComponent<Animation>()["LockerDoor"].time = locker2.GetComponent<Animation>()["LockerDoor"].length;
                    locker2.GetComponent<Animation>()["LockerDrawer"].speed = -1;
                    locker2.GetComponent<Animation>()["LockerDrawer"].time = locker2.GetComponent<Animation>()["LockerDrawer"].length;

                    locker1.GetComponent<Animation>().Play("LockerDoor");
                    locker1.GetComponent<Animation>().Play("LockerDrawer");
                    locker2.GetComponent<Animation>().Play("LockerDoor");
                    locker2.GetComponent<Animation>().Play("LockerDrawer");

                    lockersAnim = false;
                }
            }
        }

        if (GUI.Button(new Rect(130, 340, 100, 30), "Bunk Bed"))
        {
            if (!bunkBedAnim)
            {
                if (!bunkBed.GetComponent<Animation>().IsPlaying("BunkBedDrawer_BottomLeft"))
                {
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].speed = 1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].time = 0;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].speed = 1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].time = 0;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].speed = 1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].time = 0;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].speed = 1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].time = 0;

                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_BottomLeft");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_BottomRight");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_TopLeft");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_TopRight");

                    bunkBedAnim = true;
                }
            }
            else
            {
                if (!bunkBed.GetComponent<Animation>().IsPlaying("BunkBedDrawer_BottomLeft"))
                {
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].speed = -1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].time = bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomLeft"].length;

                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].speed = -1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].time = bunkBed.GetComponent<Animation>()["BunkBedDrawer_BottomRight"].length;

                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].speed = -1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].time = bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopLeft"].length;

                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].speed = -1;
                    bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].time = bunkBed.GetComponent<Animation>()["BunkBedDrawer_TopRight"].length;

                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_BottomLeft");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_BottomRight");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_TopLeft");
                    bunkBed.GetComponent<Animation>().Play("BunkBedDrawer_TopRight");

                    bunkBedAnim = false;
                }
            }
        }
    }
}
