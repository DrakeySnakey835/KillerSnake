using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    private int tokens;

    void Awake()
    {
        Instance = this;
        tokens
