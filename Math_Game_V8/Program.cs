using Math_Game_V8;

Menu menu = new();

DateTime date = DateTime.UtcNow;

string name = Helpers.GetName();

menu.ShowMenu(name, date);