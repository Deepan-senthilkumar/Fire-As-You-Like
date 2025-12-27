using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject ammoCount;
    public GameObject minimap;

    private void Start()
    {
        InitializeHUD();
    }

    private void InitializeHUD()
    {
        // Initialize HUD elements here
        healthBar.SetActive(true);
        ammoCount.SetActive(true);
        minimap.SetActive(true);
    }

    public void UpdateHealth(float healthPercentage)
    {
        // Update health bar based on health percentage
        healthBar.transform.localScale = new Vector3(healthPercentage, 1, 1);
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        // Update ammo count display
        ammoCount.GetComponent<UnityEngine.UI.Text>().text = $"{currentAmmo} / {maxAmmo}";
    }

    public void ToggleMinimap(bool isVisible)
    {
        // Show or hide the minimap
        minimap.SetActive(isVisible);
    }
}