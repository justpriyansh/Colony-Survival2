using NUnit.Framework;

public class SimulationTests
{
    private Simulation simulation;
    private ColonyState state;
    private ConsumptionConfig config;

    [SetUp]
    public void Setup()
    {
        state = new ColonyState
        {
            Population = 10,
            Food = 100,
            Water = 100,
            CurrentDay = 0
        };

        config = new ConsumptionConfig
        {
            foodPerVillagerPerDay = 1,
            waterPerVillagerPerDay = 2
        };

        simulation = new Simulation(state, config);
    }

    [Test]
    public void NextDay_IncreasesCurrentDay()
    {
        simulation.NextDay();

        Assert.AreEqual(1, state.CurrentDay);
    }

    [Test]
    public void NextDay_DecreasesFoodCorrectly()
    {
        simulation.NextDay();

        Assert.AreEqual(90, state.Food);
    }

    [Test]
    public void NextDay_DecreasesWaterCorrectly()
    {
        simulation.NextDay();

        Assert.AreEqual(80, state.Water);
    }

    [Test]
    public void FoodDaysRemaining_IsCorrect()
    {
        float days = simulation.GetFoodDaysRemaining();

        Assert.AreEqual(10f, days);
    }

    [Test]
    public void WaterDaysRemaining_IsCorrect()
    {
        float days = simulation.GetWaterDaysRemaining();

        Assert.AreEqual(5f, days);
    }

    [Test]
    public void Colony_IsNotStarvingInitially()
    {
        Assert.IsFalse(simulation.IsColonyStarving());
    }

    [Test]
    public void Colony_BecomesStarving_WhenFoodReachesZero()
    {
        state.Food = 0;

        Assert.IsTrue(simulation.IsColonyStarving());
    }

    [Test]
    public void Colony_BecomesStarving_WhenWaterReachesZero()
    {
        state.Water = 0;

        Assert.IsTrue(simulation.IsColonyStarving());
    }
}