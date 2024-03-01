using Math_Game_V8;

Menu menu = new Menu();

DateTime date = DateTime.UtcNow;

List<string> games = new List<string>();

string name = Helpers.GetName();

menu.ShowMenu(name, date);