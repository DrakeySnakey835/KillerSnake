using UnityEngine;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    public List<Mission> dailyMissions = new List<Mission>();
    public int dailyMissionLimit = 10;

    void Start()
    {
        GenerateDailyMissions();
    }

    void GenerateDailyMissions()
    {
        for (int i = 0; i < dailyMissionLimit; i++)
        {
            Mission mission = new Mission
            {
                title = "Mission " + (i + 1),
                description = "Collect " + (10 + i * 5) + " food items.",
                goal = 10 + i * 5,
                rewardTokens = (10 + i * 5) * 10,
                progress = 0,
                isCompleted = false
            };
            dailyMissions.Add(mission);
        }
    }

    public void UpdateMissionProgress(int foodCollected)
    {
        foreach (Mission mission in dailyMissions)
        {
            if (!mission.isCompleted)
            {
                mission.progress += foodCollected;
                mission.CheckCompletion();
            }
        }
    }
}
