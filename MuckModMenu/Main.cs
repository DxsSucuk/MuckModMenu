using Steamworks;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityModManagerNet;

namespace MuckModMenu
{
    public class Main
    {

        static string health = "100";
        static string ammo = "100";
        static Boolean autorespawn = false;
        static Boolean god = false;
        static int ownid = 0;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.Logger.Log("Ayo the Menu goes BRRRRRRRR");
            modEntry.OnGUI = OnGUI;
            modEntry.OnUpdate = OnUpdate;
            ownid = LocalClient.instance.myId;
            return true;
        }

        static void OnUpdate(UnityModManager.ModEntry modEntry, float df)
        {

            if (autorespawn)
            {
                if (Server.clients.Count >= 1) {
                    foreach (Client cl in Server.clients.Values)
                    {
                        if (cl != null && cl.player != null)
                        {
                            if (cl.player.dead)
                            {
                                cl.player.dead = false;
                                GameManager.players[cl.id].dead = false;
                                GameManager.instance.RespawnPlayer(cl.id, Vector3.zero);

                                ServerSend.SendChatMessage(-1, "", string.Concat(new string[] {
                                "<color=orange>",
                                Server.clients[ownid].player.username,
                                " has revived ",
                                cl.player.username,
                                " with a blowjob!"
                            }));

                                ServerSend.RevivePlayer(ownid, cl.id, true, -1);
                            }
                        }
                    }
                } else
                {
                    modEntry.Logger.Log("Not the Host turning it off!");
                    autorespawn = false;
                }
            }

            if (god)
            {
                try
                {
                    PlayerStatus.Instance.maxHp = 99999;
                    PlayerStatus.Instance.hp = 99999;
                    PlayerStatus.Instance.hunger = 999999f;
                    PlayerStatus.Instance.shield = 99999f;
                    PlayerStatus.Instance.stamina = 999999;
                    //ClientSend.PlayerHp(99999, 99999);
                }
                catch (Exception ex)
                {

                }
            }
        }

        static void OnGUI(UnityModManager.ModEntry modEntry)
        {

            GUILayout.Label("Lobby Informations");

            try
            {
               GUILayout.Label("Host: " + GameManager.players[0].username
               +"\nPVP: " + GameManager.gameSettings.friendlyFire.ToString()
               +"\nGameMode: " + GameManager.gameSettings.gameMode.ToString()
               +"\nDifficulty: " + GameManager.gameSettings.difficulty.ToString()
               +"\nSeed: " + GameManager.gameSettings.Seed);
            } catch(Exception ex)
            {
                GUILayout.Label("Not in a Lobby!");
            }

            GUILayout.Label("\n\n");
            GUILayout.Label("Player Informations");
            string end = "";

            if (Server.clients != null && MainController.isHost)
            {
                foreach (Client cl in Server.clients.Values)
                {
                    if (cl != null && cl.player != null && cl.player.username != null)
                    {
                        try
                        {
                            end += "Name: " + cl.player.username + "\nPlayerID: " + cl.id + "\nIP: " + ((cl.tcp != null && cl.tcp.socket != null && cl.tcp.socket.Client != null && cl.tcp.socket.Client.RemoteEndPoint != null) ? cl.tcp.socket.Client.RemoteEndPoint.AddressFamily.ToString() : "0.0.0.0") + "\n\n";
                        } catch(Exception ex)
                        {
                            modEntry.Logger.Log("Error while adding Data for Player " + cl.id + "\nError: " + ex.Message);
                        }
                    }
                }
            } else if(!MainController.isHost)
            {
                foreach (PlayerManager pm in GameManager.players.Values)
                {
                    if (pm != null && pm.onlinePlayer != null && pm.username!= null)
                    {
                        try
                        {
                            end += "Name: " + pm.username + "\nPlayerID: " + pm.id + "\nIP: 0.0.0.0\n\n";
                        }
                        catch (Exception ex)
                        {
                            modEntry.Logger.Log("Error while adding Data for Player " + pm.id + "\nError: " + ex.Message);
                        }
                    }
                }
            }

            GUILayout.Label(end);

            GUILayout.Label("Utils");

            autorespawn = GUILayout.Toggle(autorespawn, "AutoRespawn");
            god = GUILayout.Toggle(god, "God");

            if (GUILayout.Button("Unlock All Achievements (Part 1)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if(achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 1, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 2)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 2, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 3)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 3, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 4)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 4, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 5)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 5, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 6)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 6, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 7)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 7, achievementManager);
                }

            }

            if (GUILayout.Button("Unlock All Achievements (Part 8)"))
            {
                AchievementManager achievementManager = AchievementManager.Instance;

                if (achievementManager.CanUseAchievements())
                {
                    addAllAchievments(modEntry, 8, achievementManager);
                }

            }




            /*if(GUILayout.Button("Kill Boss"))
            {
                if (BossUI.Instance.currentBoss != null) {
                    BossUI.Instance.currentBoss.GetComponent<HitableMob>().hp = 1;
                } else
                {
                    modEntry.Logger.Log("Please first spawn a Boss!");
                }
            }*/


            GUILayout.Label("\n\n\n");
            GUILayout.Label("PowerUPS");

            foreach (Powerup pw in ItemManager.Instance.allPowerups.Values)
            {

                if (GUILayout.Button(pw.name)) {
                    try
                    {
                        PowerupInventory.Instance.AddPowerup(pw.name, pw.id, ItemManager.Instance.GetNextId());
                    }
                    catch (Exception ex)
                    {
                        modEntry.Logger.Log("Error: " + ex.Message);
                    }
                }
            }

            if (GUILayout.Button("Give All"))
            {
                foreach (Powerup pw in ItemManager.Instance.allPowerups.Values)
                {
                    try
                    {
                        PowerupInventory.Instance.AddPowerup(pw.name, pw.id, ItemManager.Instance.GetNextId());
                    }
                    catch (Exception ex)
                    {
                        modEntry.Logger.Log("Error: " + ex.Message);
                    }
                }
            }

            if (GUILayout.Button("Give All 100x (Laggy)"))
            {
                for (int i = 0; i < 100; i++)
                {
                    foreach (Powerup pw in ItemManager.Instance.allPowerups.Values)
                    {
                        try
                        {
                            PowerupInventory.Instance.AddPowerup(pw.name, pw.id, ItemManager.Instance.GetNextId());
                        }
                        catch (Exception ex)
                        {
                            modEntry.Logger.Log("Error: " + ex.Message);
                        }
                    }
                }
            }

            if (GUILayout.Button("Give All 500x (Laggy)"))
            {
                for (int i = 0; i < 500; i++)
                {
                    foreach (Powerup pw in ItemManager.Instance.allPowerups.Values)
                    {
                        try
                        {
                            PowerupInventory.Instance.AddPowerup(pw.name, pw.id, ItemManager.Instance.GetNextId());
                        }
                        catch (Exception ex)
                        {
                            modEntry.Logger.Log("Error: " + ex.Message);
                        }
                    }
                }
            }

            GUILayout.Label("\n\n\n");

            GUILayout.Label("Items");

            foreach (InventoryItem item in ItemManager.Instance.allItems.Values)
            {

                if (GUILayout.Button(item.name))
                {
                    try
                    {
                       InventoryUI.Instance.DropItemIntoWorld(item);
                    }
                    catch (Exception ex)
                    {
                        modEntry.Logger.Log("Error: " + ex.Message);
                    }
                }
            }

            if (GUILayout.Button("Give Full Set"))
            {
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Adamantite Pants"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Adamantite Helmet"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Adamantite Chestplate"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Adamantite Boots"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Gronks Sword"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Night Blade"));
            }

            if (GUILayout.Button("Give Full Set Boat"))
            {
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Wood"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Wood"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Oak Wood"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Dark Oak Wood"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Fir Wood"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rock"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Wheat"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Rope"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Flax Fibers"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Raw Meat"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Adamantite Bar"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Obamium Bar"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Gold Bar"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Iron Bar"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("AncientCore"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Blue Gem"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Green Gem"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Pink Gem"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Red Gem"));
                InventoryUI.Instance.DropItemIntoWorld(ItemManager.Instance.GetItemByName("Yellow Gem"));
            }

            /*GUILayout.Label("God mode");
            health = GUILayout.TextField(health, GUILayout.Width(100f));
            ammo = GUILayout.TextField(ammo, GUILayout.Width(100f));

            if (GUILayout.Button("Apply") && int.TryParse(health, out var h) && int.TryParse(ammo, out var a))
            {
                if (MainController.isHost)
                {
                    foreach (PlayerManager pm in GameManager.players.Values)
                    {
                        modEntry.Logger.Log("User: " + pm.onlinePlayer.name);
                        pm.hitable.maxHp = h;
                        pm.hitable.hp = h;
                    }
                }
                else
                {
                    modEntry.Logger.Log("Host: " + MainController.isHost);
                }
                 foreach (Client client in Server.clients.Values)
                 {
                     if (((client != null) ? client.player : null) != null)
                     {
                         client.player.currentHp = 9999;
                         foreach (Powerup pw in ItemManager.Instance.allPowerups.Values)
                         {
                             try
                             {
                                 PowerupInventory.Instance.AddPowerup(pw.name, pw.id, ItemManager.Instance.GetNextId());
                             } catch(Exception ex)
                             {
                                 modEntry.Logger.Log("Error: " + ex.Message);
                             }
                         }

                         modEntry.Logger.Log("User 2: " + client.player.username);
                     }
                 }
            }*/
        }

        public static void addAllAchievments(UnityModManager.ModEntry modEntry, int part, AchievementManager achievementManager) {


            modEntry.Logger.Log("Starting Adding Achievments Part " + part + "!");

            switch(part)
            {
                case 1:
                    {
                        SteamUserStats.AddStat("WinsEasy", 1);
                        SteamUserStats.AddStat("WinsNormal", 1);
                        SteamUserStats.AddStat("WinsGamer", 1);
                        SteamUserStats.AddStat("GamerMove", 1);
                        SteamUserStats.AddStat("Speedrunner", 1);
                        SteamUserStats.AddStat("NoPowerups", 1);
                        SteamUserStats.AddStat("Untouchable", 1);
                        break;
                    }
                case 2:
                    {
                        SteamUserStats.AddStat("The bois", 1);
                        SteamUserStats.AddStat("Dream Team", 1);
                        SteamUserStats.AddStat("Caveman", 1);
                        SteamUserStats.AddStat("Sweat and tears", 1);
                        SteamUserStats.AddStat("Muck", 1);
                        SteamUserStats.AddStat("GamesWon", 5);
                        SteamUserStats.AddStat("Set sail", 1);
                        break;
                    }
                case 3:
                    {

                        Thread thread = new Thread(new ThreadStart(addKills));
                        thread.Start();

                        SteamUserStats.AddStat("ChiefKills", 1);
                        SteamUserStats.AddStat("BigChunkKills", 1);
                        SteamUserStats.AddStat("GronkKills", 1);
                        SteamUserStats.AddStat("GuardianKills", 1);
                        SteamUserStats.AddStat("WoodmanKills", 100);
                        break;
                    }
                case 4:
                    {

                        SteamUserStats.AddStat("Fearless", 1);
                        for(int i = 0; i < 200; i++)
                        {
                            achievementManager.StartBattleTotem();
                        }
                        SteamUserStats.AddStat("Revives", 1);
                        for(int i = 0; i < 100; i++)
                        {
                            achievementManager.AddDeath(PlayerStatus.DamageType.Drown);
                        }
                        break;

                    }
                case 5:
                    {
                        for(int i = 0; i < 500; i++)
                        {
                            achievementManager.OpenChest();
                        }
                        achievementManager.ItemCrafted(ItemManager.Instance.GetItemByName("Coin"), 1000);
                        for (int i = 0; i < 250; i++)
                        {
                            achievementManager.BuildItem(1);
                        }
                        SteamUserStats.SetStat("Longest survived", 999999);
                        SteamUserStats.AddStat("The Black Swordsman", 1);
                        SteamUserStats.AddStat("Milkman", 10);
                        for(int i = 0; i < 50; i++) {
                            achievementManager.EatFood(ItemManager.Instance.GetItemByName("Gulpon Shroom"));
                        }
                        break;
                    }
                case 6:
                    {
                        achievementManager.AddPlayerKill();
                        for(int i = 0; i < 10000; i++)
                        {
                            achievementManager.Jump();
                        }
                        SteamUserStats.AddStat("AllGems", 1);
                        for(int i = 0; i < 250; i++)
                        {
                            achievementManager.BuildItem(0);
                        }
                        SteamUserStats.AddStat("Karlson monitor", 1);
                        break;
                    }
                case 7:
                    {
                        achievementManager.MoveDistance(250000, 25000);
                        achievementManager.OpenChiefChest();
                        SteamUserStats.AddStat("AllGems", 1);
                        break;
                    }
                case 8:
                    {
                        SteamUserStats.AddStat("Muck started", 1);
                        SteamUserStats.AddStat("GamesStarted", 1);
                        SteamUserStats.AddStat("Easy", 1);
                        SteamUserStats.AddStat("Normal", 1);
                        SteamUserStats.AddStat("Gamer", 1);
                        break;
                    }
                default:
                    {
                        SteamUserStats.StoreStats();
                        break;
                    }
            }

            modEntry.Logger.Log("Storing!");

            SteamUserStats.StoreStats();
        }

        public static void addKills()
        {
            Mob mob = new Mob();
            MobType type = new MobType();
            Mob mob2 = new Mob();
            MobType type2 = new MobType();

            type.name = "Cow";
            mob.countedKill = false;
            mob.mobType = type;

            type2.name = "Goblin";
            mob2.mobType = type2;
            mob2.multiplier = 2f;

            for (int i = 0; i < 100000; i++)
            {
                AchievementManager.Instance.AddKill(PlayerStatus.WeaponHitType.Ranged, mob);
                AchievementManager.Instance.AddKill(PlayerStatus.WeaponHitType.Ranged, mob2);
            }
        }

    }
}
