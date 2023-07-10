using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Exercise_2.DB;

namespace Exercise_2
{
    internal class DBAdapter
    {
        private ComicsShopModelContainer context;
        public DBAdapter(ComicsShopModelContainer context)
        {
            this.context = context;
            context.CategorySet.Load();
            context.PublisherSet.Load();
            context.ItemSet.Load();
            context.ItemParamsSet.Load();
        }
        public DBAdapter()
        {
            context = new ComicsShopModelContainer();
            context.CategorySet.Load();
            context.PublisherSet.Load();
            context.ItemSet.Load();
            context.ItemParamsSet.Load();

        }
        public void ClearDB()
        {
            context.CategorySet.RemoveRange(context.CategorySet);
            context.PublisherSet.RemoveRange(context.PublisherSet);
            context.ItemSet.RemoveRange(context.ItemSet);
            context.ItemParamsSet.RemoveRange(context.ItemParamsSet);
            context.SaveChanges();
        }

        public void RefillComicsShopDB()
        {
            Category Comics = new Category
            {
                //Id = 0,
                Name = "Comics",
                Description = "Comics, Manhva, Manga...",
            };
            Category Manga = new Category
            {
                //Id = 1,
                Name = "Manga",
                Description = "Contains all mangas"
            };
            Publisher MangaJP = new Publisher
            {
                //Id = 0,
                Name = "MangaJP",
                WEB_Site_Link = "Manga.jp",
                Country = "Japan"
            };
            Publisher MangaEurope = new Publisher
            {
                //Id = 1,
                Name = "MangaEu",
                WEB_Site_Link = "Manga.com",
                Country = "Ukraine"
            };
            Comic MushokuTenseiJoblessReincarnation = new Comic
            {
                //Id = 0,
                Name = "Mushoku Tensei Jobless Reincarnation Tome 2",
                Description = "Mushoku Tensei Jobless Reincarnation.",
                Price = 300,
                Barcode = "21412412412412",
                DateOfPublish = new DateTime(2022, 7, 1),
                CategoryId = Comics.Id,
                PublisherId = MangaJP.Id,
            };
            Comic AkameGaKill = new Comic
            {
                //Id = 1,
                Name = "Akame Ga Kill! Tome 1",
                Price = 199,
                Barcode = "12412412213",
                DateOfPublish = new DateTime(2022, 5, 1),
                CategoryId = Comics.Id,
                PublisherId = MangaEurope.Id,
            };

            ComicParams MushokuTenseiJoblessReincarnationParams = new ComicParams
            {
                Language = "English",
                Country = "Japan",
                Author = "Rifugin on Magonot",
                Type = "Ranobe",
                Comic = MushokuTenseiJoblessReincarnation,
            };
            ComicParams AkameGaKillParams = new ComicParams
            {
                Language = "Japanese",
                Country = "Japan",
                Author = "Sakahiro",
                Type = "Manga",
                Comic = AkameGaKill,
            };
            ClearDB();

            context.CategorySet.Add(Comics);
            context.CategorySet.Add(Manga);

            context.PublisherSet.Add(MangaJP);
            context.PublisherSet.Add(MangaEurope);

            context.ItemSet.Add(MushokuTenseiJoblessReincarnation);
            context.ItemSet.Add(AkameGaKill);

            context.ItemParamsSet.RemoveRange(context.ItemParamsSet.ToArray());
            context.ItemParamsSet.Add(MushokuTenseiJoblessReincarnationParams);
            context.ItemParamsSet.Add(AkameGaKillParams);

            context.SaveChanges();

        }

        public IEnumerable<int> GetCategoryIds()
        {
            return context.CategorySet.Select(x => x.Id).ToList();
        }

        public Category GetCategory(int id) => context.CategorySet.Find(id);
        public void AddCategory(string Name, string Description)
        {
            Category tmpCategory = new Category
            {
                //Id = context.CategorySet.ToList().Max(x => x.Id) + 1,
                Name = Name,
                Description = Description
            };

            context.CategorySet.Add(tmpCategory);
            context.SaveChanges();
        }
        public void ChangeCategory(int id, string newName, string newDescription)
        {
            Category tmpCategory = context.CategorySet.Find(id);
            tmpCategory.Name = newName;
            tmpCategory.Description = newDescription;

            context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = context.CategorySet.Find(id);
            if (category != null)
            {
                context.CategorySet.Remove(category);
                context.SaveChanges();
            }
        }


        public IEnumerable<int> GetManufacturerIds()
        {
            return context.PublisherSet.Select(x => x.Id).ToList();
        }
        
        public Publisher GetManufacturer(int id) => context.PublisherSet.Find(id);
        public void AddManufacturer(string Name, string WebLink, string Country)
        {
            Publisher tmpCategory = new Publisher
            {
                //Id = context.CategorySet.ToList().Max(x => x.Id) + 1,
                Name = Name,
                WEB_Site_Link = WebLink,
                Country = Country
            };

            context.PublisherSet.Add(tmpCategory);

            context.SaveChanges();
        }
        public void ChangeManufacturer(int id, string Name, string WebLink, string Country)
        {
            Publisher tmp = context.PublisherSet.Find(id);
            tmp.Name = Name;
            tmp.WEB_Site_Link = WebLink;
            tmp.Country = Country;

            context.SaveChanges();
        }
        public void DeleteManufacturer(int id)
        {
            var manufacturer = context.PublisherSet.Find(id);
            if (manufacturer != null)
            {
                context.PublisherSet.Remove(manufacturer);
                context.SaveChanges();
            }
        }

        public IEnumerable<int> GetComicIds()
        {
            return context.ItemSet.Select(x => x.Id).ToList();
        }
        public IEnumerable<int> GetComicParamsIds()
        {
            return context.ItemParamsSet.Select(x => x.Id).ToList();
        }
        public Comic GetItem(int id) => context.ItemSet.Find(id);
        public ComicParams GetItemParams(int id) => context.ItemParamsSet.Find(id);
        public void AddItem(string Name, string Description, decimal Price, string Barcode, DateTime DateOfPublish,
            string Language, string Country, string Author, string Type, int CategoryId, int PublisherId)
        {
            Comic tmpComic = new Comic
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Barcode = Barcode,
                DateOfPublish = DateOfPublish,
                CategoryId = CategoryId,
                PublisherId = PublisherId,
            };

            ComicParams tmpComicParams = new ComicParams
            {
                Language = Language,
                Country = Country,
                Author = Author,
                Type = Type,
                Comic = tmpComic,
            };

            context.ItemSet.Add(tmpComic);
            context.ItemParamsSet.Add(tmpComicParams);
            context.SaveChanges();
        }
        public void ChangeItem(int id, string Name, string Description, decimal Price, string SerialNum, DateTime DateOfManufacture, int CategoryId, int ManufacturerId)
        {
            Comic tmp = context.ItemSet.Find(id);
            tmp.Name = Name;
            tmp.Description = Description;
            tmp.Price = Price;
            tmp.Barcode = SerialNum;
            tmp.DateOfPublish = DateOfManufacture;
            tmp.CategoryId = CategoryId;
            tmp.PublisherId = ManufacturerId;


            context.SaveChanges();
        }
        public void ChangeItemParams(int id, string Language, string Country, string Author, string Type)
        {
            ComicParams tmp = context.ItemParamsSet.Find(id);
            tmp.Language = Language;
            tmp.Country = Country;
            tmp.Author = Author;
            tmp.Type = Type;

            context.SaveChanges();
        }
        public void DeleteByItem(int id)
        {
            var item = context.ItemSet.Find(id);
            if (item != null)
            {
                context.ItemParamsSet.Remove(item.ComicParams);
                context.ItemSet.Remove(item);
                context.SaveChanges();
            }
        }
        public void DeleteByItemParams(int id)
        {
            var itemParams = context.ItemParamsSet.Find(id);
            if (itemParams != null)
            {
                context.ItemParamsSet.Remove(itemParams);
                context.ItemSet.Remove(itemParams.Comic);
                context.SaveChanges();
            }
        }

        public enum DBTable
        {
            None,
            Category,
            Manufacturer,
            Item,
            ItemParams
        }
    }
}
