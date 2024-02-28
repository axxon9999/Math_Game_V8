using Math_Game_V8;

Menu menu = new Menu();

DateTime date = DateTime.UtcNow;

List<string> games = new List<string>();

// Call A1
string name = Helpers.GetName();

// Call A2
menu.ShowMenu(name, date);