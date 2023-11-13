
// UI를 그리는 class
//던전 기능 관련 클래스
public class Dungeon
{
    DrawUnicodeUI drawUI = new DrawUnicodeUI();
    Player Player;

    public Dungeon(Player player)
    {
        Player = player;
    }

    public void EasyMode()
    {
        ModeSettings("쉬움", 5, 1000);
    }

    public void NormalMode()
    {
        ModeSettings("노말", 11, 1500);
    }


    public void HardMode()
    {
        ModeSettings("어려움", 17, 2500);
    }

    //난이도 조절
    void ModeSettings(string difficulty, int recommendDef, int defaultGold)
    {
        int RecommendDef = recommendDef;
        int DefaultGold = defaultGold;
        //권장 방어력 미만
        if (Player.ResultDef < RecommendDef)
        {
            int ClearRate = new Random().Next(1, 11);
            // 권장 방어력 이상 > 성공
            if (ClearRate <= 4)
            {
                int decreaseHP = new Random().Next(20, 35);
                int bonusGold = new Random().Next(1, 3);
                Console.SetCursorPosition(5, 22);
                Console.Write("{0} 던전을 클리어 하였습니다.", difficulty);
                Console.SetCursorPosition(5, 23);
                Console.Write("[탐험 결과]");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + RecommendDef - Player.ResultDef));
                Player.HP = Player.HP - (decreaseHP + RecommendDef - Player.ResultDef);
                Console.SetCursorPosition(5, 25);
                Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
                Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();

            }
            // 권장 방어력 미만 > 실패
            else
            {
                Console.SetCursorPosition(5, 22);
                Console.Write("던전 공략에 실패했습니다.");
                Console.SetCursorPosition(5, 23);
                Console.Write("체력이 절반으로 감소합니다.");
                Console.SetCursorPosition(5, 24);
                Console.Write("체력 {0} -> {1}", Player.HP, Player.HP / 2);
                Player.HP /= 2;

                Console.SetCursorPosition(5, 27);
                Console.Write("아무 키나 눌러 돌아가기 [ ]");
                Console.SetCursorPosition(30, 27);
                ConsoleKeyInfo inputKey = Console.ReadKey();
                Thread.Sleep(500);
                drawUI.ClearChatUI();
            }
        }
        //권장 방어력 이상
        else if (Player.ResultDef >= recommendDef)
        {
            int decreaseHP = new Random().Next(20, 35);
            int bonusGold = new Random().Next(1, 3);
            Console.SetCursorPosition(5, 22);
            Console.Write("{0} 던전을 클리어 하였습니다.", difficulty);
            Console.SetCursorPosition(5, 23);
            Console.Write("[탐험 결과]");
            Console.SetCursorPosition(5, 24);
            Console.Write("체력\t {0} -> {1}", Player.HP, Player.HP - (decreaseHP + recommendDef - Player.ResultDef));
            Player.HP = Player.HP - (decreaseHP + recommendDef - Player.ResultDef);
            Console.SetCursorPosition(5, 25);
            Console.Write("Gold\t {0} -> {1}", Player.Gold, Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100));
            Player.Gold = Player.Gold + DefaultGold + (DefaultGold * Player.Atk * bonusGold / 100);

            Console.SetCursorPosition(5, 27);
            Console.Write("아무 키나 눌러 돌아가기 [ ]");
            Console.SetCursorPosition(30, 27);
            ConsoleKeyInfo inputKey = Console.ReadKey();
            Thread.Sleep(500);
            drawUI.ClearChatUI();
        }
    }
}

