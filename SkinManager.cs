using UnityEngine;
using System.Collections.Generic;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;

    public List<Sprite> headSkins;
    public List<Sprite> bodySkins;

    void Awake()
    {
        Instance = this;
    }

    public void ApplySkin(int skinIndex)
    {
        // Implementation to apply skins to the snake.
    }
}
