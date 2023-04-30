using UnityEngine;

public class MasterData
{
    public static bool playerShouldAttack = false;
    public static bool monsterShouldAttack = false;
    public static bool shouldFollowRotation = false;
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;
    public static GameObject musicLooper = null;
    public static Vector3 PlayerResumePosition = new Vector3(0.0f,0.0f,0.0f);
    public static Quaternion PlayerResumeRotation = new Quaternion();
    public static string playerDirectionOfTravel = "?";
    public static bool comingFromFight = false;
    public static bool enableFights = true;
    public static bool cheatMode = false;



    public static void setupDungeon()
    {
        if(MasterData.isDungeonSetup == false)
        {
            MasterData.cs = new Dungeon(100);
            MasterData.cs.populateCSDepartment();

            MasterData.p = new Player("Mike");
            MasterData.cs.addPlayer(p);
            MasterData.isDungeonSetup = true;
        }
    }
 
}
