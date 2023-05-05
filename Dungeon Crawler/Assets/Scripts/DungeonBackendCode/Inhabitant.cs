using System;

public class Inhabitant
{
    protected int maxHP;
    protected int hp;
    protected int ac;
    protected int damage;
    protected string name;
    private Random r = new Random();


    public Inhabitant(string name)
    {
        this.name = name;
        this.hp = r.Next(10, 21);
        this.maxHP = this.hp; //Never adjust, just tells us the max # of hit points we can get
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
    public void healHP(int amount)
    {
        this.hp += amount;
        if(this.hp > this.maxHP) //can only heal up to max # of hit points
        {
            this.hp = this.maxHP;
        } 
    }
    public int getHP()
    {
        return this.hp;
    }
    public int getMaxHP()
    {
        return this.maxHP;
    }
}
