// See https://aka.ms/new-console-template for more information

// Expansion: Items

using Terminal.Gui;

Application.Init();

try
{
    Ui.CreateLogWindow();
    
    Application.MainLoop.Invoke(() =>
    {
        string playerName = AskName();

        Party heroes = new Party("Heroes");
        heroes.Add(new Character(playerName, new PunchAttack(), 25));
        heroes.Add(new Character("VIN FLETCHER", new QuickShotAttack(), 15));
        heroes.AddHealthPotions(3);
        
        Party monstersWave1 = new Party("Monsters (Wave 1)");
        monstersWave1.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));
        monstersWave1.AddHealthPotions(1);
        
        Party monstersWave2 = new Party("Monsters (Wave 2)");
        monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));
        monstersWave2.Add(new Character("SKELETON", new BoneCrunchAttack(), 5));
        monstersWave2.AddHealthPotions(1);
        
        Party monstersWave3 = new Party("The Uncoded One");
        monstersWave3.Add(new Character("THE UNCODED ONE", new UnravelingAttack(), 15));
        monstersWave2.AddHealthPotions(1);
        
        int mode = AskMode();
    
        IPlayer heroesPlayer = (mode == 1 || mode == 3) ? new TuiHumanPlayer() : new ComputerPlayer();
        IPlayer monstersPlayer = (mode == 2) ? new ComputerPlayer() : new TuiHumanPlayer();
    
        List<Party> waves = new List<Party> { monstersWave1, monstersWave2, monstersWave3 };
    
        Ui.Log("The Battle Series begins!");
        Ui.Log();

        for (int i = 0; i < waves.Count; i++)
        {
            Party currentMonsters = waves[i];
            Ui.Log($"--- Battle {i + 1}: Heroes vs {currentMonsters.Name} ---");
            Ui.Log();
    
            Battle battle = new Battle(heroes,  currentMonsters, heroesPlayer, monstersPlayer);
            BattleOutcome outcome = battle.Run();

            if (outcome == BattleOutcome.MonstersWin)
            {
                Ui.Log();
                Ui.Log("Series over: The monsters have stopped the heroes.");
                break;
            }

            if (i < waves.Count - 1)
            {
                Ui.Log();
                Ui.Log("Heroes advance to the next battle!");
                Ui.Log();
            }
            else
            {
                Ui.Log();
                Ui.Log("All battles won! The Uncoded One is defeated.");
            }
        }
    });

    Application.Run();
}

finally
{
    Application.Shutdown();
}
static string AskName()
{
    string result = "TOG";

    Dialog dlg = new Dialog("True Programmer", 40, 7);
    Label label = new Label(1, 1, "Enter name:");
    TextField input = new TextField("TOG")
    {
        X = 1,
        Y = Pos.Bottom(label) + 1,
        Width = Dim.Fill() - 2
    };

    var ok = new Button("OK");
    ok.IsDefault = true;
    ok.Clicked += () =>
    {
        string text = input.Text.ToString() ?? "";
        result = string.IsNullOrEmpty(text) ? "TOG" : text.Trim().ToUpperInvariant();
        Application.RequestStop();
    };

    dlg.Add(label, input);
    dlg.AddButton(ok);

    Application.Run(dlg);
    return  result;
}

static int AskMode()
{
    int idx = MessageBox.Query(
        "Game Mode",
        "Choose game mode:",
        "1 - Player vs Computer",
        "2 - Computer vs Computer",
        "3 - Human vs Human"
    );
    return idx + 1;
}