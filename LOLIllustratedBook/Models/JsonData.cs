namespace LOLIllustratedBook.Models
{
    public class JsonData
    {
        public class ChampionData
        {
            public string Type { get; set; } = string.Empty;
            public string Format { get; set; } = string.Empty;
            public string Version { get; set; } = string.Empty;
            public Dictionary<string, Champion> Data { get; set; } = [];
            public List<Champion> ChampionList { get; set; } = [];
        }
        public class Champion
        {
            public string Id { get; set; } = string.Empty;
            public string Key { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public Image Image { get; set; } = new();
            public List<Skin> Skins { get; set; } = [];
            public string Lore { get; set; } = string.Empty;
            public string Blurb { get; set; } = string.Empty;
            public List<string> Allytips { get; set; } = [];
            public List<string> Enemytips { get; set; } = [];
            public List<string> Tags { get; set; } = [];
            public string Partype { get; set; } = string.Empty;
            public Info Info { get; set; } = new();
            public Stats Stats { get; set; } = new();
            public List<Spell> Spells { get; set; } = [];
            public Passive Passive { get; set; } = new();
            public List<Recommended> Recommended { get; set; } = [];
            public string ImageURL => $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{Id}_0.jpg";
            public string LoadingImage => $"https://ddragon.leagueoflegends.com/cdn/img/champion/loading/{Id}_0.jpg";
        }
        public class Image
        {
            public string? Full { get; set; }
            public string? Sprite { get; set; }
            public string? Group { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int W { get; set; }
            public int H { get; set; }
        }
        public class Skin
        {
            public string Id { get; set; } = string.Empty;
            public int Num { get; set; }
            public string Name { get; set; } = string.Empty;
            public bool Chromas { get; set; }
        }
        public class Info
        {
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Magic { get; set; }
            public int Difficulty { get; set; }
        }
        public class Stats
        {
            public double Hp { get; set; }
            public double Hpperlevel { get; set; }
            public double Mp { get; set; }
            public double Mpperlevel { get; set; }
            public double Movespeed { get; set; }
            public double Armor { get; set; }
            public double Armorperlevel { get; set; }
            public double Spellblock { get; set; }
            public double Spellblockperlevel { get; set; }
            public double Attackrange { get; set; }
            public double Hpregen { get; set; }
            public double Hpregenperlevel { get; set; }
            public double Mpregen { get; set; }
            public double Mpregenperlevel { get; set; }
            public double Crit { get; set; }
            public double Critperlevel { get; set; }
            public double Attackdamage { get; set; }
            public double Attackdamageperlevel { get; set; }
            public double Attackspeedperlevel { get; set; }
            public double Attackspeed { get; set; }
        }
        public class Spell
        {
            public string Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Tooltip { get; set; } = string.Empty;
            public Leveltip Leveltip { get; set; } = new();
            public int Maxrank { get; set; }
            public List<double> Cooldown { get; set; } = [];
            public string CooldownBurn { get; set; } = string.Empty;
            public List<double> Cost { get; set; } = [];
            public string CostBurn { get; set; } = string.Empty;
            public Datavalues Datavalues { get; set; } = new();
            public List<List<double>> Effect { get; set; } = [];
            public List<string> EffectBurn { get; set; } = [];
            public List<Var> Vars { get; set; } = [];
            public string CostType { get; set; } = string.Empty;
            public int Maxammo { get; set; }
            public List<double> Range { get; set; } = [];
            public string RangeBurn { get; set; } = string.Empty;
            public Image Image { get; set; } = new();
            public string Resource { get; set; } = string.Empty;
            public string SkillImageURL => $"{Id}.png";
        }
        public class Leveltip
        {
            public List<string> Label { get; set; } = [];
            public List<string> Effect { get; set; } = [];
        }
        public class Datavalues
        {
        }
        public class Var
        {
        }
        public class Passive
        {
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public Image Image { get; set; } = new();
        }
        public class Recommended
        {
            public string Champion { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Map { get; set; } = string.Empty;
            public string Mode { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public string CustomTag { get; set; } = string.Empty;
            public int Sortrank { get; set; }
            public bool ExtensionPage { get; set; }
            public bool UseObviousCheckmark { get; set; }
            public object CustomPanel { get; set; } = new();
            public List<Block> Blocks { get; set; } = [];
        }
        public class Block
        {
            public string Type { get; set; } = string.Empty;
            public bool RecMath { get; set; }
            public bool RecSteps { get; set; }
            public int MinSummonerLevel { get; set; }
            public int MaxSummonerLevel { get; set; }
            public string ShowIfSummonerSpell { get; set; } = string.Empty;
            public string HideIfSummonerSpell { get; set; } = string.Empty;
            public string AppendAfterSection { get; set; } = string.Empty;
            public List<string> VisibleWithAllOf { get; set; } = [];
            public List<string> HiddenWithAnyOf { get; set; } = [];
            public List<Item> Items { get; set; } = [];
        }
        public class Item
        {
            public string Id { get; set; } = string.Empty;
            public int Count { get; set; }
            public bool HideCount { get; set; }
        }
    }
}
