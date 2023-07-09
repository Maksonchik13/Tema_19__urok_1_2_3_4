Console.WriteLine("КАМЕНЬ, НОЖНИЦЫ, БУМАГА");
Console.WriteLine();
Console.WriteLine("Побеждает игрок, набравший нужное количество очков, \n" +
    "и при этом, он должен опережать соперника минимум на 3 очка");
Console.WriteLine();
Console.WriteLine("Нажмите ENTER, чтобы начать");
Console.ReadLine();
Random random = new Random();
int[] levelOpen = { 1, 0, 0, 0, 0 };
string[] mainWords = { "камень", "ножницы", "бумагу" };
string[] drawText = { 
    "!!!   Похоже, у нас ничья   !!!",
    "!!!   Какое напряженное сражение!   !!!",
    $"!!!  Я думаю, нужно ставить {mainWords[random.Next(mainWords.Length)]}   !!!"};
string [] winText = {
    "!!!  Удача на вашей стороне!  !!!",
    "!!!  Вы выиграли раунд!  !!!",
    "!!!  Победа почти у вас в кармане!  !!!",
    "!!!  Похоже, кое-кто владеет даром предвидения)   !!!",
    "!!!  Вперед чемпион!  !!!",
    "!!!  Я знал, что вы победите  !!!",
    "!!!  Невероятное везение!  !!!",
                "!!!   Главное не участие, а победа!   !!!"};
string[] loseText = {
    "!!!  Не расстраивайся! Тебе еще повезет!  !!!",
    "!!!  Нужно срочно отыграться  !!!",
    "!!!  Вперёд! Вперёд! Покажи этой железяке!  !!!",
    "!!!  Главное не победа а участие!   !!!",
    "!!!  Нет, ну он точно жульничал  !!!",
    "!!!  Признайся, ты просто дал противнику фору  !!!",
    $"!!!  Я думаю, нужно ставить {mainWords[random.Next(mainWords.Length)]}   !!!"};
bool playGame = true;
bool win = false;
bool lose = false;
bool error = false;
while (playGame)
{
    Console.Clear();
    if (error == true)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!!Такого уровня не существует!!!\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        error = false;
    }
    for (int i = 0; i <5; i++)
    {
        if (levelOpen.Contains(i+1))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"*****\n* {i+1} *\n*****");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"*****\n* {i + 1} *\n*****");
        }
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Введите номер уровня, или нажмите ENTER , чтобы выйти");
    string choice = Console.ReadLine()!;
    switch (choice)
    {
        case "1":
            {
                Instruction(1);
                Game(ref win, ref lose,1);
                WinLoseMessage(win, lose, 1);
            }
            break;
        case "2":
            {
                Instruction(2);
                ContainCheck(2);
                WinLoseMessage(win, lose, 2);
            }
            break;
        case "3":
            {
                Instruction(3);
                ContainCheck(3);
                WinLoseMessage(win, lose, 3);
            }
            break;
        case "4":
            {
                Instruction(4);
                ContainCheck(4);
                WinLoseMessage(win, lose, 4);
            }
            break;
        case "5":
            {
                Instruction(5);
                ContainCheck(5);
                WinLoseMessage(win, lose, 5);
            }
            break;
        case "":
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.DarkCyan;
                Console.WriteLine(
                    "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n" +
                    "         ПРИХОДИТЕ ЕЩЕ\n" +
                    "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.ForegroundColor = ConsoleColor.White;
                playGame = false;
            }
            break;
        default:
            {
                error = true;
            }
            break;
    }

}


void Game(ref bool win,ref bool lose,int limit)
{
    Console.Clear();
    win = false;
    lose = false;
    int playerScore = 0;
    int computerScore = 0;
    string playerTurn = "";
    while (Math.Abs(playerScore - computerScore) <=2 || playerScore<limit && computerScore<limit)
    {
        int botTurn = random.Next(1, 4);
        Console.Clear();
        Console.WriteLine($"СЧЁТ:   ВЫ - {playerScore}          КОМПЬЮТЕР - {computerScore}") ;
        Console.WriteLine("Ваш ход");
        do
        {
            Console.WriteLine("[1] - камень\n[2] - ножницы\n[3] - бумага\n[ENTER] - выйти в главное меню");
            playerTurn = Console.ReadLine()!;
            if (playerTurn != "1" && playerTurn != "2" && playerTurn != "3" && playerTurn != "")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!  Введите число от 1 до 3 или ENTER  !!!");
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine($"СЧЁТ:   ВЫ - {playerScore}          КОМПЬЮТЕР - {computerScore}");
            }
        }
        while (playerTurn != "1" && playerTurn != "2" && playerTurn != "3" && playerTurn != "");
        if (playerTurn != "")
        {
            Console.Clear();
            int check = int.Parse(playerTurn);
            int bigger=0;
            int smaller=0;
            switch (check)
            {
                case 1: 
                    {
                        bigger = 3;
                        smaller = 2;
                    }; break;
                case 2:
                    {
                        bigger = 1;
                        smaller = 3;
                    }; break;
                case 3:
                    {
                        bigger = 2;
                        smaller = 1;
                    }; break;
            }
            if (botTurn != check && botTurn != bigger)
            {
                playerScore++;
                Console.WriteLine($"СЧЁТ:   ВЫ - {playerScore}          КОМПЬЮТЕР - {computerScore}");
                Console.ForegroundColor = ConsoleColor.Green;
                PlayerPicture(check);
                Console.ForegroundColor = ConsoleColor.Red;
                ComputerPicture(botTurn);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine($"{winText[random.Next(winText.Length)]}");
                Console.ForegroundColor=ConsoleColor.White;
                Console.WriteLine();
                Console.Write("  Нажмите ENTER для продолжения");
                Console.ReadLine();
            }
            else if (botTurn != check && botTurn != smaller)
            {
                computerScore++;
                Console.WriteLine($"СЧЁТ:   ВЫ - {playerScore}          КОМПЬЮТЕР - {computerScore}");
                Console.ForegroundColor = ConsoleColor.Red;
                PlayerPicture(check);
                Console.ForegroundColor = ConsoleColor.Green;
                ComputerPicture(botTurn);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"{loseText[random.Next(loseText.Length)]}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("  Нажмите ENTER для продолжения");
                Console.ReadLine();
            }
            else if (botTurn == check)
            {
                Console.WriteLine($"СЧЁТ:   ВЫ - {playerScore}          КОМПЬЮТЕР - {computerScore}");
                Console.ForegroundColor = ConsoleColor.Blue;
                PlayerPicture(check);
                ComputerPicture(botTurn);
                Console.WriteLine();
                Console.WriteLine($"{drawText[random.Next(drawText.Length)]}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("  Нажмите ENTER для продолжения");
                Console.ReadLine();
            }
        }
        else
        {
            string exit;
            do
            {
                Console.Clear();
                Console.WriteLine("ВЫ уверены? Если выйдете до конца игры, результаты не сохранятся");
                Console.WriteLine("[1] - ДА [2] - Нет");
                exit = Console.ReadLine()!;
            }
            while (exit != "1" && exit != "2");
            if (exit == "1")
            {
                playerScore = 0;
                computerScore = 0;
                break;
            }
        }
    }
    if (playerScore > computerScore)
    {
        win = true;
    }
    else if (computerScore > playerScore)
    {
        lose = true;
    }
}



void PlayerPicture(int playerTurn)
{
    switch (playerTurn)
    {
        case 1:
            Console.WriteLine(
            " __________________\r\n" +
            "|               ___]\r\n" +
            "|               ___]\r\n" +
            "|               ___]\r\n" +
            "|__________________]\r\n" +
            "            \\___|"); break;
        case 2:
            Console.WriteLine(
            "           __\r\n" +
            "          / / \r\n" +
            " ________/ /______________\r\n" +
            "|              ___________]\r\n" +
            "|             [___________\r\n" +
            "|             ____________]\r\n" +
            "|             ____]\r\n" +
            "|_________________]"); break;
        case 3:
            Console.WriteLine(
                "            __\r\n" +
                "           / /  \r\n" +
                " _________/ /___________\r\n" +
                "|               ________]\r\n" +
                "|               _________]\r\n" +
                "|               ________] \r\n" +
                "|_____________________]"); break;
    }

}


void ComputerPicture(int computerTurn)
{
    switch (computerTurn)
    {
        case 1:
            Console.WriteLine(
                "                                            _____________________\r\n" +
                "                                           [___                  |\r\n" +
                "                                           [___                  |\r\n" +
                "                                           [___                  |\r\n" +
                "                                           [_____________________|\r\n" +
                "                                              |___/"); break;
        case 2: Console.WriteLine(
            "                                                           __\r\n" +
            "                                                           \\ \\\r\n" +
            "                                            ________________\\ \\_________\r\n" +
            "                                           [____________               |\r\n" +
            "                                            ____________]              |\r\n" +
            "                                           [___________                |\r\n" +
            "                                                  [____                |\r\n" +
            "                                                  [____________________|"); break;
        case 3: Console.WriteLine(
            "                                                      __\r\n" +
            "                                                      \\ \\\r\n" +
            "                                           ____________\\ \\________\r\n" +
            "                                          [________               |\r\n" +
            "                                         [________                |\r\n" +
            "                                          [_______                |\r\n" +
            "                                            [_____________________| ");break;
    }
}

void ContainCheck(int levelNumber)
{
    if (levelOpen.Contains(levelNumber))
    {
        Game(ref win,ref lose,levelNumber);
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(
            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n" +
            "!!!!!!!!!Уровень Заблокирован!!!!!!!!!\n" +
            "!Сначала пройдите предыдущий уровень!!\n" +
            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.Write("Нажмите ENTER для продолжения");
        Console.ReadLine();
    }
}

void WinLoseMessage(bool win, bool lose,int levelNumber)
{
    if (win == true && levelNumber!=5)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ПОЗДРАВЛЯЮ, ВЫ ПОбЕДИЛИ!!!");
        Console.WriteLine("ТЕПЕРЬ ВАМ ДОСТУПЕН СЛЕДУЮЩИЙ УРОВЕНЬ!");
        Console.WriteLine("Нажмите ENTER для продолжения");
        Console.ReadLine();
        Console.ForegroundColor= ConsoleColor.White;
        levelOpen[levelNumber]=levelNumber+1;
    }
    else if (win == true && levelNumber == 5)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("УХ ТЫ!!! КАЖЕТСЯ, ВЫ ПРОШЛИ ВСЕ УРОВНИ!!\n        ПОЗДРАВЛЯЮ!!!!!");
        Console.WriteLine("Нажмите ENTER для продолжения");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if (win == false && lose == true)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("     К СОЖАЛЕНИЮ, ВЫ ПРОИГРАЛИ\nНЕ РАССТРАИВАЙТЕСЬ, ПОПРОБУЙТЕ ЕЩЕ РАЗ!");
        Console.WriteLine("Нажмите ENTER для продолжения");
        Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
    }
}

void Instruction(int count)
{
    Console.Clear();
    Console.WriteLine($"Добро пожаловать на {count} уровень. Необходимое количество очков: {count}, " +
        $"\nпри этом тебе придется быть впереди своего соперника минимум на 3 очка,тоесть, " +
        $"\nесли ты набрал необходимое количество очков,но у твоего соперника на одно очко меньше,чем у тебя, " +
        $"\nто игра продолжается до тех пор,пока отрыв по очкам не составит 3");
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("Нажмите ENTER для продолжения");
    Console.ReadLine();
}