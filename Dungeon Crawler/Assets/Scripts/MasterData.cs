public class MasterData //NOT Monobehavior - doesn't need start() or update() things! //Non-mono behaviors inherit from Object - not something Unity knows about
{
    public static int count = 0; //Call with class NAME, so MasterData
}
//IS a singleton
