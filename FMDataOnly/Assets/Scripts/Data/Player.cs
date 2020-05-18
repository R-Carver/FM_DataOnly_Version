
public class Player
{   
    public int id;
    public string name;
    public Position position;
    //the contract cost in Millions
    public int cost;

    public Player(int id, string name, int position, int cost)
    {
        this.id = id;
        this.name = name;
        this.position = (Position)position;
        this.cost = cost;
    }

    Contract currentContract;

}

public enum Position
{
    QB,
    WR,
    G,
    OT,
    T,
    DT,
    DE,
    LB,
    CB,
    S,
    K
}