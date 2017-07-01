using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace HotelManagement
{
    class Hotel
    {
        public static void make_rooms(int flr)
        {
            for (int i = 1; i <= flr; i++)
            {
                int temp = (i * 100) + 1;
                for (int rnum = temp; rnum < temp + 50; rnum++)
                {

                    if ((rnum >= 100 && rnum <= 110) || (rnum >= 200 && rnum <= 210) || (rnum >= 300 && rnum <= 310) || (rnum >= 400 && rnum <= 410) || (rnum >= 500 && rnum <= 510))
                    {
                        Room room = new StandardRoom();
                        room.room_no = rnum;
                        room.reserved = "yes";
                        write_file(room);
                    }
                    else if ((rnum >= 111 && rnum <= 120) || (rnum >= 211 && rnum <= 220) || (rnum >= 311 && rnum <= 320) || (rnum >= 411 && rnum <= 420) || (rnum >= 511 && rnum <= 520))
                    {
                        Room room = new ModerateRoom();
                        room.room_no = rnum;
                        room.reserved = "yes";
                        write_file(room);
                    }
                    else if ((rnum >= 121 && rnum <= 130) || (rnum >= 221 && rnum <= 230) || (rnum >= 321 && rnum <= 330) || (rnum >= 421 && rnum <= 430) || (rnum >= 521 && rnum <= 530))
                    {
                        Room room = new SuperiorRoom();
                        room.room_no = rnum;
                        room.reserved = "yes";
                        write_file(room);
                    }
                    else if ((rnum >= 131 && rnum <= 140) || (rnum >= 231 && rnum <= 240) || (rnum >= 331 && rnum <= 340) || (rnum >= 431 && rnum <= 440) || (rnum >= 531 && rnum <= 540))
                    {
                        Room room = new JuniorRoom();
                        room.room_no = rnum;
                        room.reserved = "yes";
                        write_file(room);
                    }
                    else if ((rnum >= 141 && rnum <= 150) || (rnum >= 241 && rnum <= 250) || (rnum >= 341 && rnum <= 350) || (rnum >= 441 && rnum <= 450) || (rnum >= 541 && rnum <= 550))
                    {
                        Room room = new SuiteRoom();
                        room.room_no = rnum;
                        room.reserved = "yes";
                        write_file(room);
                    }
                }
            }
        }

        public static void write_file(Room obj)
        {
            if (!File.Exists("Rooms.xml"))
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                XmlWriter myfile = XmlWriter.Create("Rooms.xml", setting);
                myfile.WriteStartDocument();
                myfile.WriteStartElement("Hotel");

                myfile.WriteStartElement("Room");
                myfile.WriteElementString("No", obj.room_no.ToString());
                myfile.WriteElementString("Type", obj.get_type().ToString());
                myfile.WriteElementString("Available", obj.get_reserv().ToString());
                myfile.WriteEndElement();

                myfile.WriteEndDocument();
                myfile.Flush();
                myfile.Close();

            }
            else
            {
                XDocument temp = new XDocument();
                temp = XDocument.Load("Rooms.xml");
                temp.Element("Hotel").Add(new XElement("Room",
                                        new XElement("No", new XText(obj.room_no.ToString())),
                                        new XElement("Type", new XText(obj.get_type().ToString())),
                                        new XElement("Available", new XText(obj.get_reserv().ToString()))));
                temp.Save("Rooms.xml");


            }
        }
        static void Main(string[] args)
        {
            if (!File.Exists("Rooms.xml"))
            {
                make_rooms(6);
            }
                

            bool check = true;
            while (check)
            {
                Console.WriteLine("****Welcome to Hotel Management system****");
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1. Set floors, rooms, and pricing");
                Console.WriteLine("2. Reserve a room ");
                Console.WriteLine("3. Check-Out");
                Console.WriteLine("4. Queries");
                Console.WriteLine("5. Exit");
                string inp = Console.ReadLine();
                if (inp == "1")
                {
                    Console.WriteLine("a. Set numer of floors");
                    Console.WriteLine("b. Set rooms per floors");
                    Console.WriteLine("c. Set room pricing");
                    inp = Console.ReadLine();
                    if (inp == "a")
                    {
                        string floor = Console.ReadLine();
                        //write to file
                    }
                    else if (inp == "b")
                    {
                        Console.WriteLine("***Set rooms per floors***");
                        string rooms = Console.ReadLine();

                    }
                    else if (inp == "c")
                    {
                        Console.WriteLine("Enter type pf room: ");
                        string roomstype = Console.ReadLine();
                        Console.WriteLine("Enter new Price: ");
                        string room_p = Console.ReadLine();
                        //write changes to file

                    }

                }
                else if (inp == "2")
                {
                    Console.WriteLine("***Reserve a Room***");
                    Console.WriteLine("a. New cutomer ");
                    Console.WriteLine("b. Old cutomer ");
                    inp = Console.ReadLine();
                    if (inp == "a" || inp == "A")
                    {
                        Console.WriteLine("***New customer***");
                        Console.WriteLine("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Gender: ");
                        string gen = Console.ReadLine();
                        Console.WriteLine("CNIC: ");
                        string id = Console.ReadLine();
                        Console.WriteLine("Room Type: ");
                        string type = Console.ReadLine();

                        Console.WriteLine("Floor No: ");
                        string f_no = Console.ReadLine();

                        Console.WriteLine("Room No: ");
                        string r_no = Console.ReadLine();

                        Console.WriteLine("No of days: ");
                        string d = Console.ReadLine();
                        int days = int.Parse(d);
                        int rno = int.Parse(r_no);
                        int fno = int.Parse(f_no);

                        Customer mycust = new Customer(name, gen, id, type, days, rno, fno);

                        Console.WriteLine("name: " + mycust.Full_name.ToString() + "time: " + mycust.Time_remain.ToString());

                        mycust.write_cust();
                       
                        mycust.giveRoom(id,type,f_no,r_no);
                        mycust.updateroom(r_no, "no");




                    }
                    else if (inp == "b" || inp == "B")
                    {
                        Console.WriteLine("Enter Customer ID to book room: ");
                        string id = Console.ReadLine();

                        Console.WriteLine("Room Type: ");
                        string type = Console.ReadLine();

                        Console.WriteLine("Floor No: ");
                        string f_no = Console.ReadLine();

                        Console.WriteLine("Room No: ");
                        string r_no = Console.ReadLine();

                        Customer temp = new Customer();
                        temp.giveRoom(id, type, f_no, r_no);
                        //temp.updateroom(r_no, "no");

                    }
                }
                else if (inp == "3")
                {
                    Console.WriteLine("Enter Customer ID: ");
                    string id = Console.ReadLine();
                    Customer checkout = new Customer();
                    checkout.checkout(id);

                }
                else if (inp == "4")
                {
                    Console.WriteLine("***Queries***");
                    Console.WriteLine("a. How many customers have checked in today ");
                    Console.WriteLine("b.How many have checked out today ");
                    Console.WriteLine("c.How many rooms have been reserved and their types ");
                    Console.WriteLine("d.How many are empty and their types. ");

                    inp = Console.ReadLine();
                    if (inp == "a" || inp == "A")
                    {
                        Search check_today = new Search();
                        int total = check_today.total_checkin();

                        Console.WriteLine("Total Check in Today: " + total);
                    }
                    else if (inp == "b" || inp == "B")
                    {
                        Search check_today = new Search();
                        int total = check_today.total_checkin();
                        Console.WriteLine("Total check out today: " + total);
                    }
                    else if (inp == "c" || inp == "C")
                    {
                        Search reserved = new Search();
                        int[] arr = reserved.get_rooms();
                        Console.WriteLine("Reserved rooms:");
                        Console.WriteLine("suite: " + arr[0]);
                        Console.WriteLine("junior: " + arr[1]);
                        Console.WriteLine("superior: " + arr[2]);
                        Console.WriteLine("moderate: " + arr[3]);
                        Console.WriteLine("standard: " + arr[4]);


                    }
                    else if (inp == "d" || inp == "D")
                    {
                        Search empty = new Search();
                        int[] arr = empty.get_empty_rooms();
                        Console.WriteLine("empty rooms:");
                        Console.WriteLine("suite: " + arr[0]);
                        Console.WriteLine("junior: " + arr[1]);
                        Console.WriteLine("superior: " + arr[2]);
                        Console.WriteLine("moderate: " + arr[3]);
                        Console.WriteLine("standard: " + arr[4]);
                    }




                    //Console.WriteLine("lala" + cus.Full_name);
                    Console.ReadLine();
                }
                else if (inp == "5")
                {
                    check = false;
                    break;
                }
            }

            Console.WriteLine("Exiting");
            Console.ReadLine();
        }
    }
}
