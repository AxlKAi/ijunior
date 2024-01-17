using System;

namespace Lesson_2._12_FightWhisBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ConsoleWindowLength = 100;
            const int ConsoleWindowHeight = 40;
            const int WindowBorderthick = 1;
            const int LogsLineAppearenseDelay = 100;
            const char WindowBorderSymbolHorizontal = '-';
            const char WindowBorderSymbolVertical = ':';
            const char WindowHeaderLine = '.';

            const ConsoleColor WindowBorderColor = ConsoleColor.DarkGray;
            const ConsoleColor WindowTitleColor = ConsoleColor.DarkGray;
            const ConsoleColor DefaultTextColor = ConsoleColor.White;
            const ConsoleColor DefaultEnemyImageColor = ConsoleColor.DarkGray;
            const ConsoleColor HigthLihtSpellTextColor = ConsoleColor.Cyan;
            const ConsoleColor ShieldTextColor = ConsoleColor.Blue;
            const ConsoleColor LogWindowEnemyFooterColor = ConsoleColor.DarkRed;
            const ConsoleColor PlayerCriricalHealthColor = ConsoleColor.Red;
            const ConsoleColor PlayerHealthColor = ConsoleColor.DarkRed;
            const ConsoleColor EnemyImageCastSpellColor = ConsoleColor.Yellow;
            const ConsoleColor EnemyWeaknessColor = ConsoleColor.Red;
            const ConsoleColor EnemyAlmostDieColor = ConsoleColor.DarkRed;
            const ConsoleColor EnemyVasiliskColor = ConsoleColor.DarkGreen;
            const ConsoleColor FinalImageColor = ConsoleColor.DarkGray;

            const int EnemyWindowX = 1;
            const int EnemyWindowY = 16;
            const int EnemyWindowLength = 37;
            const int EnemyWindowHeight = 13;
            const int EnemyWindowTitleOffsetY = 1;
            const int EnemyWindowTitleOffsetX = 1;
            const string EnemyBossName = "Монтеск беспалый";
            const int EnemyAnimationFramesDelay = 75;

            const int EnemyImagePositionX = 2;
            const int EnemyImagePositionY = 0;
            const int VasiliskImagePositionX = 2;
            const int VasiliskImagePositionY = 9;

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

            const int FinalWindowX = 5;
            const int FinalWindowY = 3;
            const int FinalWindowLength = 90;
            const int FinalWindowHeight = 27;
            const int FinalWindowTextOffsetY = 2;
            const int FinalWindowTextOffsetX = 31;
            const int FinalWindowImageOffsetY = 5;
            const int FinalWindowImageOffsetX = 2;

            const string PlayerSpellPatronusCommand = "1";
            const string PlayerSpellImperioCommand = "2";
            const string PlayerSpellAvahtoCommand = "3";
            const string PlayerSpellImmobilusCommand = "4";
            const string PlayerSpellKonfundusCommand = "5";
            const string PlayerSpellAvadaKedavraCommand = "6";
            const string PlayerSpellExpiliarmusCommand = "7";
            const string ExitCommand = "8";

            const string ExitCommandTitle = "Порталиec-Драппа <Выход из игры>";
            const string PlayerLooseMoveTitle = "Игрок пропустил ход.";
            const string EnemyHealTitleMessage = EnemyBossName + " вылечился!";
            const string PlayerInputCommandPrompt = "Выберите номер заклинания: ";
            const string LogPlayerMoveTitle = "Ход игрока:";
            const string LogEnemyMoveTitle = "Ход монстра:";
            const string DamageToPlayerShieldMessage = "Урон щиту игрока:";
            const string DamageToPlayerHealthMessage = "Урон здоровью игрока:";
            const string EnemyCantCastRoundsMessage = "Не колдует:";
            const string VasiliskDamgeMessage = " ^_^ из них Василиск ";
            const string PressKeyPrompt = "Нажмите любую кнопку для продолжения....";

            string[] intoText =
            {
                "  Вы  управляете  молодым  магом, студентом  Волшебной  Семинарии.",
                "Неожиданно возникший портал перенес  героя  в  большое  обведшалое",
                "помещение подземного дворца.  В центре  колонного  зала расположен",
                "алтарь, на котором хранится недостающая магу часть реликта.",
                "  Мунускрипт найденный в древлехранилище Семинарии таил неприятный",
                "сюрприз.  Он  не только  указывал дорогу к последней части амулета",
                "\"Здоровой Крови\" Античных, но и телепортировал поисковика к оному.",
                " Артефакт стережет скелет, некогда крупного воина. Слабо заметное",
                "алое свечение соединяет алтарь и стражника. Заметив гостя мертвяк",
                "резким движением разворачивается и движется на Вас... "
            };

            string[] bossWinFinalText =
            {
                "",
                "",
                "  Силы  покидали  ворожея. Очередной удар подкосил героя.",
                "Он оступился  и  долговязый  мертвяк нанес удар  в спину.",
                "  Неужели так все закончится!",
                "  В  глазах темнело. Собственное тело перестало слушаться",
                "и  опало  обмякши.   Сквозь  мглу  угасающего сознания Вы",
                "видите  очертания  зала.  Скелет забирает часть реликта у",
                "поверженного  мага,   и  кладет ее  на алтарь.  Очертания",
                "становятся четче, видно как разрозненные части  артефакта",
                "собираются в единый оберег.",
                "  Тело  волшебника  вдруг начинает подниматься.  Сознание",
                "парит по залу не в силах управлять  движеньем. Взгляд Ваш",
                "прикован к алтарю  вокруг  которого  мертвецки  медленной",
                "походкой теперь бродят два стражника.."
            };

            string[] playerWinFinalText =
            {   "  Сильный  удар  магией  разносит  в  прах  ноги  изрядно",
                "потрепанного схваткой мертвеца. Его  туловище  рушится на",
                "мрамор пола, как  груда костей.  С  довольной  улыбкой на",
                "лице, ворожей  наносит неспешный, но сильный удар магией,",
                "которым разносит в щепки оставшееся тело скелета! ",
                "  Бой кончен!  Вот  она,  сладость победы!  Настал момент ",
                "соединить   во  едино  обломки  артефакта.    С  чувством ",
                "восхищения, перемешанной с легким  трепетом  предвкушения ",
                "не  известности,  прихрамывая,  маг  подходит  к  алтарю.",
                "С первых  лет  обучения  семинарист начал поиски  амулета",
                "\"Здоровой  Крови\"  Античных.   И  вот  она,  долгожданная",
                "последняя часть!  Разделенные половинки cлились во едино,",
                "яркая вспышка  света  озарила  зал. Становятся видны души",
                "проклятых, парящих вокруг алтаря.     Слышен  гул голосов",
                "Античных, они  произносят разные заклинания. Язык древних",
                "ворожею не знаком, но несколько из них  ворожей  понимает",
                "и запоминает.",
                "  Амулет собран!  Сила  крови  великих  Античных пращуров",
                "теперь течет в Ваших жилах! Физическое тело стало крепче,",
                "и новые знания открылись Вам ..."
            };

            string[] bothDeadFinalText =
            {
                "  Мучительно  долгое  сражение  подходило к концу.  Кости",
                "скелета были сильно повреждены, а каркас маячило в разные",
                "стороны.  Тяжело  дышавший  маг,  обессиленным  движением",
                "выкинул самое мощное  заклятие  на которое  был способен.",
                "Одновременно с этим, мертвяк  сотворил  свое  сильнейшее.", 
                "Оба  удара  достигли  цели. Последнее, что видел ворожей,",
                "как  груда  костей  рухнула на мраморный пол,  не подавая",
                "признаков  жизни.  Сознание  помутнело,  но  позже  стали",
                "различимы  очертания зала.  Взор был направлен на алтарь,",
                "подле   которого   была  разбросана  груда костей, смутно",
                "напоминавшая  некогда  грозного  врага. С  другой стороны",
                "распласталось  тело  ворожея.  Словно поддаваемая легкому",
                "бризу,   душа  мага  начала  парить  по  кругу,  в центре",
                "которого был алтарь, с возложенной частью реликта. Спустя",
                "некоторое время, тело, некогда принадлежавшее волшебнику,",
                "стало  подниматься.  Бездушно-мертвецкими  движениями оно",
                "подошло к алтарю, соединило части амулета в единое целое,",
                "положило  артефакт на алтарь, и побрело по кругу, даже не",
                "полюбовавшись столь желанной добычей."
            };

            string playerSpellPatronusName = "Патронус";
            int playerSpellPatronusPower = 35;
            int playerSpellPatronusRechargeTime = 2;
            int playerSpellPatronusTimeToCanCast = 0;
            string playerSpellPatronusLog = $"Урон {playerSpellPatronusPower}.";
            string[] playerSpellPatronusText =
            {
                "Храбрец делает короткий  взмах палочкой, так хорошо отточенный еще",
                "с первого курса  Волшебной  Семинарии. Из  палочки  вылетает яркий",
                "светлый шар и поражает нежить!"
            };
            string[] playerSpellPatronusWrongCast =
            {
                "В любом бою важно сохранять самообладание и концентрацию!  Правило",
                "настолько же простое, на сколько  сложно его выполнить в пылу боя.",
                "Маг поспешил, не сконцентрировался, и заклятие сорвалось..."
            };

            string playerSpellImperioName = "Империо";
            int playerSpellImperioPower = 45;
            int playerSpellImperioRechargeTime = 3;
            int playerSpellImperioTimeToCanCast = 0;
            string playerSpellImperioLog = $"Урон {playerSpellImperioPower}.";
            string[] playerSpellImperioText =
            {
                "Маг делает резкий выпад вперед, и  изрекает боевой клич - Империо!",
                "В нежить  летит  большой  серебристый гладиус,  осеянный  брызгами",
                "молний. Чары разбиваются о недруга, и рассыпаются снопом искр."
            };
            string[] playerSpellImperioWrongCast =
            {
                "Резкий выпад, но боевой клич срывается на кашель!  Ворожей слишком",
                "спешит...  В сознании мелькает:  \"Не время! Наберись сил!\".  Помни,",
                "самообладание и концентрация... Заклятие не получилось."
            };

            string playerSpellAvahtoName = "Авахто";
            string playerSpellAvahtoLog = $"Полное излечение.";
            int playerSpellAvahtoAmmountMaximum = 2;
            int playerHealthLevelIncrease = 75;
            int playerSpellAvahtoAmmount = playerSpellAvahtoAmmountMaximum;
            string[] playerSpellAvahtoText =
            {
                "Магик извлекает пузырёк алой жидкости, быстро чарует его и пьет.",
                "Вокруг тела появляется яркий перелив цветов радуги.",
                "Раны затягивает. Вы вновь полны сил и здоровья."
            };
            string[] playerSpellAvahtoSpecialText =
            {
                "Внезапно, обряд  лечения  вызвал  ярко-алую ауру, связавшую мага и",
                "реликт с алтаря. Оба противника применили древнее заклятье Авахто.",
                "Разделенные части амулета \"Здоровой Крови\" Античных усилили эфект.",
                "Здоровье героя выросло, склянки с врачевным зельем пополнены."
            };
            string[] playerSpellAvahtoWrongCast =
            {
                "Чародей шарится по карманам  камзола, но найти  сляночку не может.",
                "Драгоценное время потеряно, ход за противником. Для восстановления",
                "сил требуется врачевное зелье, которого увы нет.."
            };

            string playerSpellImmobilusName = "Иммобилус";
            string playerSpellImmobilusTitle = "Щит.";
            int playerSpellImmobilusAmmount = 3;
            string[] playerSpellImmobilusText =
            {
                "Маг  описывает  палочкой литеру, призывая дух горной рыси. Крупный",
                "прозрачный торс волшебной кошки  покрыт ярко-синими рунами. Хищник",
                "может  атаковать  мелкое  враждебное магическое существо. Не найдя",
                "жертвы, она растворяется создавая защитный купол.",
            };

            string[] playerSpellImmobilusSpecialText =
            {
                "Ворожей  призывает дух горной рыси.  Волшебная  кошка находит себе",
                "развлечение.  Она  играючи  кидается на Василиска, уворачиваясь от",
                "его атак. В конце-концов  руническая рысь изводит Василиска, после",
                "чего кастует магу защитный барьер и исчезает.",
            };

            string[] PlayerSpellImmobilusWrongCast =
            {
                "Маг описывает палочкой литеру, призывая горную рысь. Но в этот раз",
                "хищница  не  приходит на помощь.  Духи хотят покоя.  Число вызовов",
                "кошки ограниченно.",
            };

            string playerSpellKonfundusName = "Конфундус";
            int playerSpellKonfundusAmmount = 0;
            int playerSpellKonfundusEffectTime = 3;
            int playerSpellKonfundusAdventChance = 12; 
            int playerSpellKonfundusCastReserv = 3;
            string playerSpellKonfundusTitle = $"Лишает магии {playerSpellKonfundusEffectTime} раунда.";
            string[] playerSpellKonfundusText =
            {
                "Из палочки волшебника вылетают изумрудные молнии,  попадая в череп",
                "противника.   Корпус  скелета  искрит,  аура  между  ним и алтерем",
               $"пропадает. Мертвяк не может колдовать {playerSpellKonfundusEffectTime} раунда.",
            };
            string[] playerSpellKonfundusWrongCast =
            {
                "Лишь малая часть знаний  Античных дошла до  нашего  времени. Магия",
                "крадущая силы противника одна из них. В этот раз изумрудные молнии",
                "разбились  об ореол  возникший  из  потока  силы  между скелетом и",
                "артефактом. У Вас недостаточно сил.",
            };

            string playerSpellAvadaKedavraName = "Авада-Кедавра";
            int playerSpellAvadaKedavraAmmount = 0;
            int playerSpellAvadaKedavraPower = 100;
            int playerSpellAvadaKedavraAdventChance = 12;
            int playerSpellAvadaKedavraCastReserv = 3;
            int playerSpellAvadaKedavraEnhancementPower = playerSpellAvadaKedavraPower / 2;
            bool wasLastEnemySpellAvadaKedavra = false;
            string playerSpellAvadaKedavraTitle = $"Мощьный урон {playerSpellAvadaKedavraPower} Hp";
            string[] playerSpellAvadaKedavraText =
            {
                "Маг  вспоминает  мудреную  древнюю руну и выводит ее. Над скелетом",
                "появляется россыпь крупных льдин, которые рушатся на мертвяка. Зал",
                "наполнился ледяными снежинками, повеяло холодом.",
            };
            string[] playerSpellAvadaKedavraWrongCast =
            {
                "При  произношенни   заклятия   \"Авада-Кедавра\",  чародеем  овладел",
                "приступ сильного кашля. Заклинание Авада-Кедавра не получилось.",
            };
            string[] playerSpellAvadaKedavraSpecialCast =
            {
                "Грохочущим  эхом  по залу  разносится  заклинание сказанное магом.",
                "Сотворенные  льдины  значительно  крупнее   обычных.    Заклинание",
                $"получает дополнительный урон в {playerSpellAvadaKedavraEnhancementPower} единиц.",
            };

            string playerSpellExpiliarmusName = "Экспилиармус";
            int playerSpellExpiliarmusAmmount = 0;
            int playerSpellExpiliarmusPower = 75;
            int playerSpellExpiliarmusEffectTime = 1;
            int playerSpellExpiliarmusAdventChance = 12;
            int playerSpellExpiliarmusCastReserv = 3;
            string playerSpellExpiliarmusTitle = $"Урон {playerSpellExpiliarmusPower} Hp, задержка ";
            string[] playerSpellExpiliarmusText =
            {
                "Воздух вокруг  нежити  сгущается,   словно  плавится, и происходит",
                "звучных  хлопок!   Волшебник  применил антимагию, прием взрывающий",
                "магическую энергию врага. ",
               $"Скелет не сможет колдовать {playerSpellExpiliarmusEffectTime} ход " +
               $"и получает урон в {playerSpellExpiliarmusPower} единиц."
            };
            string[] playerSpellExpiliarmusWrongCast =
            {
                "Юный  волшебник   произносит  сложное  заклинание  и  одновременно",
                "вырисовывает  магическую  литеру,  как вдруг чувствует резкую боль",
                "в спине.  Травма  полученная в фехтовальном  зале Семинарии, после",
                "занятий с Осью Апполона сказалась так не вовремя. Магия сорвалась."
            };

            int enemyPunchPower = 20;
            string[] enemyPunchText =
            {
                "Мертвяк неожиданно  проворно бросается на мага, и наносит хлесткий",
                "ощутимый  удар.  Проворность   ветхой   нежити вызывает изумление!",
                "Многие молодые трюкачи позавидуют его ловкости."
            };

            int enemySpellInflarmePower = 40;
            int enemySpellInflarmeRechargeTime = 3;
            int enemySpellInflarmeTimeToCanCast = 0;
            string[] enemySpellInflarmeText =
            {
                "Из  темноты  колонного  зала  вылетает  несколько  крупных злобных",
                "фантомов  летучих  мышей, которые атакуют героя звуковыми ударами.",
                "Маг применяет контрудар, но все же несколько волн достигают цели.",
            };

            int enemySpellAvahtoAmmount = 1;
            string enemySpellAvahtoTitle = $"Лечение.";
            string[] enemySpellAvahtoText =
            {
                "Ходячие мощи  вскидывают руки  вверх, взывая  Античных  о  помощи.",
                "Реликт на алтаре вспыхивает, и наполняет скелет светящейся формой.",
                "Кости врага воссоздаются. Вам хочется сотворить АВАХТО самому!"
            };

            int enemySpellSektrumSempraPower = 60;
            int enemySpellSektrumSempraRechargeTime = 3; 
            int enemySpellSektrumSempraTimeToCanCast = 0; 
            int enemySpellSektrumSempraAdventChance = 60; 
            int enemySpellSektrumSempraCastReserv = 2;
            int enemySpellSektrumSempraAmmount = 0;            
            string[] enemySpellSektrumSempraText =
            {
                "Скелет  щелкает  костяшками   пальцев,    раздается  мощный  рокот",
                "камнепада  и  с  колон  зала  на ворожея начинают сыпаться крупные",
                "булыжники, причиняя сильные травмы герою.",
            };

            int enemySpellEngorgioPower = 20;
            int enemySpellEngorgioRechargeTime = 3;
            int enemySpellEngorgioTimeToCanCast = 0;
            int enemySpellEngorgioAdventChance = 60;
            int enemySpellEngorgioCastReserv = 2;
            int enemySpellEngorgioAmmount = 0;
            int enemyVasilisklAliveRounds = 0;
            int enemyVasilisklAliveRoundsMaximum = 3;
            string[] enemySpellEngorgioText =
            {
                "Из  набедренных  лохмотьев  скелет  достает  склянку и бросает ее.",
                "Возникает тучка яда из которой на мага бросается ВАСИЛИСК, мелкая",
                "тварь, смесь змеи и дракона. Что если накастовать щит ?",
            };

            int enemySpellAvadaKedavraPower = 75;
            int enemySpellAvadaKedavraRechargeTime = 5;
            int enemySpellAvadaKedavraTimeToCanCast = 0;
            int enemySpellAvadaKedavraAdventChance = 60; 
            int enemySpellAvadaKedavraCastReserv = 2;
            int enemySpellAvadaKedavraAmmount = 0;
            string[] EnemySpellAvadaKedavraText =
            {
                "Костяной воин бормочет странным  говором знакомые выражения...  По",
                "залу грохочет Авада-Кедавра! Льдины рушатся на мага! Игроку знаком",
                "этот древний трюк... Что если произнести его сейчас?",
            };

            string[] enemyBossImage =
            {
                "      ▄▄▄    ▄▐    ",
                "     ▐▀█▀▌  ▄██▄   ",
                "     ▐█▄█▌     ▀█▄ ",
                "      ▀▄▀   ▄▄▄▄▀▀ ",
                "    ▄▄▄██▀▀▀▀    ",
                "   █▀▄▄▄█ ▀▀ ",
                "   ▌ ▄▄▄▐▌▀▀▀ ",
                "▄ ▐   ▄▄ █ ▀▀ ",
                "▀█▌   ▄ ▀█▀ ▀ ",
                "       ▄▄▐▌▄▄ ",
                "       ▀███▀█ ▄ ",
                "      ▐▌▀▄▀▄▀▐▄ ",
                "      ▐▀      ▐▌",
                "      █        █",
                "     ▐▌         █"
            };

            string[][] enemyArmAnimation = new string[4][];
            enemyArmAnimation[0] = new string[] {
                "         " ,
                " ▄▐      " ,
                "▄██▄▄▄   " ,
                "▄▄▄▄▀▀   " ,
                 "        " 
                    };

            enemyArmAnimation[1] = new string[] 
            {
                 "   ▄    " ,
                 " ▄▀░▀▄  ",
                 "▄█▀▄█▄  ",
                 "▄▄▄▄▀▀  ",
                 "        "
            };

            enemyArmAnimation[2] = new string[] 
            {
                " ▄ ▄ ▄   ",
                " ▄▀░▀▄   ",
                "▄█░ ░█   ",
                "▄▄▀▄▀▄   "
            };

            enemyArmAnimation[3] = new string[]
            {
                "▀▄ ▄▄ ▄▀",
                " ▄▀░░▀▄",
                "▄█░▄▀░█",
                "▄▄▀▄▄▀▄",
                "▀      ▀"
            };

            string[] enemyVasiliskImage = 
            { 
                "█████████",
                "█▄█████▄█",
                "█ ▼▼▼▼▼ █",
                "██▌    ██",
                "█ ▲▲▲▲▲ █",
                "█████████"
            };

            string[] playerDeadImage =
            {
                "██░└┐░░░░░░░░░░░░░░░░░┌┘░██",
                "██░░└┐░░░░░░░░░░░░░░░┌┘░░██",
                "██░░┌┘▄▄▄▄▄░░░░░▄▄▄▄▄└┐░░██",
                "██▌░│██████▌░░░▐██████│░▐██",
                "███░│▐███▀▀░░▄░░▀▀███▌│░███",
                "██▀─┘░░░░░░░▐█▌░░░░░░░└─▀██",
                "██▄░░░▄▄▄▓░░▀█▀░░▓▄▄▄░░░▄██",
                "████▄─┘██▌░░░░░░░▐██└─▄████",
                "█████░░▐█─┬┬┬┬┬┬┬─█▌░░█████",
                "████▌░░░▀┬┼┼┼┼┼┼┼┬▀░░░▐████",
                "█████▄░░░└┴┴┴┴┴┴┴┘░░░▄█████"
            };

            string[] playerWinImage =
            {
                "            █ █ ",
                "             █",
                "          ███████ ",
                "        ███  █  ███ ",
                "       ██ █     █ ██  ",
                "      ██   █   █   ██ ",
                "      ██    ███    ██ ",
                "      ██   █   █   ██ ",
                "       ██ ██   ██ ██  ",
                "        ███  █  ███   ",
                "          ███████     "
            };

            int[][] enemyDieAnimationFrames = new int[4][];
            enemyDieAnimationFrames[0] = new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14 };
            enemyDieAnimationFrames[1] = new int[] { 2, 3, 4, 5, 7, 9, 10, 11, 12, 13 };
            enemyDieAnimationFrames[2] = new int[] { 2, 3, 4, 5, 9, 10, 13 };
            enemyDieAnimationFrames[3] = new int[] { 2, 4, 5, 9 };

            int[][] enemyAttackAnimationFrames = new int[3][];
            enemyAttackAnimationFrames[0] = new int[] { 1, 1, 1, 1 };
            enemyAttackAnimationFrames[1] = new int[] { 2, 2, 2, 2, 1, 1, 1, 1, 1 };
            enemyAttackAnimationFrames[2] = new int[] { 3, 3, 3, 3, 2, 2, 2 };
            string[] finalOutputImage;
            string[] finalOutputText;

            int enemyWindowCursorPositionY;
            int playerWindowCursorPositionY;
            int logWindowCursorPositionY;
            int enemyImageCursorPositionY;
            int finalWindowCursorPositionY;
            bool isIntro = true;
            bool isBattleActive = true;
            bool canShowEnemyCastAnimation = true;
            string enemyWindowMessageCaсhe = "";
            string enemyWindowMessage1 = "";
            string enemyWindowMessage2 = "";
            string enemyWindowMessage3 = "";
            string enemyLogWindowFooterText = "";
            string logWindowClearLine = "";
            string playerWindowClearLine = "";
            string enemyWindowClearLine = "";
            string enemyImageClearLine = "";
            string finalWindowClearLine = "";

            int playerHealthMaximum = 175;
            int playerHealth = playerHealthMaximum;
            int playerCriricalHealth = playerHealthMaximum / 3;
            int playerShieldMaximum = 100;
            int playerShield = 0;
            bool isPlayerDead = false;
            string inputCommand;
            string[] playerLooseMove =
            {
                "Страх и оцепенение овладело ворожеем! Он пропускает ход. Аккуратее",
                "вводите команды, пожалуйста!!! Он - один из лучших выпускников! Не",
                "ввергайте в шок его разум. Он искусственный.",
            };

            int enemyHealthMaximum = 450;
            int enemyHealth = enemyHealthMaximum;
            int enemyCriticalHealth = 150;
            int enemyWeaknessHealth = 150;
            int enemyDealDamageToPlayer = 0;
            int enemyCantCastSpellsRounds = 0;
            int enemyImageArmPositionX = EnemyImagePositionX + 14;
            int enemyImageArmPositionY = EnemyImagePositionY;
            int enemyImageClearLineLength = LogWindowX - EnemyImagePositionX - 1;
            bool isEnemyDie = false;
            bool canEnemyCastSpells = true;
            bool isVasiliskActive = false;
            bool wasLastEnemvySpellAvahto = false;
            ConsoleColor currentEnemyImageColor = DefaultEnemyImageColor;

            string[] playerLogsOutput = new string[3];
            string[] enemyLogsOutput = new string[3];
            int persentageCoefficient = 100;
            Random random;

            Console.SetWindowSize(ConsoleWindowLength, ConsoleWindowHeight);
            random = new Random();

            for (int i = 0; i < LogWindowLength -LogWindowTextOffsetX - WindowBorderthick; i++)
                logWindowClearLine += " ";

            for (int i = 0; i < (PlayerWindowLength - PlayerWindowTextOffsetX - WindowBorderthick * 2); i++)
                playerWindowClearLine += " ";

            for (int i = 0; i < EnemyWindowLength - LogWindowTextOffsetX - WindowBorderthick * 2; i++)
                enemyWindowClearLine += " ";

            for (int i = 0; i < enemyImageClearLineLength; i++)
                enemyImageClearLine += " ";

            for (int i = 0; i < FinalWindowLength - WindowBorderthick * 2; i++)
                finalWindowClearLine += " ";

            while (isBattleActive)
            {
                if (playerSpellPatronusTimeToCanCast > 0)
                    playerSpellPatronusTimeToCanCast--;

                if (playerSpellImperioTimeToCanCast > 0)
                    playerSpellImperioTimeToCanCast--;

                if (playerSpellKonfundusCastReserv > 0)
                {                    
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= playerSpellKonfundusAdventChance);
                    if (haveAdventSpell)
                    {
                        playerSpellKonfundusAmmount++;
                        playerSpellKonfundusCastReserv--;
                    }                        
                }

                if (playerSpellAvadaKedavraCastReserv > 0)
                {
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= playerSpellAvadaKedavraAdventChance);
                    if (haveAdventSpell)
                    {
                        playerSpellAvadaKedavraAmmount++;
                        playerSpellAvadaKedavraCastReserv--;
                    }
                }

                if (playerSpellExpiliarmusCastReserv > 0)
                {
                    int adventChance = random.Next(0, persentageCoefficient);
                    bool haveAdventSpell = (adventChance <= playerSpellExpiliarmusAdventChance);

                    if (haveAdventSpell)
                    {
                        playerSpellExpiliarmusAmmount++;
                        playerSpellExpiliarmusCastReserv--;
                    }
                }

                if (enemySpellInflarmeTimeToCanCast > 0)
                    enemySpellInflarmeTimeToCanCast--;
                
                if (enemyVasilisklAliveRounds > 0)
                    enemyVasilisklAliveRounds--;

                if (enemySpellEngorgioTimeToCanCast > 0)
                    enemySpellEngorgioTimeToCanCast--;

                if (enemySpellSektrumSempraTimeToCanCast > 0)
                    enemySpellSektrumSempraTimeToCanCast--;

                if (enemySpellAvadaKedavraTimeToCanCast > 0)
                    enemySpellAvadaKedavraTimeToCanCast--;

                if (canEnemyCastSpells)
                {
                    if (enemySpellEngorgioCastReserv > 0 && enemySpellEngorgioTimeToCanCast <= 0)
                    {
                        int adventChance = random.Next(0, persentageCoefficient);
                        bool haveAdventSpell = (adventChance <= enemySpellEngorgioAdventChance);

                        if (haveAdventSpell)
                        {
                            enemySpellEngorgioAmmount++;
                            enemySpellEngorgioCastReserv--;
                        }
                    }

                    if (enemySpellSektrumSempraCastReserv > 0 && enemySpellSektrumSempraTimeToCanCast <= 0)
                    {
                        int adventChance = random.Next(0, persentageCoefficient);
                        bool haveAdventSpell = (adventChance <= enemySpellSektrumSempraAdventChance);

                        if (haveAdventSpell)
                        {
                            enemySpellSektrumSempraAmmount++;
                            enemySpellSektrumSempraCastReserv--;
                        }
                    }

                    if (enemySpellAvadaKedavraCastReserv > 0 && enemySpellAvadaKedavraTimeToCanCast <= 0)
                    {
                        int adventChance = random.Next(0, persentageCoefficient);
                        bool haveAdventSpell = (adventChance <= enemySpellAvadaKedavraAdventChance);

                        if (haveAdventSpell)
                        {
                            enemySpellAvadaKedavraAmmount++;
                            enemySpellAvadaKedavraCastReserv--;
                        }
                    }
                } 
                else
                {
                    canEnemyCastSpells = true;
                }

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

                Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY);

                if (enemyHealth <= enemyCriticalHealth)
                    currentEnemyImageColor = EnemyAlmostDieColor;
                else if (enemyHealth <= enemyWeaknessHealth)
                    currentEnemyImageColor = EnemyWeaknessColor;
                else
                    currentEnemyImageColor = DefaultEnemyImageColor;

                Console.ForegroundColor = currentEnemyImageColor;
                enemyImageCursorPositionY = 0;

                foreach (string line in enemyBossImage)
                {
                    Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY + enemyImageCursorPositionY);
                    Console.WriteLine(line);
                    enemyImageCursorPositionY++;
                }

                if (isVasiliskActive)
                {
                    Console.ForegroundColor = EnemyVasiliskColor;
                    enemyImageCursorPositionY = 0;
                    foreach (string line in enemyVasiliskImage)
                    {
                        Console.SetCursorPosition(VasiliskImagePositionX, VasiliskImagePositionY + enemyImageCursorPositionY);
                        Console.WriteLine(line);
                        enemyImageCursorPositionY++;
                    }
                }

                Console.ForegroundColor = DefaultTextColor;

                Console.ForegroundColor = WindowBorderColor;
                Console.SetCursorPosition(LogWindowX, LogWindowY);

                Console.Write(WindowBorderSymbolHorizontal);
                Console.Write(LogWindowName);

                for (int i = 1; i < LogWindowLength - LogWindowName.Length; i++)
                    Console.Write(WindowBorderSymbolHorizontal);
                                    
                for (int i = 1; i < LogWindowHeight - LogWindowTitleOffsetY; i++)
                {
                    Console.SetCursorPosition(LogWindowX, LogWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(LogWindowX + LogWindowLength - WindowBorderthick, LogWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }

                Console.SetCursorPosition(LogWindowX, LogWindowY + LogWindowHeight - WindowBorderthick);

                for (int i = 0; i < LogWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);
          
                logWindowCursorPositionY = LogWindowTitleOffsetY;
                Console.ForegroundColor = DefaultTextColor;

                for(int i=0; i<LogWindowHeight-WindowBorderthick*2; i++)
                {
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(logWindowClearLine);
                    logWindowCursorPositionY++;
                }

                logWindowCursorPositionY = LogWindowTitleOffsetY;

                if (isIntro)
                {
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

                    foreach (string textLine in playerLogsOutput)
                    {
                        Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                        Console.Write(textLine);
                        logWindowCursorPositionY++;
                        System.Threading.Thread.Sleep(LogsLineAppearenseDelay);
                    }

                    logWindowCursorPositionY++;

                    Console.ForegroundColor = currentEnemyImageColor;
                    foreach (int[] animationFrames in enemyAttackAnimationFrames)
                    {
                        System.Threading.Thread.Sleep(EnemyAnimationFramesDelay);
       
                        for(int line = 0; line<animationFrames.Length; line++)
                        {
                            Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY + line);
                            for (int i = 0; i < animationFrames[line]; i++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(enemyBossImage[line]);                                
                        }
                    }

                    if (canShowEnemyCastAnimation) 
                    { 
                        Console.ForegroundColor = EnemyImageCastSpellColor;

                        foreach (string[] armImageFrame in enemyArmAnimation)
                        {
                            for (int lineNumber=0; lineNumber < armImageFrame.Length; lineNumber++)
                            {
                                Console.SetCursorPosition(enemyImageArmPositionX, enemyImageArmPositionY+ lineNumber);
                                Console.WriteLine(armImageFrame[lineNumber]);                            
                            }
                            System.Threading.Thread.Sleep(EnemyAnimationFramesDelay);
                        }

                        for (int frameNumber = enemyArmAnimation.Length - 1; frameNumber >= 0; frameNumber--)
                        {
                            for (int lineNumber = 0; lineNumber < enemyArmAnimation[frameNumber].Length; lineNumber++)
                            {
                                Console.SetCursorPosition(enemyImageArmPositionX, enemyImageArmPositionY + lineNumber);
                                Console.WriteLine(enemyArmAnimation[frameNumber][lineNumber]);
                            }
                            System.Threading.Thread.Sleep(EnemyAnimationFramesDelay);
                        }
                    }
                    else
                    {
                        canShowEnemyCastAnimation = true;
                    }

                    Console.ForegroundColor = currentEnemyImageColor;

                    for(int frameNumber = enemyAttackAnimationFrames.Length - 1; frameNumber>=0; frameNumber--)  
                    {
                        System.Threading.Thread.Sleep(EnemyAnimationFramesDelay);

                        for (int numberOfAnimationLine = 0; numberOfAnimationLine < enemyAttackAnimationFrames[frameNumber].Length; numberOfAnimationLine++)
                        {
                            Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY + numberOfAnimationLine);
                            for (int i = 0; i < enemyAttackAnimationFrames[frameNumber][numberOfAnimationLine] -1; i++)
                            {
                                Console.Write(" ");
                            }
                            Console.Write(enemyBossImage[numberOfAnimationLine]);
                        }
                    }

                    Console.ForegroundColor = DefaultTextColor;
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
                    Console.ForegroundColor = LogWindowEnemyFooterColor;
                    Console.Write(enemyLogWindowFooterText);                    
                }

                Console.ForegroundColor = WindowBorderColor;
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

                enemyWindowCursorPositionY = EnemyWindowTitleOffsetY;

                for (int i = 0; i < EnemyWindowHeight - WindowBorderthick * 2; i++)
                {
                    Console.SetCursorPosition(EnemyWindowX + LogWindowTextOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                    Console.Write(enemyWindowClearLine);
                    enemyWindowCursorPositionY++;
                }

                Console.ForegroundColor = WindowTitleColor;
                enemyWindowCursorPositionY = EnemyWindowTitleOffsetY;
                Console.SetCursorPosition(EnemyWindowX + EnemyWindowTitleOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                Console.Write($" {EnemyBossName} | Здоровье: {enemyHealth}");
                enemyWindowCursorPositionY++;
                Console.SetCursorPosition(EnemyWindowX + EnemyWindowTitleOffsetX, EnemyWindowY + enemyWindowCursorPositionY);
                
                for (int i = WindowBorderthick; i < EnemyWindowLength - WindowBorderthick; i++)
                    Console.Write(WindowHeaderLine);

                Console.ForegroundColor = DefaultTextColor;

                if (enemyWindowMessage1 != "")
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

                Console.ForegroundColor = WindowBorderColor;
                Console.SetCursorPosition(PlayerWindowX, PlayerWindowY);

                for (int i = 0; i < PlayerWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                for (int i = 1; i < PlayerWindowHeight - PlayerWindowTitleOffsetY; i++)
                {
                    Console.SetCursorPosition(PlayerWindowX, PlayerWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowLength - WindowBorderthick, PlayerWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }

                Console.SetCursorPosition(PlayerWindowX, PlayerWindowY + PlayerWindowHeight - WindowBorderthick);

                for (int i = 0; i < PlayerWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                playerWindowCursorPositionY = PlayerWindowTitleOffsetY;

                for (int i = 0; i < PlayerWindowHeight - WindowBorderthick * 2; i++)
                {
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write(playerWindowClearLine);
                    playerWindowCursorPositionY++;
                }

                Console.ForegroundColor = WindowTitleColor;
                playerWindowCursorPositionY = PlayerWindowTitleOffsetY;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($" {PlayerName} | ");

                if (playerHealth < playerCriricalHealth)
                    Console.ForegroundColor = PlayerCriricalHealthColor; 
                else
                    Console.ForegroundColor = PlayerHealthColor;

                Console.Write($"Здоровье: {playerHealth}");
                Console.ForegroundColor = WindowTitleColor;
                Console.Write($" | ");

                if(playerShield > 0)
                    Console.ForegroundColor = ShieldTextColor;

                Console.Write($"Щит: {playerShield}");
                Console.ForegroundColor = WindowTitleColor;
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                
                for (int i = WindowBorderthick; i < PlayerWindowLength - WindowBorderthick; i++)
                    Console.Write(WindowHeaderLine);

                Console.ForegroundColor = DefaultTextColor;

                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellPatronusCommand}. {playerSpellPatronusName} - {playerSpellPatronusLog} " +
                             $"Перезарядка {playerSpellPatronusTimeToCanCast}.");

                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellImperioCommand}. {playerSpellImperioName} - {playerSpellImperioLog} " +
                              $"Перезарядка {playerSpellImperioTimeToCanCast}.");

                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellAvahtoCommand}. {playerSpellAvahtoName} - {playerSpellAvahtoLog} " +
                              $"Кол-во {playerSpellAvahtoAmmount}.");

                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{PlayerSpellImmobilusCommand}. {playerSpellImmobilusName} - {playerSpellImmobilusTitle} " +
                              $"Кол-во {playerSpellImmobilusAmmount}.");
                Console.ForegroundColor = HigthLihtSpellTextColor;

                if (playerSpellKonfundusAmmount > 0)
                {

                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellKonfundusCommand}. {playerSpellKonfundusName} - {playerSpellKonfundusTitle} " +
                                  $"Кол-во {playerSpellKonfundusAmmount}.");
                }

                if (playerSpellAvadaKedavraAmmount > 0)
                {
                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellAvadaKedavraCommand}. {playerSpellAvadaKedavraName} - {playerSpellAvadaKedavraTitle} " +
                                  $"Кол-во {playerSpellAvadaKedavraAmmount}.");
                }

                if (playerSpellExpiliarmusAmmount > 0)
                {
                    playerWindowCursorPositionY++;
                    Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                    Console.Write($"{PlayerSpellExpiliarmusCommand}. {playerSpellExpiliarmusName} - {playerSpellExpiliarmusTitle} " +
                                  $"Кол-во {playerSpellExpiliarmusAmmount}.");
                }

                Console.ForegroundColor = DefaultTextColor;
                playerWindowCursorPositionY++;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($"{ExitCommand}. {ExitCommandTitle}");

                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + PlayerWindowHeight - WindowBorderthick*2);
                Console.Write(PlayerInputCommandPrompt);
                inputCommand = Console.ReadLine();

                switch (inputCommand)
                {
                    case PlayerSpellPatronusCommand:
                        if (playerSpellPatronusTimeToCanCast > 0)
                        {
                            playerLogsOutput = playerSpellPatronusWrongCast;
                        }
                        else
                        {
                            playerSpellPatronusTimeToCanCast = playerSpellPatronusRechargeTime;
                            playerLogsOutput = playerSpellPatronusText;
                            enemyHealth -= playerSpellPatronusPower;
                            enemyWindowMessageCaсhe = $"{playerSpellPatronusName} -{playerSpellPatronusPower}. Осталось {enemyHealth}";
                        }                            
                        break;

                    case PlayerSpellImperioCommand:
                        if (playerSpellImperioTimeToCanCast > 0)
                        {
                            playerLogsOutput = playerSpellImperioWrongCast;
                        }
                        else
                        {
                            playerSpellImperioTimeToCanCast = playerSpellImperioRechargeTime;
                            playerLogsOutput = playerSpellImperioText;
                            enemyHealth -= playerSpellImperioPower;
                            enemyWindowMessageCaсhe = $"{playerSpellImperioName} -{playerSpellImperioPower}. Осталось {enemyHealth}";
                        }
                        break;

                    case PlayerSpellAvahtoCommand:
                        if (playerSpellAvahtoAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellAvahtoWrongCast;
                            break;
                        }

                        if (wasLastEnemvySpellAvahto)
                        {
                            playerSpellAvahtoAmmount = playerSpellAvahtoAmmountMaximum;
                            playerHealthMaximum += playerHealthLevelIncrease;
                            playerHealth = playerHealthMaximum;
                            playerLogsOutput = playerSpellAvahtoSpecialText;
                            enemyWindowMessageCaсhe = $"{playerSpellAvahtoName}. Игрок прокачался.";
                        }
                        else
                        {
                            playerSpellAvahtoAmmount--;
                            playerLogsOutput = playerSpellAvahtoText;
                            enemyWindowMessageCaсhe = $"{playerSpellAvahtoName}. Игрок вылечился.";
                        }

                        playerHealth = playerHealthMaximum;
                        
                        break;

                    case PlayerSpellImmobilusCommand:
                        if (playerSpellImmobilusAmmount <= 0)
                        {
                            playerLogsOutput = PlayerSpellImmobilusWrongCast;
                            enemyVasilisklAliveRounds = 0;
                            break;
                        }
                        playerShield = playerShieldMaximum;
                        playerSpellImmobilusAmmount--;

                        if (isVasiliskActive)
                        {
                            isVasiliskActive = false;
                            playerLogsOutput = playerSpellImmobilusSpecialText;
                        }
                        else
                        {
                            playerLogsOutput = playerSpellImmobilusText;
                        }                        

                        enemyWindowMessageCaсhe = $"{playerSpellImmobilusName}. Игрок поставил щит.";
                        break;

                    case PlayerSpellKonfundusCommand:
                        if (playerSpellKonfundusAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellKonfundusWrongCast;
                            break;
                        }
                        playerSpellKonfundusAmmount--;
                        enemyCantCastSpellsRounds += playerSpellKonfundusEffectTime;
                        playerLogsOutput = playerSpellKonfundusText;
                        enemyWindowMessageCaсhe = $"{playerSpellKonfundusName} - Игрок сбил заклятья.";
                        break;

                    case PlayerSpellAvadaKedavraCommand:
                        if (playerSpellAvadaKedavraAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellAvadaKedavraWrongCast;
                            break;
                        }
                        playerSpellAvadaKedavraAmmount--;

                        int power = playerSpellAvadaKedavraPower;

                        if (wasLastEnemySpellAvadaKedavra)
                        {
                            power += playerSpellAvadaKedavraEnhancementPower;
                            playerLogsOutput = playerSpellAvadaKedavraSpecialCast;
                        }
                        else
                        {
                            playerLogsOutput = playerSpellAvadaKedavraText;
                        }

                        enemyHealth -= power;
                        enemyWindowMessageCaсhe = $"{playerSpellAvadaKedavraName} -{power}. Осталось {enemyHealth}";
                        break;

                    case PlayerSpellExpiliarmusCommand:
                        if (playerSpellExpiliarmusAmmount <= 0)
                        {
                            playerLogsOutput = playerSpellExpiliarmusWrongCast;
                            break;
                        }
                        playerSpellExpiliarmusAmmount--;
                        enemyCantCastSpellsRounds += playerSpellExpiliarmusEffectTime;
                        playerLogsOutput = playerSpellExpiliarmusText;
                        enemyHealth -= playerSpellExpiliarmusPower;
                        enemyWindowMessageCaсhe = $"{playerSpellExpiliarmusName} -{playerSpellExpiliarmusPower}. Осталось {enemyHealth}";
                        break;

                    case ExitCommand:
                        isBattleActive = false;
                        break;

                    default:
                        playerLogsOutput = playerLooseMove;
                        enemyWindowMessageCaсhe = PlayerLooseMoveTitle;
                        break;
                }

                playerWindowCursorPositionY = PlayerWindowTitleOffsetY;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($" {PlayerName} | ");

                if (playerHealth < playerCriricalHealth)
                    Console.ForegroundColor = PlayerCriricalHealthColor;
                else
                    Console.ForegroundColor = PlayerHealthColor;

                Console.Write($"Здоровье: {playerHealth}");
                Console.ForegroundColor = DefaultTextColor;
                Console.Write($" | ");

                if (playerShield > 0)
                    Console.ForegroundColor = ShieldTextColor;

                Console.Write($"Щит: {playerShield}     ");
                Console.ForegroundColor = DefaultTextColor;

                if (wasLastEnemvySpellAvahto)
                    wasLastEnemvySpellAvahto = false;

                if (wasLastEnemySpellAvadaKedavra)
                    wasLastEnemySpellAvadaKedavra = false;

                if (enemyCantCastSpellsRounds > 0)
                {
                    enemyDealDamageToPlayer = enemyPunchPower;
                    enemyLogsOutput = enemyPunchText;
                    enemyCantCastSpellsRounds--;
                    canEnemyCastSpells = false;
                    canShowEnemyCastAnimation = false;
                }
                else if (enemyHealth < enemyCriticalHealth && enemySpellAvahtoAmmount > 0 && enemyHealth > 0)
                {
                    enemySpellAvahtoAmmount--;
                    enemyLogsOutput = enemySpellAvahtoText;
                    enemyHealth = enemyHealthMaximum;
                    wasLastEnemvySpellAvahto = true;
                    enemyWindowMessageCaсhe = $"{EnemyHealTitleMessage}";
                }
                else if (enemySpellAvadaKedavraTimeToCanCast <= 0 && enemySpellAvadaKedavraAmmount > 0) 
                {
                    wasLastEnemySpellAvadaKedavra = true;
                    enemyDealDamageToPlayer = enemySpellAvadaKedavraPower;
                    enemyLogsOutput = EnemySpellAvadaKedavraText;
                    enemySpellAvadaKedavraTimeToCanCast = enemySpellAvadaKedavraRechargeTime;
                }
                else if (enemySpellSektrumSempraTimeToCanCast <= 0 && enemySpellSektrumSempraAmmount > 0)
                {
                    enemyDealDamageToPlayer = enemySpellSektrumSempraPower;
                    enemyLogsOutput = enemySpellSektrumSempraText;
                    enemySpellSektrumSempraTimeToCanCast = enemySpellSektrumSempraRechargeTime;
                }
                else if (enemySpellEngorgioTimeToCanCast <= 0 && enemySpellEngorgioAmmount > 0)
                {
                    isVasiliskActive = true;
                    enemySpellEngorgioAmmount--;
                    enemySpellEngorgioTimeToCanCast = enemySpellEngorgioRechargeTime;
                    enemyVasilisklAliveRounds = enemyVasilisklAliveRoundsMaximum;
                    enemyLogsOutput = enemySpellEngorgioText;
                }
                else if (enemySpellInflarmeTimeToCanCast <= 0)
                {
                    enemyDealDamageToPlayer = enemySpellInflarmePower;
                    enemyLogsOutput = enemySpellInflarmeText;
                    enemySpellInflarmeTimeToCanCast = enemySpellInflarmeRechargeTime;
                }
                else
                {               
                    enemyDealDamageToPlayer = enemyPunchPower;
                    enemyLogsOutput = enemyPunchText;
                    canShowEnemyCastAnimation = false;
                }

                enemyLogWindowFooterText = "";

                if (isVasiliskActive && enemyVasilisklAliveRounds==0)
                {
                    isVasiliskActive = false;
                }

                if (isVasiliskActive && enemyVasilisklAliveRounds>0)
                {
                    enemyDealDamageToPlayer += enemySpellEngorgioPower;
                }

                if (enemyDealDamageToPlayer > 0)
                {
                    if(playerShield>0 && playerShield >= enemyDealDamageToPlayer)
                    {
                        playerShield -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText = $"{DamageToPlayerShieldMessage} {enemyDealDamageToPlayer} "; 
                    }   
                    else if(playerShield > 0 && playerShield < enemyDealDamageToPlayer)
                    {
                        enemyDealDamageToPlayer -= playerShield;
                        enemyLogWindowFooterText = $"{DamageToPlayerShieldMessage} {playerShield} ";
                        playerShield = 0;
                        playerHealth -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText += $"{DamageToPlayerHealthMessage} {enemyDealDamageToPlayer} "; 
                    }
                    else
                    {
                        playerHealth -= enemyDealDamageToPlayer;
                        enemyLogWindowFooterText += $"{DamageToPlayerHealthMessage} {enemyDealDamageToPlayer} ";
                    }
                    enemyDealDamageToPlayer = 0;

                    if (enemyCantCastSpellsRounds > 0)
                    {
                        enemyLogWindowFooterText += $"{EnemyCantCastRoundsMessage} {enemyCantCastSpellsRounds}";
                    }

                    if (isVasiliskActive)
                    {
                        enemyLogWindowFooterText += $"{VasiliskDamgeMessage} {enemySpellEngorgioPower}";
                    }
                }

                playerWindowCursorPositionY = PlayerWindowTitleOffsetY;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTitleOffsetX, PlayerWindowY + playerWindowCursorPositionY);
                Console.Write($" {PlayerName} | ");

                if (playerHealth < playerCriricalHealth)
                    Console.ForegroundColor = PlayerCriricalHealthColor;
                else
                    Console.ForegroundColor = PlayerHealthColor;

                Console.Write($"Здоровье: {playerHealth}");
                Console.ForegroundColor = DefaultTextColor;
                Console.Write($" | ");

                if (playerShield > 0)
                    Console.ForegroundColor = ShieldTextColor;

                Console.Write($"Щит: {playerShield}     ");
                Console.ForegroundColor = DefaultTextColor;

                if (playerHealth <= 0)
                {
                    isBattleActive = false;
                    isPlayerDead = true;
                }

                if (enemyHealth <= 0)
                {
                    isBattleActive = false;
                    isEnemyDie = true;
                }
            }

            if (isEnemyDie)
            {
                Console.ForegroundColor = currentEnemyImageColor;

                foreach (int[] animationFrames in enemyDieAnimationFrames)
                {
                    System.Threading.Thread.Sleep(LogsLineAppearenseDelay);

                    for (enemyImageCursorPositionY = 0; enemyImageCursorPositionY < enemyBossImage.Length - animationFrames.Length; enemyImageCursorPositionY++)
                    {
                        Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY + enemyImageCursorPositionY);
                        Console.WriteLine(enemyImageClearLine);
                    }

                    foreach (int index in animationFrames)
                    {
                        enemyImageCursorPositionY++;
                        Console.SetCursorPosition(EnemyImagePositionX, EnemyImagePositionY + enemyImageCursorPositionY);
                        Console.WriteLine(enemyBossImage[index]);
                    }
                }
                Console.ForegroundColor = DefaultTextColor;
            }

            if (enemyHealth <= 0 && playerHealth <= 0)
            {
                finalOutputText = bothDeadFinalText;
                finalOutputImage = playerDeadImage;
            }
            else if (playerHealth <= 0)
            {
                finalOutputText = bossWinFinalText;
                finalOutputImage = playerDeadImage;
            }
            else 
            {
                finalOutputText = playerWinFinalText;
                finalOutputImage = playerWinImage;
            }

            if(isPlayerDead || isEnemyDie)
            {
                logWindowCursorPositionY = LogWindowTitleOffsetY;
                Console.ForegroundColor = DefaultTextColor;

                for (int i = 0; i < LogWindowHeight - WindowBorderthick * 2; i++)
                {
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(logWindowClearLine);
                    logWindowCursorPositionY++;
                }

                logWindowCursorPositionY = LogWindowTitleOffsetY;
                Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                Console.Write(LogPlayerMoveTitle);
                logWindowCursorPositionY++;

                foreach (string textLine in playerLogsOutput)
                {
                    Console.SetCursorPosition(LogWindowX + LogWindowTextOffsetX, LogWindowY + logWindowCursorPositionY);
                    Console.Write(textLine);
                    logWindowCursorPositionY++;
                    System.Threading.Thread.Sleep(LogsLineAppearenseDelay);
                }
                logWindowCursorPositionY++;

                Console.ForegroundColor = DefaultTextColor;

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
                Console.ForegroundColor = LogWindowEnemyFooterColor;
                Console.Write(enemyLogWindowFooterText);

                Console.ForegroundColor = HigthLihtSpellTextColor;
                Console.SetCursorPosition(PlayerWindowX + PlayerWindowTextOffsetX, PlayerWindowY + PlayerWindowHeight - WindowBorderthick * 2);
                Console.Write(PressKeyPrompt);
                Console.ReadKey();

                Console.ForegroundColor = WindowBorderColor;
                Console.SetCursorPosition(FinalWindowX, FinalWindowY);

                for (int i = 0; i < FinalWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                for (int i = 1; i < FinalWindowHeight - WindowBorderthick; i++)
                {
                    Console.SetCursorPosition(FinalWindowX, FinalWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                    Console.SetCursorPosition(FinalWindowX + FinalWindowLength - WindowBorderthick, FinalWindowY + i);
                    Console.Write(WindowBorderSymbolVertical);
                }

                Console.SetCursorPosition(FinalWindowX, FinalWindowY + FinalWindowHeight - WindowBorderthick);

                for (int i = 0; i < FinalWindowLength; i++)
                    Console.Write(WindowBorderSymbolHorizontal);

                Console.ForegroundColor = DefaultTextColor;

                for (int i = 1; i < FinalWindowHeight - WindowBorderthick; i++)
                {
                    Console.SetCursorPosition(FinalWindowX + WindowBorderthick, FinalWindowY + i);
                    Console.Write(finalWindowClearLine);
                }

                finalWindowCursorPositionY = FinalWindowImageOffsetY;
                Console.ForegroundColor = FinalImageColor;

                foreach (string textLine in finalOutputImage)
                {
                    Console.SetCursorPosition(FinalWindowX + FinalWindowImageOffsetX, FinalWindowY + finalWindowCursorPositionY);
                    Console.Write(textLine);
                    finalWindowCursorPositionY++;
                }

                finalWindowCursorPositionY = FinalWindowTextOffsetY;
                Console.ForegroundColor = DefaultTextColor;

                finalWindowCursorPositionY = FinalWindowTextOffsetY;
                Console.ForegroundColor = DefaultTextColor;

                foreach (string textLine in finalOutputText)
                {
                    Console.SetCursorPosition(FinalWindowX + FinalWindowTextOffsetX, FinalWindowY + finalWindowCursorPositionY);
                    Console.Write(textLine);
                    finalWindowCursorPositionY++;
                }

                Console.ReadKey();
            }            
        }
    }
}
