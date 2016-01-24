using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrinkCrafter : MonoBehaviour {


	Canvas c;

	CameraControl cam;

	int buttonsPushed = 0;
	string butt1, butt2, butt3;
	bool sequenceComplete;

	public Sprite transparent, abutton, bbutton, xbutton, ybutton;
	public Image slot1, slot2, slot3;

	public Image recipeIndicator;
	public Text recipeText;

	public Animator background, content;

	SteeperController control;

	public AudioClip blip_a, blip_b, blip_x, blip_y, success;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		c = GetComponent <Canvas> ();
		cam = Camera.main.gameObject.GetComponent<CameraControl> ();
		aud = GetComponent<AudioSource> ();
		control = GameObject.Find ("STEEPER").GetComponent<SteeperController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (control.grounded) {

			if (Input.GetButtonUp ("Start") && !c.enabled) {
				ResetCrafting ();
				content.enabled = true;
				content.Play("CraftingMenuFadein");
				background.Play("BackgroundFadeIn");
				c.enabled = true;
				cam.crafting = true;
			}
	
			if (c.enabled && !sequenceComplete) {
				/*
			if(Input.GetButtonDown("Cancel") || Input.GetButtonDown("Jump") || Input.GetButtonDown("Triangle") || Input.GetButtonDown("Square")) {
				buttonsPushed += 1;
			} */

				if (buttonsPushed == 0) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot(blip_a);
						butt1 = "A";
						slot1.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot(blip_b);
						butt1 = "B";
						slot1.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot(blip_y);
						butt1 = "Y";
						slot1.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot(blip_x);
						butt1 = "X";
						slot1.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed == 1) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot(blip_a);
						butt2 = "A";
						slot2.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot(blip_b);
						butt2 = "B";
						slot2.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot(blip_y);
						butt2 = "Y";
						slot2.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot(blip_x);
						butt2 = "X";
						slot2.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed == 2) {
					if (Input.GetButtonDown ("Jump")) {
						aud.PlayOneShot(blip_a);
						butt3 = "A";
						slot3.overrideSprite = abutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Cancel")) {
						aud.PlayOneShot(blip_b);
						butt3 = "B";
						slot3.overrideSprite = bbutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Triangle")) {
						aud.PlayOneShot(blip_y);
						butt3 = "Y";
						slot3.overrideSprite = ybutton;
						buttonsPushed += 1;
					}
					if (Input.GetButtonDown ("Square")) {
						aud.PlayOneShot(blip_x);
						butt3 = "X";
						slot3.overrideSprite = xbutton;
						buttonsPushed += 1;
					}
				} else if (buttonsPushed == 3) {
					StartCoroutine(FinishedCrafting());
				}
			}

			if(sequenceComplete) {
				if(Input.GetButtonDown("Cancel")) {
					ResetCrafting();
				}

				if(Input.GetButtonDown("Jump")) {
					StartCoroutine(FinishDrink());
				}
			}

			if (!c.enabled) {
				control.canMove = true;
			} else if (c.enabled) {
				control.canMove = false;
				if (Input.GetButtonUp ("Start") && buttonsPushed > 0) {
					StartCoroutine(FinishDrink());
				}
			}
		}
	}


	IEnumerator FinishedCrafting () {
		CheckSequence (butt1 + butt2 + butt3);
		content.enabled = false;
		sequenceComplete = true;
		yield return new WaitForSeconds (0.15f);
		aud.PlayOneShot (success);
	}

	void ResetCrafting () {
		buttonsPushed = 0;
		sequenceComplete = false;
		recipeText.text = "Enter a Recipe";
		recipeText.color = Color.white;
		recipeIndicator.color = new Color32(30, 43, 58, 255);
		slot1.overrideSprite = transparent;
		slot2.overrideSprite = transparent;
		slot3.overrideSprite = transparent;	
	}

	void CheckSequence (string sequence) {
		switch (sequence) {
		case "AAA":
			recipeText.text = "Black Coffee";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "BAA":
			recipeText.text = "Iced Coffee";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "ABB":
			recipeText.text = "Espresso";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "XXX":
			recipeText.text = "Plain Milk";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "AXA":
			recipeText.text = "Cappuccino";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "ABA":
			recipeText.text = "Americano";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		case "AAY":
			recipeText.text = "Coffee & Sugar";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(122, 244, 66, 255);
			break;
		default:
			recipeText.text = "That's not a drink.";
			recipeText.color = new Color32(30, 43, 58, 255);
			recipeIndicator.color = new Color32(255, 59, 130, 255);
			break;
		}
	}

	IEnumerator FinishDrink () {
		content.enabled = true;
		content.Play ("CraftingMenuFadeOut 1");
		background.Play ("BackgroundFadeOut");
		cam.crafting = false;
		yield return new WaitForSeconds (0.4f);
		c.enabled = false;
	}


	/*
	IEnumerator CraftDrink () {
		while (buttonsPushed == 0) {
			yield return null;
		}
		while (buttonsPushed == 1) {
			yield return null;
		}
		while (buttonsPushed == 2) {
			yield return null;
		}
		while (buttonsPushed == 3) {
			yield return null;
		}
		while (buttonsPushed == 4) {
			yield return null;
		}
	} */

}
