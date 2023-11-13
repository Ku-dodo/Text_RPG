
// UI를 그리는 class
public class Player
{
    //Player 변수
    public string Name;
    public string Job;
    public int HP;
    public int Atk;
    public int Def;
    public int Gold;
    public List<Item> itemlist = new List<Item>();
    Item armor = new Item("무쇠 갑옷", 0, 5, false);
    Item sword = new Item("낡은 검", 2, 0, false);

    //Player 장비 수치
    public int equipAtk;
    public int equipDef;

    //Player 능력치 + 장비 수치
    public int ResultAtk;
    public int ResultDef;

    //Player 생성자
    public Player(string name, string job, int hp, int atk, int def, int gold)
    {
        Name = name;
        Job = job;
        HP = hp;
        Atk = atk;
        Def = def;
        Gold = gold;

        itemlist.Add(armor);
        itemlist.Add(sword);
    }

    //스탯 + 장비 스탯을 새로고침 하는 메서드
    public void EquipmentStat()
    {
        equipAtk = 0;
        equipDef = 0;
        foreach (Item item in itemlist)
        {
            if (item.equipState)
            {
                equipAtk += item.Atk;
                equipDef += item.Def;
            }
        }
        ResultAtk = Atk + equipAtk;
        ResultDef = Def + equipDef;
    }

}

//item 구조체
public struct Item
{
    //item 변수
    public string Name;
    public int Atk;
    public int Def;
    public bool equipState;

    //item 생성자
    public Item(string _Name, int _Atk, int _Def, bool _equipState)
    {
        Name = _Name;
        Atk = _Atk;
        Def = _Def;
        equipState = _equipState;
    }
}