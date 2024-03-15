using System.IO;
using System.Reflection;
using BepInEx;
using LethalLib.Modules;
using UnityEngine;
namespace Template;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION), BepInDependency(LethalLib.Plugin.ModGUID)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        var assets = AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream($"{PluginInfo.PLUGIN_GUID}.assets"));

        Item donut = assets.LoadAsset<Item>("Assets/Prefabs/Donut - Lilu/DonutLilu.asset");
        Utilities.FixMixerGroups(donut.spawnPrefab);
        NetworkPrefabs.RegisterNetworkPrefab(donut.spawnPrefab);
        Items.RegisterScrap(donut, 1000, Levels.LevelTypes.All);

        Logger.LogInfo("Donuts loaded!");
    }
}
