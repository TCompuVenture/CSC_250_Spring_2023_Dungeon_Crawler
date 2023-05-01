using System;

public class Inhabitant
{
    protected int hp;
    protected int ac;
    protected int damage;
    protected string name;
    private Random r = new Random();


    public Inhabitant(string name)
    {
        this.name = name;
        this.hp = r.Next(10, 21);
        this.ac = r.Next(10, 18);//CHANGE THIS!!!!!
        this.damage = r.Next(1, 6);  //CHANGE THIS!!!!!
    }

    public string getData()
    {
        string s = this.name;
        s = s + " - " + this.hp + " / " + this.ac + " / " + this.damage;
        return s;
    }

    public bool isDead()
    {
        return this.hp <= 0;
    }

    public int getAC()
    {
        return this.ac;
    }
    public void resetHP()
    {
        this.hp = this.r.Next(10,21);
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }
}
