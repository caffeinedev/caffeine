using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrinkCrafter : MonoBehaviour
{


	Canvas c;
	CameraControl cam;
	int buttonsPushed = 0;
	string butt1, butt2, butt3, drinkMade;
	bool sequenceComplete, drinkSuccessful, canCraft, poor;
	public Sprite transparent, abutton, bbutton, xbutton, ybutton;
	public Image slot1, slot2, slot3;
	public Image recipeIndicator;
	public Text recipeText;
	public GameObject basicCoffee, icedCoffee, espresso, plainMilk;
	public Transform drinkAnchor;
	public Animator background, content, anim;
	public AudioClip blip_a, blip_b, blip_x, blip_y, success;
	AudioSource aud;

	GameManager manager;


	// Use this for initialization
	void Start ()
	{
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		c = GetComponent <Canvas> ();
		cam = Camera.main.gameObject.GetComponent<CameraControl> ();
		aud = GetComponent<AudioSource> ();
		anim = manager.control.gameObject.GetComponent<Animator> ();
		canCraft = true;
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (sequenceComplete && cam.crafting) {
			if (Input.GetButtonUp ("LT")) {
				FinishDrink ();
			}
		}

		if (Input.GetButtonUp ("LT") && !sequenceComplete && cam.crafting) {
			ResetCrafting();
			drinkSuccessful = false;
			FinishDrink();
		}


		/*
		if (!cam.crafting && !canCraft && control.carryingDrink) {
			if (Input.GetButtonDown ("Square") && control.grounded) { //change this later to a trigger
				//drinkAnchor.BroadcastMessage ("Throw", control.gameObject.transform.forward);
				canCraft = true;
				sequenceComplete = false;
				control.carryingDrink = false;
				anim.Play ("Throw");
				anim.SetBool("carrying", false);
			}
		} */

		if (!manager.control.carryingDrink && !sequenceComplete && manager.hasbackpack) {
			if (Input.GetButtonDown ("LT") && !cam.crafting && manager.control.grounded && manager.control.canMove) {
				ResetCrafting ();
				manager.tanks.SetBool("crafting", true);
				content.enabled = true;
				content.Play ("CraftingMenuFadein");
				background.Play ("BackgroundFadeIn");
				c.enabled = true;
				cam.crafting = true;
				manager.ShowTanks();
			}

			if (cam.crafting && canCraft) {
				manager.control.canMove = false;

				if (buttonsPushed == 0 && !sequenceComplete) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot (blip_a);
						butt1 = "A";
						slot1.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot (blip_b);
						butt1 = "B";
						slot1.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot (blip_y);
						butt1 = "Y";
						slot1.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot (blip_x);
						butt1 = "X";
						slot1.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed == 1) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot (blip_a);
						butt2 = "A";
						slot2.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot (blip_b);
						butt2 = "B";
						slot2.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot (blip_y);
						butt2 = "Y";
						slot2.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot (blip_x);
						butt2 = "X";
						slot2.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed == 2) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot (blip_a);
						butt3 = "A";
						slot3.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot (blip_b);
						butt3 = "B";
						slot3.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot (blip_y);
						butt3 = "Y";
						slot3.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot (blip_x);
						butt3 = "X";
						slot3.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed > 2) {
					drinkMade = CheckSequence (butt1 + butt2 + butt3);
					if (drinkMade == "That's not a drink." || poor) {
						drinkSuccessful = false;
						StartCoroutine(TimeoutReset());
					} else {
						drinkSuccessful = true;
					}
					canCraft = false;
				}
			}
		}
	}

	public void ResetCrafting ()
	{
		canCraft = true;
		buttonsPushed = 0;
		sequenceComplete = false;
		drinkSuccessful = false;
		manager.control.carryingDrink = false;
		recipeText.text = "Enter a Recipe";
		recipeText.color = Color.white;
		recipeIndicator.color = new Color32 (30, 43, 58, 255);
		slot1.overrideSprite = transparent;
		slot2.overrideSprite = transparent;
		slot3.overrideSprite = transparent;	
	}

	string CheckSequence (string sequence)
	{
		poor = false;
		switch (sequence) {
		case "AAA":
			if(manager.coffee.value >= 10) {
			recipeText.text = "Black Coffee";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			} else poor = true;
			break;
		case "BAA":
			if(manager.coffee.value >= 10) {
			recipeText.text = "Iced Coffee";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			} else poor = true;
			break;
		case "ABA":
			if(manager.coffee.value >= 20) {
			recipeText.text = "Espresso";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			} else poor = true;
			break;
		case "YYY":
			if(manager.milk.value >= 10) {
			recipeText.text = "Plain Milk";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			} else poor = true;
			break;
		case "AXA":
			recipeText.text = "Cappuccino";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			break;
		case "ABB":
			recipeText.text = "Americano";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			break;
		case "AAY":
			recipeText.text = "Coffee & Sugar";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (122, 244, 66, 255);
			break;
		default:
			recipeText.text = "That's not a drink.";
			recipeText.color = new Color32 (30, 43, 58, 255);
			recipeIndicator.color = new Color32 (255, 59, 130, 255);
			break;
		}

		sequenceComplete = true;
		return recipeText.text;
	}

	void FinishDrink ()
	{
		manager.control.canMove = true;
		cam.crafting = false;
		c.enabled = false;
		content.Play ("CraftingMenuFadeOut 1");
		background.Play ("BackgroundFadeOut");
		if (drinkSuccessful) {  //spawn the drink.
			drinkSuccessful = false; //dont want to spawn multiple ever
			aud.PlayOneShot(success);
			manager.control.carryingDrink = true;
			manager.uiLabels[3].text = "Throw";
			anim.SetTrigger ("pickup");
			anim.SetBool ("carrying", true);
			//	yield return new WaitForSeconds(0.2f);
			switch (drinkMade) {
			case "Iced Coffee":
				GameObject icedDrink = GameObject.Instantiate (icedCoffee) as GameObject;
				icedDrink.name = "Basic Coffee";
				manager.coffee.value -= 10;
				icedDrink.transform.position = drinkAnchor.position;
				icedDrink.transform.rotation = drinkAnchor.rotation;
				icedDrink.transform.parent = drinkAnchor;
				break;
			case "Espresso":
				GameObject espressoDrink = GameObject.Instantiate (espresso) as GameObject;
				espressoDrink.name = "Espresso";
				manager.coffee.value -= 20;
				espressoDrink.transform.position = drinkAnchor.position;
				espressoDrink.transform.rotation = drinkAnchor.rotation;
				espressoDrink.transform.parent = drinkAnchor;
				break;
			case "Plain Milk":
				GameObject plainMilkDrink = GameObject.Instantiate (plainMilk) as GameObject;
				manager.milk.value -= 20;
				plainMilkDrink.name = "Plain Milk";
				plainMilkDrink.transform.position = drinkAnchor.position;
				plainMilkDrink.transform.rotation = drinkAnchor.rotation;
				plainMilkDrink.transform.parent = drinkAnchor;
				break;
			default:
				GameObject basicDrink = GameObject.Instantiate (basicCoffee) as GameObject;
				manager.coffee.value -= 10;
				basicDrink.name = "Iced Coffee";
				basicDrink.transform.position = drinkAnchor.position;
				basicDrink.transform.rotation = drinkAnchor.rotation;
				basicDrink.transform.parent = drinkAnchor;
				break;
			}
		}
		canCraft = false;
		manager.tanks.SetBool("crafting", false);
	}

	IEnumerator TimeoutReset () {
		yield return new WaitForSeconds(1.4f);
		ResetCrafting ();
	}
	

}
