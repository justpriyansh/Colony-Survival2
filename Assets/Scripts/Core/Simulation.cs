public class Simulation
{
    private readonly ColonyState colonyState;
    private readonly ConsumptionConfig consumptionConfig;

    public Simulation(ColonyState colonyState, ConsumptionConfig consumptionConfig)
    {
        this.colonyState = colonyState;
        this.consumptionConfig = consumptionConfig;
    }

    public void NextDay()
    {
        colonyState.CurrentDay++;

        float dailyFoodConsumption = colonyState.Population * consumptionConfig.foodPerVillagerPerDay;

        float dailyWaterConsumption = colonyState.Population * consumptionConfig.waterPerVillagerPerDay;

        colonyState.Food -= dailyFoodConsumption;
        colonyState.Water -= dailyWaterConsumption;

        if (colonyState.Food < 0)
            colonyState.Food = 0;

        if (colonyState.Water < 0)
            colonyState.Water = 0;
    }

    public float GetDailyFoodConsumption()
    {
        return colonyState.Population * consumptionConfig.foodPerVillagerPerDay;
    }

    public float GetDailyWaterConsumption()
    {
        return colonyState.Population * consumptionConfig.waterPerVillagerPerDay;
    }

    public float GetFoodDaysRemaining()
    {
        float daily = GetDailyFoodConsumption();

        if (daily <= 0)
            return float.PositiveInfinity;

        return colonyState.Food / daily;
    }

    public float GetWaterDaysRemaining()
    {
        float daily = GetDailyWaterConsumption();

        if (daily <= 0)
            return float.PositiveInfinity;

        return colonyState.Water / daily;
    }

    public bool IsColonyStarving()
    {
        return colonyState.Food <= 0 || colonyState.Water <= 0;
    }

    public ColonyState GetState()
    {
        return colonyState;
    }
}