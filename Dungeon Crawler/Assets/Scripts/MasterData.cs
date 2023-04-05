public class MasterData //NOT Monobehavior - doesn't need start() or update() things! //Non-mono behaviors inherit from Object - not something Unity knows about
{
    public static int count = 0; //Call with class NAME, so MasterData
    public static string whereDidIComeFrom = "north";
    public static bool isMoving = true;
    public static bool setupDone = false;
}
//IS a singleton
