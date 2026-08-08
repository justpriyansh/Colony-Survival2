using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text foodDaysText;
    [SerializeField] private TMP_Text waterDaysText;
    [SerializeField] private TMP_Text starvingText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        starvingText.gameObject.SetActive(false);
    }

    public void UpdateUI(
        ColonyState state,
        float foodDays,
        float waterDays,
        bool starving)
    {
        dayText.text = $"Day : {state.CurrentDay}";
        foodText.text = $"Food : {state.Food:F0}";
        waterText.text = $"Water : {state.Water:F0}";
        foodDaysText.text = $"Food Days Remaining : {foodDays:F0}";
        waterDaysText.text = $"Water Days Remaining : {waterDays:F0}";

        starvingText.gameObject.SetActive(starving);
    }

    public void ShowGameOver()
    {
        starvingText.gameObject.SetActive(true);
        starvingText.text = "COLONY STARVING";
    }
}