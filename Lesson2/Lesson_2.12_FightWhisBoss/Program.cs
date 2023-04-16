using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2._12_FightWhisBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ConsoleWindowLength = 100;
            const int ConsoleWindowHeight = 40;
            const int WindowBorderthick = 1;
            const int LogsLineAppearenseDelay = 300;
            const char WindowBorderSymbolHorizontal = '#';
            const char WindowBorderSymbolVertical = '|';
            const char WindowHeaderLine = '-';
            const ConsoleColor WindowBorder = ConsoleColor.DarkGray;
            const ConsoleColor DefaultText = ConsoleColor.White;
            const ConsoleColor DefaultEnemyImage = ConsoleColor.DarkGray;
            const ConsoleColor HigthLihtSpellText = ConsoleColor.Cyan;
            const ConsoleColor ShieldTextColor = ConsoleColor.Blue;
            const ConsoleColor PlayerCriricalHealthColor = ConsoleColor.Red;
            const ConsoleColor PlayerHealthColor = ConsoleColor.DarkRed;

            const int EnemyWindowX = 1;
            const int EnemyWindowY = 16;
            const int EnemyWindowLength = 37;
            const int EnemyWindowHeight = 13;
            const int EnemyWindowTitleOffsetY = 1;
            const int EnemyWindowTitleOffsetX = 1;
            const string EnemyBossName = "Монтеск беспалый";
            const int EnemyHealthMaximum = 350;

            const int PlayerWindowX = 40;
            const int PlayerWindowY = 16;
            const int PlayerWindowLength = 55;
            const int PlayerWindowHeight = 13;
            const int PlayerWindowTitleOffsetY = 1;
            const int PlayerWindowTitleOffsetX = 1;
            const int PlayerWindowTextOffsetX = 2; 
            const string PlayerName = "Игрок";

            const int LogWindowX = 25;
            const int LogWindowY = 1;
            const int LogWindowLength = 70;
            const int LogWindowHeight = 13;
            const int LogWindowTitleOffsetY = 1;
            const int LogWindowTextOffsetX = 2;
            const string LogWindowName = "=-  ХОД ИГРЫ  -=";

            const string PlayerSpellPatronusCommand = "1";
            const string PlayerSpellImperioCommand = "2";
            const string PlayerSpellAvahtoCommand = "3";
            const string PlayerSpellImmobilusCommand = "4";
            const string PlayerSpellKonfundusCommand = "5";
            const string PlayerSpellAvadaKedavraCommand = "6";
            const string PlayerSpellExpiliarmusCommand = "7";
            const string ExitCommand = "8";

            const string PlayerLooseMoveTitle = "Игрок пропустил ход.";
            const string EnemyHealTitleMessage = "Гад вылечился!";
            const string PlayerInputCommandPrompt = "Выберите номер заклинания: ";
            const string LogPlayerMoveTitle = "Ход игрока:";
            const string LogEnemyMoveTitle = "Ход монстра:";
            const string DamageToPlayerShieldMessage = "Урон щиту игрока:";
            const string DamageToPlayerHealthMessage = "Урон здоровью игрока:";

            string[] intoText =
            {
                "Игрок применил магию Иммобилюс, голубой лучь света вылетает",
                "из палочки игрока, и создает вокруг него защитный купол.",
                "Заклинание отнимает 75 Hp у противника",
                "",
                "Босс Мандрагора : применил магию Експилиармус -  олубой лучь света",
                "применил магию Експилиармус -  олубой лучь света ",
                "Заклинание отнимает 75 Hp у игрока "
            };

            //Player Spell 1 Патронус - 30dmg
            string PlayerSpellPatronusName = "Патронус";
            int PlayerSpellPatronusPower = 30;
            int PlayerSpellPatronusRechargeTime = 2;
            int PlayerSpellPatronusTimeToCanCast = 0;
            string PlayerSpellPatronusTitle = $"Урон {PlayerSpellPatronusPower}.";
            string[] PlayerSpellPatronusText =
            {//  ---------------------------------------------------------|
                "Патронус учь ярко-бирюзового цвета врезается в грудь",
                "противника, и  LKJDLKJFS:LKFJ:SLDKFJ",
                "SDFJSLDKFJ:LSDKFJ:SLD"
            };
            string[] PlayerSpellPatronusWrongCast =
            {//  ---------------------------------------------------------|
                "Патронус НЕ СМОГ",
                "Жди перезарядки",
                "Патронус НЕ СМОГ"
            };

            //Player Spell 2 Империо - 30dmg
            string PlayerSpellImperioName = "Империо";
            int PlayerSpellImperioPower = 35;
            int PlayerSpellImperioRechargeTime = 3;
            int PlayerSpellImperioTimeToCanCast = 0;
            string PlayerSpellImperioTitle = $"Урон {PlayerSpellImperioPower}.";
            string[] PlayerSpellImperioText =
            {
                "Imperio, обезаруживает монстра на 2 раунда",
                "полупрозрачный красный свет создает обвалакивает монстра,",
                "и не позволяет ему колдовать 2 раунда"
            };
            string[] PlayerSpellImperioWrongCast =
            {//  ---------------------------------------------------------|
                "Imperio НЕ СМОГ",
                "Жди перезарядки",
                "Imperio НЕ СМОГ"
            };

            //Player Spell 3 Авахто (лечение)
            string PlayerSpellAvahtoName = "Авахто";
            string PlayerSpellAvahtoTitle = $"Лечение.";
            int PlayerSpellAvahtoAmmount = 2;
            string[] PlayerSpellAvahtoText =
            {//  ---------------------------------------------------------|
                "лечение ООО лечение РРР лечение ООО лечение РРР ",
                "лечение ООО лечение РРР лечение ООО лечение РРР лечение ООО ",
                "лечение ООО лечение РРР лечение ООО лечение РРР "
            };
            string[] PlayerSpellAvahtoWrongCast =
            {//  ---------------------------------------------------------|
                "Avahto НЕ СМОГ",
                "Не осталось сили. нету маны",
                "Avahto НЕ СМОГ"
            };

            //Player Spell 4 Иммобилус (щит)
            string PlayerSpellImmobilusName = "Иммобилус";
            string PlayerSpellImmobilusTitle = $"Щит.";
            int PlayerSpellImmobilusAmmount = 2;
            string[] PlayerSpellImmobilusText =
            {//  ---------------------------------------------------------|
                "Иммобилус ООО лечение РРР лечение ООО Иммобилус РРР ",
                "лечение ООО лечение РРР Иммобилус ООО лечение РРР лечение ООО ",
                "Иммобилус ООО лечение РРР лечение ООО Иммобилус РРР "
            };
            string[] PlayerSpellImmobilusWrongCast =
            {//  ---------------------------------------------------------|
                "Immobilus НЕ СМОГ",
                "Не осталось сили. нету маны Immobilus",
                "Immobilus НЕ СМОГ"
            };

            //Player Spell 5 Конфундус 
            string PlayerSpellKonfundusName = "Конфундус";
            int PlayerSpellKonfundusAmmount = 0;
            int PlayerSpellKonfundusEffectTime = 2;
            int PlayerSpellKonfundusAdventChance = 30;
            int PlayerSpellKonfundusCastReserv = 3;
            string PlayerSpellKonfundusTitle = $"Лишает магии {PlayerSpellKonfundusEffectTime} раунда.";
            string[] PlayerSpellKonfundusText =
            {//  ---------------------------------------------------------|
                "Иммобилус ООО лечение РРР лечение ООО Иммобилус РРР ",
                "лечение ООО лечение РРР Иммобилус ООО лечение РРР лечение ООО ",
                "Иммобилус ООО лечение РРР лечение ООО Иммобилус РРР "
            };
            string[] playerSpellKonfundusWrongCast =
            {//  ---------------------------------------------------------|
                "Конфундус НЕ СМОГ",
                "Не осталось сили. нету маны Конфундус",
                "Конфундус НЕ СМОГ"
            };

            //Player Spell 6 Авада-Кедавра 
            string PlayerSpellAvadaKedavraName = "Авада-Кедавра";
            int PlayerSpellAvadaKedavraAmmount = 0;
            int PlayerSpellAvadaKedavraPower = 100;
            int PlayerSpellAvadaKedavraAdventChance = 30;
            int PlayerSpellAvadaKedavraCastReserv = 3;
            string PlayerSpellAvadaKedavraTitle = $"Мощьный урон {PlayerSpellAvadaKedavraPower} Hp";
            string[] PlayerSpellAvadaKedavraText =
            {//  ---------------------------------------------------------|
                "Авада-Кедавра ООО Авада-Кедавра РРР          РРР ",
                "Авада-Кедавра Ое ООО ",
                "Авада-Кедавра  РРР "
            };
            string[] playerSpellAvadaKedavraWrongCast =
            {//  ---------------------------------------------------------|
                "Авада-Кедавра НЕ СМОГ",
                "Не осталось сили. нету маны Авада-Кедавра",
                "Авада-Кедавра НЕ СМОГ"
            };

            //Player Spell 7 Экспилиармус 
            string PlayerSpellExpiliarmusName = "Экспилиармус";
            int PlayerSpellExpiliarmusAmmount = 0;
            int PlayerSpellExpiliarmusPower = 75;
            int PlayerSpellExpiliarmusEffectTime = 1;
            int PlayerSpellExpiliarmusAdventChance = 30;
            int PlayerSpellExpiliarmusCastReserv = 3;
            string PlayerSpellExpiliarmusTitle = $"Урон {PlayerSpellExpiliarmusPower} Hp, задержка ";
            string[] PlayerSpellExpiliarmusText =
                        {//  ---------------------------------------------------------|
                "Экспилиармус ООО Экспилиармус РРР          РРР ",
                "Экспилиармус   Ое ООО ",
                "Экспилиармус  РРР "
            };
            string[] playerSpellExpiliarmusWrongCast =
            {//  ---------------------------------------------------------|
                "Экспилиармус НЕ СМОГ",
                "Не осталось сили. нету маны Экспилиармус",
                "Экспилиармус НЕ СМОГ"
            };


            // Enemy Spells
            // Enemy Spells 1
            string EnemySpellOneName = "Ближняя Атака ";
            int EnemySpellOnePower = 20;
            string EnemySpellOneTitle = $"Урон {EnemySpellOnePower}.";
            string[] EnemySpellOneText =
            {//  ---------------------------------------------------------|
                "Ближняя Атака БОСС цвета врезается в грудь",
                "противника, и  LKJDLKJFS:LKFJ:SLDKFJ",
                "SDFJSLDKFJ:LSDKFJ:SLD"
            };

            // Enemy Spells 2 молния
            string EnemySpellTwoName = "Удар молнией";
            int EnemySpellTwoPower = 40;
            int EnemySpellTwoRechargeTime = 3;
            int EnemySpellTwoTimeToCanCast = 0;
            string EnemySpellTwoTitle = $"Урон {EnemySpellTwoPower}.";
            string[] EnemySpellTwoText =
            {//  ---------------------------------------------------------|
                "Удар молнией , БОСС монстра на 2 раунда",
                "Удар молнией  красный свет создает обвалакивает монстра,",
                " Удар молниейа т ему колдовать 2 раунда"
            };

            // Enemy Spells 3 Авахто (лечение)
            int EnemySpellAvahtoAmmount = 1;
            string EnemySpellAvahtoName = "Авахто";
            string EnemySpellAvahtoTitle = $"Лечение.";
            string[] EnemySpellAvahtoText =
            {//  ---------------------------------------------------------|
                "лечение Босса ",
                "лечение Босса",
                "лечение Босса"
            };

            // Enemy Spells 3 Сектрум-Семпра (урон 60)
            // Enemy Spells 4 Волна-Расамента (дьявольские силки, игрок пропускает ход)
            // Enemy Spells 5 Eнгоргио, дух Василиска (отрава)
            // Enemy Spells 6 Авада-Кедавра (очень мощьное заклятие)


            string[] enemyBossImage =  
            {
                "  ░░░░░░▄▄▄░░  ▄▐",
                "  ░░░░░▐▀█▀▌░░▄██▄",
                "  ░░░░░▐█▄█▌░░░░░▀█▄",
                "  ░░░░░░▀▄▀░░░▄▄▄▄▀▀",
                "  ░░░░▄▄▄██▀▀▀▀",
                "  ░░░█▀▄▄▄█░▀▀",
                "  ░░░▌░▄▄▄▐▌▀▀▀",
                "  ▄░▐░░░▄▄░█░▀▀",
                "  ▀█▌░░░▄░▀█▀░▀",
                "  ░░░░░░░▄▄▐▌▄▄",
                "  ░░░░░░░▀███▀█░▄",
                "  ░░░░░░▐▌▀▄▀▄▀▐▄",
                "  ░░░░░░▐▀░░░░░░▐▌",
                "  ░░░░░░█░░░░░░░░█",
                "  ░░░░░▐▌░░░░░░░░░█"
            };

            int enemyWindowCursorPositionY;
            int playerWindowCursorPositionY;
            int logWindowCursorPositionY;
            bool isIntro = true;
            bool isBattleActive = true;
            string enemyWindowMessageCaсhe = "";
            string enemyWindowMessage1 = "";
            string enemyWindowMessage2 = "";
            string enemyWindowMessage3 = "";
            string enemyLogWindowFooterText = "";
            string logWindowClearLine = "";

            //параметры Player
            int playerHealthMaximum = 100;
            int PlayerHealth = playerHealthMaximum;
            int PlayerCriricalHealth = playerHealthMaximum / 3;
            int PlayerShieldMaximum = 100;
            int PlayerShield = 0;
            string inputCommand;
            string[] PlayerLooseMove =
            {//  ---------------------------------------------------------|
                "Игрок пропускает ход ",
                "PlayerLooseMove PlayerLooseMove",
                "PlayerLooseMove PlayerLooseMove"
            };

            //параметры Enemy
            int enemyHealth = EnemyHealthMaximum;
            int enemyCriticalHealth = 85;
            int enemyWeaknessHealth = 130;
            int enemyDealDamageToPlayer = 0;
            ConsoleColor enemyWeakness = ConsoleColor.Red;
            ConsoleColor enemyAlmostDieColor = ConsoleColor.DarkRed;

            string[] playerLogsOutput = new string[3];
            string[] enemyLogsOutput = new string[3];
            int persentageCoefficient = 100;
            Random random;

            Console.SetWindowSize(ConsoleWindowLength, ConsoleWindowHeight);
            random = new Random();

            for (int i = 0; i < (LogWindowLength -LogWindowTextOffsetX - WindowBorderthick * 2); i++)
                logWindowClearLine += " ";

            while (isBattleActive)
            {
                // Console.Clear();
                Console.ForegroundColor = DefaultEnemyImage;

                // восстановление магий игрока
                if (PlayerSpellPatronusTimeToCanCast > 0)
                    PlayerSpellPatronusTimeToCanCast--;
                if (PlayerSpellImperioTimeToCanCast > 0)
                    PlayerSpellImperioTimeToCanCast--;
                if (PlayerSpellKonfundusCastReserv > 0)
                {                    
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= PlayerSpellKonfundusAdventChance);
                    if (haveAdventSpell)
                    {
                        PlayerSpellKonfundusAmmount++;
                        PlayerSpellKonfundusCastReserv--;
                    }                        
                }
                if (PlayerSpellAvadaKedavraCastReserv > 0)
                {
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= PlayerSpellAvadaKedavraAdventChance);
                    if (haveAdventSpell)
                    {
                        PlayerSpellAvadaKedavraAmmount++;
                        PlayerSpellAvadaKedavraCastReserv--;
                    }
                }
                if (PlayerSpellExpiliarmusCastReserv > 0)
                {
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= PlayerSpellExpiliarmusAdventChance);
                    if (haveAdventSpell)
                    {
                        PlayerSpellExpiliarmusAmmount++;
                        PlayerSpellExpiliarmusCastReserv--;
                    }
                }

                // восстановление магий Enemy
                if (EnemySpellTwoTimeToCanCast > 0)
                    EnemySpellTwoTimeToCanCast--;
                // прокрутка логов Enemy
                if (enemyWindowMessage2 != "")
                    enemyWindowMessage3 = enemyWindowMessage2;
                else
                    enemyWindowMessage3 = "";

                if (enemyWindowMessage1 != "")
                    enemyWindowMessage2 = enemyWindowMessage1;
                else
                    enemyWindowMessage2 = "";

                if (enemyWindowMessageCaсhe != "")
                    enemyWindowMessage1 = enemyWindowMessageCaсhe;
                else
                    enemyWindowMessage1 = "";

                enemyWindowMessageCaсhe = "";




                Console.SetCursorPosition(0, 0);
                if (enemyHealth <= enemyCriticalHealth)
                    Console.ForegroundColor = enemyAlmostDieColor;
                else if(enemyHealth <= enemyWeaknessHealth)
                    Console.ForegroundColor = enemyWeakness;


                foreach (string line in enemyBossImage)
                    Console.WriteLine(line);

                Console.ForegroundColor = DefaultText;









                // Logs
                // Log window 
                Console.ForegroundColor = WindowBorder;
                Console.SetCursorPosition(LogWindowX, LogWindowY);
                // Log window title
                // --------------------------------------------
                Console.Write(WindowBorderSymbolHorizontal);
                Console.Write(LogWindowName);
                for (int i = 1; i < LogWindowLength - LogWindowName.Length; i++)
                    Console.Write(WindowBorderSymbolHorizontal);
                // |                                          |
                for (int i = 1; i < LogWindowHeight - LogWindowTitleOffsetY; i++)
                {
                    Console.SetCursorPosition(LogWindowX, LogWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(LogWindowX + LogWindowLength - WindowBorderthick, LogWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }
                Console.SetCursorPosition(LogWindowX, LogWindowY + LogWindowHeight - WindowBorderthick);
                // --------------------------------------------
                for (int i = 0; i < LogWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                // Log text            
                logWindowCursorPositionY = LogWindowTitleOffsetY;
                Console.ForegroundColor = DefaultText;
                //Clear Log Window
                for(int i=0; i<LogWindowHeight-WindowBorderthick*2; i++)
                {
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(logWindowClearLine);
                    logWindowCursorPositionY++;
                }

                logWindowCursorPositionY = LogWindowTitleOffsetY;

                if (isIntro)
                {
                    //intro
                    isIntro = false;
                    logWindowCursorPositionY++;
                    foreach (string textLine in intoText)
                    {
                        Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                        Console.Write(textLine);
                        logWindowCursorPositionY++;
                    }
                }
                else
                {
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(LogPlayerMoveTitle);
                    logWindowCursorPositionY++;
                    // Log player text
                    foreach (string textLine in playerLogsOutput)
                    {
                        Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                        Console.Write(textLine);
                        logWindowCursorPositionY++;
                        System.Threading.Thread.Sleep(LogsLineAppearenseDelay);
                    }
                    logWindowCursorPositionY++;
                    // Log enemy text
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(LogEnemyMoveTitle);
                    logWindowCursorPositionY++;
                    foreach (string textLine in enemyLogsOutput)
                    {
                        Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                        Console.Write(textLine);
                        logWindowCursorPositionY++;
                        System.Threading.Thread.Sleep(LogsLineAppearenseDelay);
                    }
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(enemyLogWindowFooterText);                    
                }

                






                // Draw Enemi window
                // Enemy window
                Console.ForegroundColor = WindowBorder;
                Console.SetCursorPosition(EnemyWindowX, EnemyWindowY);
                for (int i = 0; i < EnemyWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);
                for (int i = 1; i < EnemyWindowHeight - EnemyWindowTitleOffsetY; i++)
                {
                    Console.SetCursorPosition(EnemyWindowX, EnemyWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(EnemyWindowX + EnemyWindowLength - WindowBorderthick, EnemyWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }
                Console.SetCursorPosition(EnemyWindowX, EnemyWindowY + EnemyWindowHeight - WindowBorderthick);
                for (int i = 0; i < EnemyWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                Console.ForegroundColor = DefaultText;
                enemyWindowCursorPositionY = EnemyWindowTitleOffsetY;
                Console.SetCursorPosition(EnemyWindowX + EnemyWindowTitleOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                Console.Write($" {EnemyBossName} | Здоровье: {enemyHealth}");
                enemyWindowCursorPositionY++;
                Console.SetCursorPosition(EnemyWindowX + EnemyWindowTitleOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                for (int i = WindowBorderthick; i < EnemyWindowLength - WindowBorderthick; i++)
                    Console.Write(WindowHeaderLine);


                //enemy Текущий ход
                if(enemyWindowMessage1 != "")
                {
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write("Текущий ход:");
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write(enemyWindowMessage1);
                    enemyWindowCursorPositionY++;
                }
                if (enemyWindowMessage2 != "")
                {
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write("Прошлый ход:");
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write(enemyWindowMessage2); 
                    enemyWindowCursorPositionY++;
                }
                if (enemyWindowMessage3 != "")
                {
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write("Ранее:");
                    enemyWindowCursorPositionY++;
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write(enemyWindowMessage3);
                }




                // Player window draw

                Console.ForegroundColor = WindowBorder;
                Console.SetCursorPosition(PlayerWindowX, PlayerWindowY);
                // Player window title
                // --------------------------------------------
                for (int i = 0; i < PlayerWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);
                // |                                          |
                for (int i = 1; i < PlayerWindowHeight - PlayerWindowTitleOffsetY; i++)
                {
                    Console.SetCursorPosition(PlayerWindowX, PlayerWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowLength - WindowBorderthick, PlayerWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }
                Console.SetCursorPosition(PlayerWindowX, PlayerWindowY + PlayerWindowHeight - WindowBorderthick);
                // --------------------------------------------
                for (int i = 0; i < PlayerWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);


                // Player text
                playerWindowCursorPositionY = PlayerWindowTitleOffsetY;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($" {PlayerName} | ");
                if (PlayerHealth < PlayerCriricalHealth)
                    Console.ForegroundColor = PlayerCriricalHealthColor; 
                else
                    Console.ForegroundColor = PlayerHealthColor;
                Console.Write($"Здоровье: {PlayerHealth}");
                Console.ForegroundColor = DefaultText;
                Console.Write($" | ");
                if(PlayerShield > 0)
                    Console.ForegroundColor = ShieldTextColor;
                Console.Write($"Щит: {PlayerShield}");
                Console.ForegroundColor = DefaultText;
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                for (int i = WindowBorderthick; i < PlayerWindowLength - WindowBorderthick; i++)
                    Console.Write(WindowHeaderLine);

                Console.ForegroundColor = DefaultText;
                // Player menu text 
                // Write Spell 1 menu
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellPatronusCommand}. {PlayerSpellPatronusName} - {PlayerSpellPatronusTitle} " +
                             $"Перезарядка {PlayerSpellPatronusTimeToCanCast}.");
                // Write Spell 2 menu
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellImperioCommand}. {PlayerSpellImperioName} - {PlayerSpellImperioTitle} " +
                              $"Перезарядка {PlayerSpellImperioTimeToCanCast}.");
                // Write Spell 3 menu Авахто (лечение)
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellAvahtoCommand}. {PlayerSpellAvahtoName} - {PlayerSpellAvahtoTitle} " +
                              $"Кол-во {PlayerSpellAvahtoAmmount}.");
                // Write Spell 4 menu Иммобилус
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellImmobilusCommand}. {PlayerSpellImmobilusName} - {PlayerSpellImmobilusTitle} " +
                              $"Кол-во {PlayerSpellImmobilusAmmount}.");
                // Write Spell 5 menu Конфундус
                Console.ForegroundColor = HigthLihtSpellText;
                if (PlayerSpellKonfundusAmmount > 0)
                {

                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellKonfundusCommand}. {PlayerSpellKonfundusName} - {PlayerSpellKonfundusTitle} " +
                                  $"Кол-во {PlayerSpellKonfundusAmmount}.");
                }
                // Write Spell 6 menu Авада-Кедавра
                if (PlayerSpellAvadaKedavraAmmount > 0)
                {
                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellAvadaKedavraCommand}. {PlayerSpellAvadaKedavraName} - {PlayerSpellAvadaKedavraTitle} " +
                                  $"Кол-во {PlayerSpellAvadaKedavraAmmount}.");
                }
                // Write Spell 7 menu Экспилиармус
                if (PlayerSpellExpiliarmusAmmount > 0)
                {
                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellExpiliarmusCommand}. {PlayerSpellExpiliarmusName} - {PlayerSpellExpiliarmusTitle} " +
                                  $"Кол-во {PlayerSpellExpiliarmusAmmount}.");
                }

                Console.ForegroundColor = DefaultText;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + PlayerWindowHeight - WindowBorderthick*2);
                Console.Write(PlayerInputCommandPrompt);
                inputCommand = Console.ReadLine();






                switch (inputCommand)
                {
                    case PlayerSpellPatronusCommand:
                        if (PlayerSpellPatronusTimeToCanCast > 0)
                        {
                            playerLogsOutput = PlayerSpellPatronusWrongCast;
                        }
                        else
                        {
                            PlayerSpellPatronusTimeToCanCast = PlayerSpellPatronusRechargeTime;
                            playerLogsOutput = PlayerSpellPatronusText;
                            enemyHealth -= PlayerSpellPatronusPower;
                            enemyWindowMessageCaсhe = $"{PlayerSpellPatronusName} -{PlayerSpellPatronusPower}. Осталось {enemyHealth}";
                        }                            
                        break;

                    case PlayerSpellImperioCommand:
                        if (PlayerSpellImperioTimeToCanCast > 0)
                        {
                            playerLogsOutput = PlayerSpellImperioWrongCast;
                        }
                        else
                        {
                            PlayerSpellImperioTimeToCanCast = PlayerSpellImperioRechargeTime;
                            playerLogsOutput = PlayerSpellImperioText;
                            enemyHealth -= PlayerSpellImperioPower;
                            enemyWindowMessageCaсhe = $"{PlayerSpellImperioName} -{PlayerSpellImperioPower}. Осталось {enemyHealth}";
                        }
                        break;

                    case PlayerSpellAvahtoCommand:
                        if (PlayerSpellAvahtoAmmount <= 0)
                        {
                            playerLogsOutput = PlayerSpellAvahtoWrongCast;
                            break;
                        }                            
                        PlayerSpellAvahtoAmmount--;
                        playerLogsOutput = PlayerSpellAvahtoText;
                        enemyWindowMessageCaсhe = $"{PlayerSpellAvahtoName}. Игрок вылечился.";
                        break;

                    case PlayerSpellImmobilusCommand:
                        if (PlayerSpellImmobilusAmmount <= 0)
                        {
                            playerLogsOutput = PlayerSpellImmobilusWrongCast;
                            break;
                        }
                        PlayerShield = PlayerShieldMaximum;
                        PlayerSpellImmobilusAmmount--;
                        playerLogsOutput = PlayerSpellImmobilusText;
                        enemyWindowMessageCaсhe = $"{PlayerSpellImmobilusName}. Игрок поставил щит.";
                        break;

                    case PlayerSpellKonfundusCommand:
                        if (PlayerSpellKonfundusAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellKonfundusWrongCast;
                            break;
                        }
                        PlayerSpellKonfundusAmmount--;
                        playerLogsOutput = PlayerSpellKonfundusText;
                        enemyWindowMessageCaсhe = $"{PlayerSpellKonfundusName} - Игрок сбил заклятья.";
                        break;

                    case PlayerSpellAvadaKedavraCommand:
                        if (PlayerSpellAvadaKedavraAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellAvadaKedavraWrongCast;
                            break;
                        }
                        PlayerSpellAvadaKedavraAmmount--;
                        playerLogsOutput = PlayerSpellAvadaKedavraText;
                        enemyHealth -= PlayerSpellAvadaKedavraPower;
                        enemyWindowMessageCaсhe = $"{PlayerSpellAvadaKedavraName} -{PlayerSpellAvadaKedavraPower}. Осталось {enemyHealth}";
                        break;

                    case PlayerSpellExpiliarmusCommand:
                        if (PlayerSpellExpiliarmusAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellExpiliarmusWrongCast;
                            break;
                        }
                        PlayerSpellExpiliarmusAmmount--;
                        playerLogsOutput = PlayerSpellExpiliarmusText;
                        enemyHealth -= PlayerSpellExpiliarmusPower;
                        enemyWindowMessageCaсhe = $"{PlayerSpellExpiliarmusName} -{PlayerSpellExpiliarmusPower}. Осталось {enemyHealth}";
                        break;

                    case ExitCommand:
                        isBattleActive = false;
                        break;

                    default:
                        playerLogsOutput = PlayerLooseMove;
                        enemyWindowMessageCaсhe = PlayerLooseMoveTitle;
                        break;
                }




                // ENEMY MOOVE
                // ENEMY MOOVE
                // ENEMY MOOVE
                if (enemyHealth < enemyCriticalHealth && EnemySpellAvahtoAmmount>0)
                {
                    EnemySpellAvahtoAmmount--;
                    enemyLogsOutput = EnemySpellAvahtoText;
                    enemyHealth = EnemyHealthMaximum;
                    enemyWindowMessageCaсhe = $"{EnemyHealTitleMessage} Осталось {enemyHealth}";
                }
                else if (EnemySpellTwoTimeToCanCast <= 0)
                {
                    // enemy spell 2 
                    enemyDealDamageToPlayer = EnemySpellTwoPower;
                    enemyLogsOutput = EnemySpellTwoText;
                    EnemySpellTwoTimeToCanCast = EnemySpellTwoRechargeTime;
                }
                else
                {
                    // enemy spell 1                
                    enemyDealDamageToPlayer = EnemySpellOnePower;
                    enemyLogsOutput = EnemySpellOneText;
                }

                enemyLogWindowFooterText = "";
                if (enemyDealDamageToPlayer > 0)
                {
                    if(PlayerShield>0 && PlayerShield >= enemyDealDamageToPlayer)
                    {
                        PlayerShield -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText = $"{DamageToPlayerShieldMessage} {enemyDealDamageToPlayer} "; 
                    }   
                    else if(PlayerShield > 0 && PlayerShield < enemyDealDamageToPlayer)
                    {
                        enemyDealDamageToPlayer -= PlayerShield;
                        enemyLogWindowFooterText = $"{DamageToPlayerShieldMessage} {PlayerShield} ";
                        PlayerShield = 0;
                        PlayerHealth -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText += $"{DamageToPlayerHealthMessage} {enemyDealDamageToPlayer}"; 
                    }
                    else
                    {
                        PlayerHealth -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText += $"{DamageToPlayerHealthMessage} {enemyDealDamageToPlayer}";
                    }
                    enemyDealDamageToPlayer = 0;
                }

            }












            Console.ReadLine();


        }
    }
}
