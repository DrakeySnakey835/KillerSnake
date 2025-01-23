using System;

[Serializable]
public class Mission
{
    public string title;
    public string description;
    public int goal;
    public int progress;
    public bool isCompleted;
    public int rewardTokens;

    public void CheckCompletion()
    {
        if (progress >= goal && !isCompleted)
        {
            isCompleted = true;
            RewardPlayer();
        }
    }

    void RewardPlayer()
    {
        CurrencyManager.Instance.AddTokens(rewardTokens);
    }
}
