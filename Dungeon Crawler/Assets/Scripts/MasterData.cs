public class MasterData //NOT Monobehavior - doesn't need start() or update() things! //Non-mono behaviors inherit from Object - not something Unity knows about
{
    public static int count = 0; //Call with class NAME, so MasterData
    public static string whereDidIComeFrom = "?";
    public static bool isMoving = true;
    public static bool isExiting = false;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;
    public static bool northOn;
    public static bool southOn;
    public static bool eastOn;
    public static bool westOn;
   // public static Vector3 centerShift; //Idea here would be to shift center when Player has chosen a direction such that 
   //When the Player rolls into the next room, the Player hits the edge of the centerController only when over dead center.

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
//IS a singleton
