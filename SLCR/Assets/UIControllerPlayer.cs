using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerPlayer : MonoBehaviour
{
    // Crosshair for player to use for gun.
    public GameObject reticle;

    // Player HUD containing health bar and ammo counter.
    public GameObject playerHUD;

    // Player Health Bar on Player HUD.
    public RectTransform playerHealthBackbar;
    public RectTransform playerHealthFrontbar;
    public Text playerHealthText;

    // Player Health Bar on Player HUD.
    public RectTransform playerAmmoBackbar;
    public RectTransform playerAmmoFrontbar;
    public Text playerAmmoText;

    public PlayerController player;

    // UI Panel to pop up when player wants to pause the game.
    public GameObject PauseMenu;
    // Resume Game Button found under Pause Menu.
    public Button resumeButton;
    // Pause Game Flag.
    public Text pauseMenuText;
    // Pause Menu / Start Menu Flag.
    public bool paused;
    public bool menuEnabled;
    // UI Panel to pop up when Player wins the game.
    public GameObject WinScreen;

    public Button restartButton;

    // UI Panel to pop up when Player health is below Zero.
    public GameObject DeathScreen;
    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.SetActive(false);
        DeathScreen.SetActive(false);
        playerHUD.SetActive(false);
        reticle.SetActive(false);
        PauseMenu.SetActive(true);
        resumeButton.onClick.AddListener(PauseMenuController);
        menuEnabled = true;
        paused = true;
        restartButton.interactable = true;
        player.onHealthChange.AddListener(UpdateHealth);
        player.weaponCheck.AddListener(UpdateAmmo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseMenuController()
    {
        if (paused)
        {
            PauseMenu.SetActive(false);
            menuEnabled = false;
            paused = false;
            resumeButton.interactable = false;
            reticle.SetActive(true);
            playerHUD.SetActive(true);
            UpdateHealth();
            UpdateAmmo();

            Debug.Log("Game Resumed");
        }
        else
        {
            pauseMenuText.text = "Game Paused";
            PauseMenu.SetActive(true);
            menuEnabled = true;
            paused = true;
            resumeButton.interactable = true;
            reticle.SetActive(false);
            playerHUD.SetActive(false);
            UpdateHealth();
            UpdateAmmo();

            Debug.Log("Game Paused");
        }
    }

    public void UpdateHealth()
    {

        if (player.equipedWeapon.loadedAmmoCount >= 0)
            playerHealthFrontbar.localScale = new Vector3(playerHealthBackbar.sizeDelta.x * ((float)player.health / player.maxHealth) * 2, 1, 1);
        else
            playerHealthFrontbar.localScale = new Vector3(0, 1, 1);
        playerHealthText.text = player.health + "/" + player.maxHealth;
        Debug.Log(player.health);
    }

    public void UpdateAmmo()
    {
        if (player.equipedWeapon.loadedAmmoCount >= 0)
        {
            playerAmmoFrontbar.localScale = new Vector3(playerAmmoBackbar.sizeDelta.x * ((float)player.equipedWeapon.loadedAmmoCount / player.equipedWeapon.capacity) * 2, 1, 1);
            playerAmmoText.text = player.equipedWeapon.loadedAmmoCount + "/" + player.equipedWeapon.capacity;
        }

        else
        {
            playerAmmoFrontbar.localScale = new Vector3(0, 1, 1);
            playerAmmoText.text = "0" + "/" + player.equipedWeapon.capacity;
        }

        Debug.Log(player.equipedWeapon.loadedAmmoCount);
    }



    public void Dead()
    {
        UpdateAmmo();
        UpdateHealth();
        DeathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
    }

    public void ToggleReticle()
    {
        if (reticle.activeInHierarchy)
            reticle.SetActive(false);
        else
            reticle.SetActive(true);
    }

    public void Victory()
    {
        UpdateAmmo();
        UpdateHealth();
        WinScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
    }

    /*
       else
        {
            PlayerIsDead = true;
            playerAmmo.transform.localScale = new Vector3(0, 1, 1);
            playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / 2, 0, 0);
            playerHealth.transform.localScale = new Vector3(0, 1, 1);
            playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
            DeathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            reticle.SetActive(false);
        }

        if(Victory)
        {
            PlayerIsDead = false;
            playerAmmo.transform.localScale = new Vector3(0, 1, 1);
            playerAmmo.transform.localPosition = new Vector3(0 + ((float)equipedWeapon.loadedAmmoCount - (float)equipedWeapon.baseCapacity) / 2, 0, 0);
            playerHealth.transform.localScale = new Vector3(0, 1, 1);
            playerHealth.transform.localPosition = new Vector3(0 + (health - maxHealth) / 2, 0, 0);
            WinScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            reticle.SetActive(false);
        }
     */
}
