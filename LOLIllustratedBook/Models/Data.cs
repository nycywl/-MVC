using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOLIllustratedBook.Models
{
    public class Champion
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public string KeyName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Lore { get; set; } = string.Empty;
        public string Blurb { get; set; } = string.Empty;
        public string Allytips { get; set; } = string.Empty;
        public string Enemytips { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public string Partype { get; set; } = string.Empty;

        [NotMapped]
        public string ImageURL => $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{Id}_0.jpg";
        [NotMapped]
        public string[] AllytipList { get; set; } = [];
        [NotMapped]
        public string[] EnemytipList { get; set; } = [];
    }
    public class Info
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Difficulty { get; set; }
    }
    public class States
    {
        [Key]
        public string Id { get; set; } = string.Empty;
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
        [Key]
        public Guid Guid { get; set; }
        public string Id { get; set; } = string.Empty;
        public string ImageId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class Love
    {
        [Key]
        public string Id { get; set; } = string.Empty;
    }
    public class LOLIllustratedBook_DbContext(DbContextOptions<LOLIllustratedBook_DbContext> options) : DbContext(options)
    {
        public DbSet<Champion> Champion { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Spell> Spell { get; set; }
        public DbSet<Love> Love { get; set; }
    }
}
