using System.Collections.Generic;

public class Team
{   
    public int id;
    public string name;
    private int capspace = 250;
    public int Capspace
    {
        get{return capspace;}
        set
        {
            if(capspace == value)
            {
                return;
            }
            capspace = value;
            PropertyChanged();
        }
    }

    List<Contract> currentContracts = new List<Contract>();

    public Team(int id, string name, int capspace)
    {
        this.id = id;
        this.name = name;
        this.capspace = capspace;
    }


    //Property changed events
    public List<IPropertyListener<Team>> propertyListeners = new List<IPropertyListener<Team>>();

    private void PropertyChanged()
    {
        foreach(IPropertyListener<Team> listener in propertyListeners)
        {
            listener.OnPropertyChanged(this);
        }
    }
}