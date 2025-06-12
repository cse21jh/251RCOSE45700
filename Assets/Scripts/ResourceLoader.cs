using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ResourceLoader
{
    private static readonly Dictionary<string, Sprite> spriteCache = new();

    /// <summary>
    /// Resources/UpgradeIcons.png �ȿ� �߶���� Sprite�� �̸����� �ε�
    /// </summary>
    public static Sprite LoadUpgradeIcon(string name)
    {
        // ���� �� ���� LoadAll
        if (spriteCache.Count == 0)
        {
            var sprites = Resources.LoadAll<Sprite>("UpgradeIcons");
            foreach (var sprite in sprites)
            {
                spriteCache[sprite.name] = sprite;
            }
        }

        // ������ null
        if (spriteCache.TryGetValue(name, out var result))
            return result;

        Debug.LogWarning($"[ResourceLoader] ��������Ʈ '{name}'�� ã�� �� �����ϴ�.");
        return null;
    }
}
