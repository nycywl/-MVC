using System.ComponentModel.DataAnnotations.Schema;

namespace LOLIllustratedBook.Models
{
    public class DTO
    {
        public class ChampionData
        {
            public Champion DTO_Champion { get; set; } = new();
            public Info DTO_Info { get; set; } = new();
            public States DTO_States { get; set; } = new();
            public List<Spell> DTO_Spells  { get; set; } = [];
            public string ImageURL => $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{DTO_Champion.Id}_0.jpg";
            public string LoadingImage => $"https://ddragon.leagueoflegends.com/cdn/img/champion/loading/{DTO_Champion.Id}_0.jpg";
        }
        public class DTOChampion
        {
            public string Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string Blurb { get; set; } = string.Empty;
            public string Tags { get; set; } = string.Empty;
            public string Partype { get; set; } = string.Empty;
            public int Attack { get; set; }
            public int Defense { get; set; }
            public int Magic { get; set; }
            public int Difficulty { get; set; }
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
            public string ImageURL { get; set; } = string.Empty;
        }
    }
}
