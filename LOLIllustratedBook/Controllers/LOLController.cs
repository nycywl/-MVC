using LOLIllustratedBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using Newtonsoft.Json;

namespace LOLIllustratedBook.Controllers
{
    public class LOLController(LOLIllustratedBook_DbContext db) : Controller
    {
        public async Task<IActionResult> Menu(string? tag = null, string? state = null, string? search = null, int ststeValue = 0)
        {
            var source = db.Champion.ToList();
            var source_Info = db.Info.ToList();
            var source_States = db.States.ToList();
            var data = source.Select(d => new DTO.DTOChampion()
            {
                Id = d.Id,
                Name = d.Name,
                Blurb = d.Blurb,
                Partype = d.Partype,
                Tags = d.Tags,
                Title = d.Title,
                Defense = source_Info.First(t => t.Id == d.Id).Defense,
                Difficulty = source_Info.First(t => t.Id == d.Id).Difficulty,
                Attack = source_Info.First(t => t.Id == d.Id).Attack,
                Magic = source_Info.First(t => t.Id == d.Id).Magic,
                Armor = source_States.First(t => t.Id == d.Id).Armor,
                Armorperlevel = source_States.First(t => t.Id == d.Id).Armorperlevel,
                Attackdamage = source_States.First(t => t.Id == d.Id).Attackdamage,
                Attackdamageperlevel = source_States.First(t => t.Id == d.Id).Attackdamageperlevel,
                Attackrange = source_States.First(t => t.Id == d.Id).Attackrange,
                Attackspeed = source_States.First(t => t.Id == d.Id).Attackspeed,
                Attackspeedperlevel = source_States.First(t => t.Id == d.Id).Attackspeedperlevel,
                Crit = source_States.First(t => t.Id == d.Id).Crit,
                Critperlevel = source_States.First(t => t.Id == d.Id).Critperlevel,
                Hp = source_States.First(t => t.Id == d.Id).Hp,
                Hpperlevel = source_States.First(t => t.Id == d.Id).Hpperlevel,
                Hpregen = source_States.First(t => t.Id == d.Id).Hpperlevel,
                Hpregenperlevel = source_States.First(t => t.Id == d.Id).Hpperlevel,
                Movespeed = source_States.First(t => t.Id == d.Id).Movespeed,
                Mp = source_States.First(t => t.Id == d.Id).Mp,
                Mpperlevel = source_States.First(t => t.Id == d.Id).Mpperlevel,
                Mpregen = source_States.First(t => t.Id == d.Id).Mpregen,
                Mpregenperlevel = source_States.First(t => t.Id == d.Id).Mpregenperlevel,
                Spellblock = source_States.First(t => t.Id == d.Id).Spellblock,
                Spellblockperlevel = source_States.First(t => t.Id == d.Id).Spellblockperlevel,
                ImageURL = $"https://ddragon.leagueoflegends.com/cdn/img/champion/splash/{d.Id}_0.jpg",
            }).ToList();
            // 獲取英雄資料
            if (data.Count != 152)
            {
                await GetChampionDataAsync();
            }
            var states = new List<SelectListItem>()
            {
                new() { Text = "全部", Value = string.Empty },
                new() { Text = "攻擊力", Value = "Attack" },
                new() { Text = "魔力", Value = "Magic" },
                new() { Text = "防禦力", Value = "Defense" },
                new() { Text = "難度", Value = "Difficulty" }
            };
            var championTags = new List<SelectListItem>()
            {
                new() { Text = "全部" , Value = string.Empty },
                new() { Text = "刺客" , Value = "Assassin" },
                new() { Text = "戰士" , Value = "Fighter" },
                new() { Text = "法師" , Value = "Mage" },
                new() { Text = "射手" , Value = "Marksman" },
                new() { Text = "支援" , Value = "Support" },
                new() { Text = "坦克" , Value = "Tank" },
            };

            ViewBag.States = states;
            ViewBag.ChampionTags = championTags;
            ViewBag.Search = search;
            ViewBag.StsteValue = ststeValue;

            if (!string.IsNullOrEmpty(search))
                data = data.Where(d => d.Name.Contains(search) || d.Id.Contains(search)).ToList(); // 根據 search 參數過濾英雄資料
            if (!string.IsNullOrEmpty(tag))
                data = data.Where(d => d.Tags.Contains(tag)).ToList();
            if (!string.IsNullOrEmpty(state))
            {
                data = state switch
                {
                    "Attack" => data.Where(d => d.Attack == ststeValue).ToList(),
                    "Magic" => data.Where(d => d.Magic == ststeValue).ToList(),
                    "Defense" => data.Where(d => d.Defense == ststeValue).ToList(),
                    "Difficulty" => data.Where(d => d.Difficulty == ststeValue).ToList(),
                    _ => data
                };
            }
            return View(data);
        }

        // 根據英雄 ID 獲取英雄詳細資料並顯示
        public IActionResult ChampionContent(string Id)
        {
            var champion = db.Champion.Find(Id);
            if (champion == null)
                return BadRequest();

            var data = new DTO.ChampionData()
            {
                DTO_Champion = champion,
                DTO_Info = db.Info.FirstOrDefault(d => d.Id == Id) ?? new(),
                DTO_Spells = db.Spell.Where(d => d.Id == Id).ToList() ?? [],
                DTO_States = db.States.FirstOrDefault(d => d.Id == Id) ?? new()
            };
            data.DTO_Champion.AllytipList = FormatArray(data.DTO_Champion.Allytips);
            data.DTO_Champion.EnemytipList = FormatArray(data.DTO_Champion.Enemytips);

            return View(data);
        }
        public IActionResult Love()
        {
            var data = db.Love.ToList();
            return View(data);
        }
        public IActionResult AddLove(string Id)
        {
            try
            {
                db.Love.Add(new Love() { Id = Id });
                db.SaveChanges();
            }
            catch 
            {
                return RedirectToAction("Love","LoL");
            }
            return RedirectToAction("Love","LoL");
        }
        public IActionResult RemoveLove(string Id)
        {
            try
            {
                var data = db.Love.FirstOrDefault(d => d.Id == Id);
                if (data is null)
                    return Love();
                db.Love.Remove(data);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Love", "LoL");
            }
            return RedirectToAction("Love", "LoL");
        }

        // 獲取遊戲英雄列表到資料庫
        public async Task GetChampionDataAsync()
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"https://ddragon.leagueoflegends.com/cdn/10.22.1/data/zh_TW/champion.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<JsonData.ChampionData>(responseBody) ?? new();
            data.ChampionList = [.. data.Data.Values];
            var champions = data.ChampionList.Select(d => new Champion()
            {
                Id = d.Id,
                Name = d.Name,
                Allytips = JsonConvert.SerializeObject(d.Allytips),
                Blurb = d.Blurb,
                Enemytips = JsonConvert.SerializeObject(d.Enemytips),
                KeyName = d.Key,
                Lore = d.Lore,
                Partype = d.Partype,
                Tags = JsonConvert.SerializeObject(d.Tags),
                Title = d.Title
            }).ToList();
            var info = data.ChampionList.Select(d => new Info()
            {
                Id =d.Id,
                Defense = d.Info.Defense,
                Difficulty = d.Info.Difficulty,
                Attack = d.Info.Attack,
                Magic = d.Info.Magic,
            }).ToList();
            var state = data.ChampionList.Select(d => new States()
            {
                Id = d.Id,
                Armor = d.Stats.Armor,
                Armorperlevel = d.Stats.Armorperlevel,
                Attackdamage = d.Stats.Attackdamage,
                Attackdamageperlevel = d.Stats.Attackdamageperlevel,
                Attackrange = d.Stats.Attackrange,
                Attackspeed = d.Stats.Attackspeed,
                Attackspeedperlevel = d.Stats.Attackspeedperlevel,
                Crit = d.Stats.Crit,
                Critperlevel = d.Stats.Critperlevel,
                Hp = d.Stats.Hp,
                Hpperlevel = d.Stats.Hpperlevel,
                Hpregen = d.Stats.Hpperlevel,
                Hpregenperlevel = d.Stats.Hpperlevel,
                Movespeed = d.Stats.Movespeed,
                Mp = d.Stats.Mp,
                Mpperlevel = d.Stats.Mpperlevel,
                Mpregen = d.Stats.Mpregen,
                Mpregenperlevel = d.Stats.Mpregenperlevel,
                Spellblock = d.Stats.Spellblock,
                Spellblockperlevel = d.Stats.Spellblockperlevel
            }).ToList();
            await db.AddRangeAsync(champions);
            await db.AddRangeAsync(info);
            await db.AddRangeAsync(state);
            await db.SaveChangesAsync();
        }

        public string[] FormatArray(string str) => JsonConvert.DeserializeObject<string[]>(str ?? "") ?? [];
    }
}
