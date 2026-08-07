using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Simulation simulation;
    private ColonyState colonyState;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        InitializeGame();

        UIManager.Instance.UpdateUI(colonyState, simulation.GetFoodDaysRemaining(), simulation.GetWaterDaysRemaining(), simulation.IsColonyStarving());
        StartCoroutine(GameLoop());
    }

    private void InitializeGame()
    {
        PopulationConfig populationConfig = JsonLoader.Load<PopulationConfig>("population");

        ConsumptionConfig consumptionConfig = JsonLoader.Load<ConsumptionConfig>("consumption");

        colonyState = new ColonyState
        {
            Population = populationConfig.villagers,
            Food = populationConfig.startingFood,
            Water = populationConfig.startingWater,
            CurrentDay = 0
        };

        simulation = new Simulation(colonyState, consumptionConfig);
    }

    private IEnumerator GameLoop()
    {
        while (!simulation.IsColonyStarving())
        {
            yield return new WaitForSeconds(1f);

            simulation.NextDay();

            UIManager.Instance.UpdateUI( colonyState, simulation.GetFoodDaysRemaining(), simulation.GetWaterDaysRemaining(), simulation.IsColonyStarving());
        }

        UIManager.Instance.ShowGameOver();
    }

    public ColonyState GetState()
    {
        return colonyState;
    }
}