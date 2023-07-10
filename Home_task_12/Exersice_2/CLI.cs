using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exercise_2
{
    internal class CLI
    {
        readonly string INFO = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "CLI_Manual.txt"));
        readonly Dictionary<Commands, string> command_Keyword = new Dictionary<Commands, string>
        {
            {Commands.Info,"info"},
            {Commands.TableInfo,"get_tables"},
            {Commands.TableSelect,"select_table"},

            {Commands.CloseCLI,"close"},

            {Commands.Create,"create"},
            {Commands.Read,"read"},
            {Commands.Update,"update"},
            {Commands.Delete,"delete"},
        };
        private DBAdapter.DBTable CurrentTable = DBAdapter.DBTable.None;
        string prefix = string.Empty;

        DBAdapter adapter;


        public CLI(DBAdapter adapter)
        {
            if (adapter == null)
                throw new ArgumentNullException(nameof(adapter));
            this.adapter = adapter;
        }
        public void OpenCLI()
        {
            CurrentTable = DBAdapter.DBTable.None;
            string inputCommand = "~~~~~~~~~~~~~~~CLI is activated~~~~~~~~~~~~~~~";
            Console.SetCursorPosition((Console.WindowWidth - "CLI is activated".Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CLI is activated");
            Console.ResetColor();

            Info();
            prefix = string.Empty;
            Console.Write($"{prefix}>");
            inputCommand = Console.ReadLine();
            while (inputCommand != command_Keyword[Commands.CloseCLI])
            {
                DefineCommand(inputCommand);

                Console.Write($"{prefix}>");

                inputCommand = Console.ReadLine();
            }
            CloseCLI();
        }
        void CloseCLI()
        {
            Console.SetCursorPosition((Console.WindowWidth - "CLI is deactivated".Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CLI is activated");
            Console.ResetColor();

        }
        void Info()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + INFO + "\n\n\n");
            Console.ResetColor();
        }
        void DefineCommand(string commandString)
        {
            commandString = commandString.ToLower();
            string commandPart = commandString.Split(' ')[0];
            if (command_Keyword.ContainsValue(commandPart))
            {
                //Info and Table select
                if (commandPart == command_Keyword[Commands.TableInfo])
                {
                    StringBuilder sb = new StringBuilder();
                    Console.WriteLine("Available tables:");
                    foreach (string table in Enum.GetNames(CurrentTable.GetType()))
                    {
                        Console.WriteLine($"-----{table}");
                    }

                }
                else if (commandPart == command_Keyword[Commands.Info])
                {
                    Info();
                }
                else if (commandPart == command_Keyword[Commands.TableSelect])
                {
                    SelectTable(commandString.Split(' ')[1]);
                }

                //CRUD OPERATIONS
                else if (CurrentTable != DBAdapter.DBTable.None)
                {
                    if (commandPart == command_Keyword[Commands.Create])
                    {
                        Create();
                    }
                    else if (commandPart == command_Keyword[Commands.Read])
                    {
                        if (commandString.Split(' ').Length > 1)
                            if (int.TryParse(commandString.Split(' ')[1], out int id))
                                Read(id);
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid <id> format");
                                Console.ResetColor();
                            }
                        else
                            Read();

                    }
                    else if (commandPart == command_Keyword[Commands.Update])
                    {
                        if (int.TryParse(commandString.Split(' ')[1], out int id))
                            Update(id);
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid <id> format");
                            Console.ResetColor();
                        }
                    }
                    else if (commandPart == command_Keyword[Commands.Delete])
                    {
                        if (int.TryParse(commandString.Split(' ')[1], out int id))
                            Delete(id);
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid <id> format");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Please command SELECT TABLE, before execute CRUD operations.\nTo get list of all awailable tables, please input \"{command_Keyword[Commands.TableInfo]}\" command.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command! Type <INFO> to get info about available commands");
                Console.ResetColor();
            }
        }
        void Create()
        {
            if (CurrentTable == DBAdapter.DBTable.Category)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Name[string]: ");
                Console.ResetColor();
                string Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid data inputted.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Description[string?]: ");
                    Console.ResetColor();
                    string Description = Console.ReadLine();
                    adapter.AddCategory(Name, Description);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New Category added.");
                    Console.ResetColor();
                }


            }
            else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Name[string]: ");
                Console.ResetColor();
                string Name = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"WEB-site[string?]: ");
                Console.ResetColor();
                string WebLink = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Country[string]: ");
                Console.ResetColor();
                string Country = Console.ReadLine();

                adapter.AddManufacturer(Name, WebLink, Country);
            }
            else if (CurrentTable == DBAdapter.DBTable.Item || CurrentTable == DBAdapter.DBTable.ItemParams)
            {
                List<bool> check = new List<bool>();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Name[string]: ");
                Console.ResetColor();
                string Name = Console.ReadLine();
                check.Add(!string.IsNullOrEmpty(Name));

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Description[string?]: ");
                Console.ResetColor();
                string Description = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Price[decimal(ex: {123456.12345M})]: ");
                Console.ResetColor();
                check.Add(decimal.TryParse(Console.ReadLine(), out decimal Price));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Barcode[string]: ");
                Console.ResetColor();
                string SerialNum = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Day of publish[int]: ");
                Console.ResetColor();
                int day;
                check.Add(int.TryParse(Console.ReadLine(), out day));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Month of publish[int]: ");
                Console.ResetColor();
                check.Add(int.TryParse(Console.ReadLine(), out int month));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Year of publish[int]: ");
                Console.ResetColor();
                check.Add(int.TryParse(Console.ReadLine(), out int year));
                DateTime DateOfManufacturer = new DateTime(year, month, day);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Category id[int]: ");
                Console.ResetColor();
                check.Add(int.TryParse(Console.ReadLine(), out int CategoryId));
                check.Add(adapter.GetCategory(CategoryId) != null);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Publisher id[int]: ");
                Console.ResetColor();
                check.Add(int.TryParse(Console.ReadLine(), out int ManufacturerId));
                check.Add(adapter.GetManufacturer(ManufacturerId) != null);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Language[string]: ");
                Console.ResetColor();
                string Language = Console.ReadLine();
                check.Add(!string.IsNullOrEmpty(Language));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Author[string]: ");
                Console.ResetColor();
                string Author = Console.ReadLine();
                check.Add(!string.IsNullOrEmpty(Author));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Country[string]: ");
                Console.ResetColor();
                string Country = Console.ReadLine();
                check.Add(!string.IsNullOrEmpty(Country));

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Type[string]: ");
                string Type = Console.ReadLine();
                check.Add(!string.IsNullOrEmpty(Type));

                if (check.TrueForAll(x => x == true))
                {
                    adapter.AddItem(Name, Description, Price, SerialNum, DateOfManufacturer, Language, Author, Country, Type, CategoryId, ManufacturerId);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New Item added.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid data inputted.");
                    Console.ResetColor();
                }
            }
        }
        void Read(int id)
        {
            if (IsIdCorrect(id))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (CurrentTable == DBAdapter.DBTable.Category)
                {
                    Console.WriteLine(adapter.GetCategory(id).ToString());
                }
                else if (CurrentTable == DBAdapter.DBTable.Item)
                {
                    Console.WriteLine(adapter.GetItem(id).ToString());
                }
                else if (CurrentTable == DBAdapter.DBTable.ItemParams)
                {
                    Console.WriteLine(adapter.GetItemParams(id).ToString());
                }
                else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
                {
                    Console.WriteLine(adapter.GetManufacturer(id).ToString());
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong ID!");
                Console.ResetColor();
            }

            Console.ResetColor();
        }
        void Read()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("IDs: " +
                "");
            if (CurrentTable == DBAdapter.DBTable.Category)
            {
                Console.WriteLine(string.Join(", ", adapter.GetCategoryIds()));
            }
            else if (CurrentTable == DBAdapter.DBTable.Item)
            {
                Console.WriteLine(string.Join(", ", adapter.GetComicIds()));
            }
            else if (CurrentTable == DBAdapter.DBTable.ItemParams)
            {
                Console.WriteLine(string.Join(", ", adapter.GetComicParamsIds()));
            }
            else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
            {
                Console.WriteLine(string.Join(", ", adapter.GetManufacturerIds()));
            }
            Console.ResetColor();
        }
        void Update(int id)
        {
            if (IsIdCorrect(id))
            {
                if (CurrentTable == DBAdapter.DBTable.Category)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"New name[string]: ");
                    Console.ResetColor();
                    string Name = Console.ReadLine();
                    if (string.IsNullOrEmpty(Name))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid data inputted.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"New description[string?]: ");
                        Console.ResetColor();
                        string Description = Console.ReadLine();

                        adapter.ChangeCategory(id, Name, Description);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Element updated.");
                        Console.ResetColor();
                    }


                }
                else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
                {
                    List<bool> check = new List<bool>();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"New name[string]: ");
                    Console.ResetColor();
                    string Name = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Name));

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"New WEB-site[string?]: ");
                    Console.ResetColor();
                    string WebLink = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"New country[string]: ");
                    Console.ResetColor();
                    string Country = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Country));

                    if (check.TrueForAll(x => x == true))
                    {
                        adapter.ChangeManufacturer(id, Name, WebLink, Country);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Element updated.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid data inputted.");
                        Console.ResetColor();
                    }
                }
                else if (CurrentTable == DBAdapter.DBTable.Item)
                {
                    List<bool> check = new List<bool>();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Name[string]: ");
                    Console.ResetColor();
                    string Name = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Name));

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"Description[string?]: ");
                    Console.ResetColor();
                    string Description = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Price[decimal(ex: {123456.12345M})]: ");
                    Console.ResetColor();
                    check.Add(decimal.TryParse(Console.ReadLine(), out decimal Price));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Barcode[string]: ");
                    Console.ResetColor();
                    string Barcode = Console.ReadLine();
                    check.Add(string.IsNullOrEmpty(Barcode));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Day of Publish[int]: ");
                    Console.ResetColor();
                    int day;
                    check.Add(int.TryParse(Console.ReadLine(), out day));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Month of Publish[int]: ");
                    Console.ResetColor();
                    check.Add(int.TryParse(Console.ReadLine(), out int month));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Year of Publish[int]: ");
                    Console.ResetColor();
                    check.Add(int.TryParse(Console.ReadLine(), out int year));
                    DateTime DateOfPublish = new DateTime(year, month, day);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Category id[int]: ");
                    Console.ResetColor();
                    check.Add(int.TryParse(Console.ReadLine(), out int CategoryId));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Manufacturer id[int]: ");
                    Console.ResetColor();
                    check.Add(int.TryParse(Console.ReadLine(), out int PublisherId));

                    if (check.TrueForAll(x => x == true))
                    {
                        adapter.ChangeItem(id, Name, Description, Price, Barcode, DateOfPublish, CategoryId, PublisherId);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Element updated.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid data inputted.");
                        Console.ResetColor();
                    }
                }
                else if (CurrentTable == DBAdapter.DBTable.ItemParams)
                {
                    List<bool> check = new List<bool>();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Language[string]: ");
                    Console.ResetColor();
                    string Language = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Language));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Author[string]: ");
                    Console.ResetColor();
                    string Author = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Author));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Depth[double]: ");
                    Console.ResetColor();
                    string Contry = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Contry));

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"Weight[double]: ");
                    Console.ResetColor();
                    string Type = Console.ReadLine();
                    check.Add(!string.IsNullOrEmpty(Type));

                    if (check.TrueForAll(x => x == true))
                    {
                        adapter.ChangeItemParams(id, Language, Author, Contry, Type);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Element updated.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid data inputted.");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Wrong ID!");
                Console.ResetColor();
            }

        }
        void Delete(int id)
        {
            if (CurrentTable == DBAdapter.DBTable.Category)
            {
                adapter.DeleteCategory(id);
            }
            else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
            {
                adapter.DeleteManufacturer(id);
            }
            else if (CurrentTable == DBAdapter.DBTable.Item)
            {
                adapter.DeleteByItem(id);
            }
            else if (CurrentTable == DBAdapter.DBTable.ItemParams)
            {
                adapter.DeleteByItemParams(id);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Element deleted");
            Console.ResetColor();
        }
        void SelectTable(string tableName)
        {
            if (Enum.GetNames(CurrentTable.GetType()).Select(x => x.ToLower()).Contains(tableName))
            {
                CurrentTable = (DBAdapter.DBTable)Enum.Parse(CurrentTable.GetType(), tableName, true);
            }
            prefix = CurrentTable != DBAdapter.DBTable.None ? CurrentTable.ToString() : "";
        }

        bool IsIdCorrect(int id)
        {
            if (CurrentTable == DBAdapter.DBTable.Category)
            {
                return adapter.GetCategory(id) != null;
            }
            else if (CurrentTable == DBAdapter.DBTable.Item)
            {
                return adapter.GetItem(id) != null;
            }
            else if (CurrentTable == DBAdapter.DBTable.ItemParams)
            {
                return adapter.GetItemParams(id) != null;
            }
            else if (CurrentTable == DBAdapter.DBTable.Manufacturer)
            {
                return adapter.GetManufacturer(id) != null;
            }
            return false;
        }
        enum Commands
        {
            Create,
            Read,
            Update,
            Delete,
            CloseCLI,
            Info,
            TableInfo,
            TableSelect
        }
    }
}
