namespace ProtectedMultipleObjects
{
    // Base Class
    internal class Club
    {
        protected string _Name;
        protected string _Location;
        protected int _NumMembers;
        protected string _Description;
        protected string _MeetingDay;
        protected string _MeetingTime;

        // Default constructor
        public Club()
        {
            _Name = string.Empty;
            _Location = string.Empty;
            _NumMembers = 0;
            _Description = string.Empty;
            _MeetingDay = string.Empty;
            _MeetingTime = string.Empty;
        }

        // Parameterized constructor
        public Club(string name, string location, int numMembers, string description, string meetingDay, string meetingTime)
        {
            _Name = name;
            _Location = location;
            _NumMembers = numMembers;
            _Description = description;
            _MeetingDay = meetingDay;
            _MeetingTime = meetingTime;
        }

        //get and set methods
        public string getName() { return _Name; }
        public string getLocation() { return _Location; }
        public int getNumMembers() { return _NumMembers; }
        public string getDescription() { return _Description; }
        public string getMeetingDay() { return _MeetingDay; }
        public string getMeetingTime() { return _MeetingTime; }
        public void setName(string name) { _Name = name; }
        public void setLocation(string location) { _Location = location; }
        public void setNumMembers(int numMembers) { _NumMembers = numMembers; }
        public void setDescription(string description) { _Description = description; }
        public void setMeetingDay(string meetingDay) { _MeetingDay = meetingDay; }
        public void setMeetingTime(string meetingTime) { _MeetingTime = meetingTime; }

        public virtual void AddChange()
        {
            Console.Write("What is your club name? ");
            _Name = Console.ReadLine();
            Console.Write("What is the location of the club? ");
            _Location = Console.ReadLine();
            Console.Write("How many members are in the club? ");
            _NumMembers = int.Parse(Console.ReadLine());
            Console.Write("What is the description of the club? ");
            _Description = Console.ReadLine();
            Console.Write("What day does the club meet? ");
            _MeetingDay = Console.ReadLine();
            Console.Write("What time does the club meet? ");
            _MeetingTime = Console.ReadLine();
        }


        public virtual void Print()
        {
            Console.WriteLine();
            Console.WriteLine($"      Club _Name: {_Name}");
            Console.WriteLine($"      Number of Members: {_NumMembers}");
            Console.WriteLine($"      _Location: {_Location}");
            Console.WriteLine($"      _Description: {_Description}");
            Console.WriteLine($"      Meeting Day: {_MeetingDay}");
            Console.WriteLine($"      Meeting Time: {_MeetingTime}");
            Console.WriteLine();
        }
    }

    // Derived class
    internal class KnittingClub : Club
    {
        protected List<string> _Projects;
        protected string _SkillLevel;
        protected string _YarnType;

        // Default constructor
        public KnittingClub()
        {
            _Projects = [];
            _SkillLevel = string.Empty;
            _YarnType = string.Empty;
        }

        // Parameterized constructor
        public KnittingClub(string name, string location, int numMembers, string description, string meetingDay, string meetingTime, List<string> projects, string skillLevel, string yarnType)
            : base(name, location, numMembers, description, meetingDay, meetingTime)
        {
            _Projects = projects;
            _SkillLevel = skillLevel;
            _YarnType = yarnType;
        }

        public override void AddChange()
        {
            base.AddChange();
            Console.Write("What project are you working on? ");
            _Projects.Add(Console.ReadLine());
            Console.Write("What is the skill level of your project? ");
            _SkillLevel = Console.ReadLine();
            Console.Write("What type of yarn does your project require? ");
            _YarnType = Console.ReadLine();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"      _Projects: {string.Join(", ", _Projects)}");
            Console.WriteLine($"      Skill Level: {_SkillLevel}");
            Console.WriteLine($"      Yarn Type: {_YarnType}");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("How many clubs do you want to enter?");
            int maxClubs;
            while (!int.TryParse(Console.ReadLine(), out maxClubs))
            {
                Console.WriteLine("Please enter a whole number");
            }
            //array of clubs
            Club[] clubs = new Club[maxClubs];
            Console.WriteLine("How many knitting clubs do you want to enter?");
            int maxKnitting;
            while (!int.TryParse(Console.ReadLine(), out maxKnitting))
            {
                Console.WriteLine("Please enter a whole number");
            }
            //array of knitting clubs
            KnittingClub[] knittingClubs = new KnittingClub[maxKnitting];

            int choice, type;
            int clubCounter = 0, knittingCounter = 0;

            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Club or 2 for Knitting Club");
                while (!int.TryParse(Console.ReadLine(), out type))
                {
                    Console.WriteLine("Please enter a whole number");
                }

                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1) // Club
                            {
                                if (clubCounter < maxClubs)
                                {
                                    clubs[clubCounter] = new Club();
                                    clubs[clubCounter].AddChange();
                                    clubCounter++;
                                }
                                else
                                {
                                    Console.WriteLine("The maximum number of clubs has been added");
                                }
                            }
                            else // Knitting Club
                            {
                                if (knittingCounter <= maxKnitting)
                                {
                                    knittingClubs[knittingCounter] = new KnittingClub();
                                    knittingClubs[knittingCounter].AddChange();
                                    knittingCounter++;
                                }
                                else
                                {
                                    Console.WriteLine("The maximum number of knitting clubs has been added");
                                }
                            }
                            break;

                        case 2: // Change Club/Knitting Club Details
                            Console.Write("1 for club or 2 for knitting club");
                            ChangeClubDetails(clubs, clubCounter, knittingClubs, knittingCounter);
                            break;

                        case 3: // Print All
                            PrintAllClubs(clubs, clubCounter, knittingClubs, knittingCounter);
                            break;
                        case 4://Quit
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }

        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection is < 1 or > 4)
            {
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
                }
            }

            return selection;
        }

        private static void ChangeClubDetails(Club[] clubs, int clubCounter, KnittingClub[] knittingClubs, int knittingCounter)
        {
            Console.WriteLine("Enter the number of the club you want to change");
            int clubNumber;
            while (!int.TryParse(Console.ReadLine(), out clubNumber) || clubNumber < 1 || clubNumber > clubCounter)
            {
                Console.WriteLine("Please enter a valid club number");
            }
            clubs[clubNumber - 1].AddChange();
        }

        private static void PrintAllClubs(Club[] clubs, int clubCounter, KnittingClub[] knittingClubs, int knittingCounter)
        {
            Console.WriteLine("Current clubs:");
            if (clubCounter == 0 && knittingCounter == 0)
            {
                Console.WriteLine("There are no clubs or knitting clubs to print.");
            }
            else
            {
                for (int i = 0; i < clubCounter; i++)
                {
                    clubs[i].Print();
                }
                for (int i = 0; i < knittingCounter; i++)
                {
                    knittingClubs[i].Print();
                }
            }
        }
    }
}