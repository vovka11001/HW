class Program
{
    static void Main()
    {
        Platoon platoon = new Platoon();
        platoon.Work();
    }
}

class Platoon
{
    private List<Soldier> _soldiers1 = new List<Soldier>();
    private List<Soldier> _soldiers2 = new List<Soldier>();

    public Platoon()
    {
        _soldiers1.Add(new Soldier("Вова"));
        _soldiers1.Add(new Soldier("Борис"));
        _soldiers1.Add(new Soldier("Дима"));
        _soldiers2.Add(new Soldier("Олег"));
        _soldiers2.Add(new Soldier("Ваня"));
        _soldiers2.Add(new Soldier("Арсентий"));
    }

    public void Work()
    {
        char firstLetter = 'Б';
        var soldiersToTransfer = _soldiers1.Where(soldier => soldier.Name.StartsWith(firstLetter)).ToList();
    
        Console.WriteLine("Список бойцов первого отряда до перевода");
        ShowSoldiers(_soldiers1);
    
        Console.WriteLine("Список бойцов второго отряда до перевода");
        ShowSoldiers(_soldiers2);
    
        _soldiers1 = _soldiers1.Except(soldiersToTransfer).ToList();
        _soldiers2 = _soldiers2.Union(soldiersToTransfer).ToList();
    
        Console.WriteLine("Список бойцов первого отряда после перевода");
        ShowSoldiers(_soldiers1);
    
        Console.WriteLine("Список бойцов второго отряда после перевода");
        ShowSoldiers(_soldiers2);
    }
    
    private void ShowSoldiers(List<Soldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.Name);
        }
    }
}

class Soldier
{
    public Soldier(string name)
    {
        Name = name;
    }
    public string Name { get; }
}