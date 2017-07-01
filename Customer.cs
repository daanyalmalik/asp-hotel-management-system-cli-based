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
    class Customer
    {
        string full_name;
        string gender;
        string id_num;
        double balance;
        int reserve_day;
        int floorno;
        Room room_type;
        string roomtype;
        int room_no;
        DateTime check_in;
        DateTime check_out;
        double time_remain;

        public Customer()
        {

        }
        public Customer(string na, string g, string id,string type, int days, int room, int floor)
        {
            this.full_name = na;
            this.gender = g;
            this.id_num = id;
            this.room_no = room;
            this.floorno = floor;
            this.roomtype = type;
            this.reserve_day = days;
            if(type=="suite")
            {
                room_type = new SuiteRoom();
            }
            else if(type== "junior")
            {
                room_type = new JuniorRoom();
            }
            else if (type == "superior")
            {
                room_type = new SuperiorRoom();
            }
            else if (type == "moderate")
            {
                room_type = new ModerateRoom();
            }
            else if (type == "standard")
            {
                room_type = new StandardRoom();
            }
            DateTime date = DateTime.Now;
            this.check_in = date;
            Console.WriteLine("lalala date: " + Check_in );
            this.check_out = this.check_in.AddDays(days);
            TimeSpan t = this.check_out.Subtract(this.check_in);
            this.time_remain = t.TotalHours;

            this.balance = this.time_remain * this.room_type.get_price();

        }

        public void write_cust()
        {
            if (!File.Exists("Customers.xml"))
            {
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                XmlWriter myfile = XmlWriter.Create("Customers.xml", setting);
                myfile.WriteStartDocument();
                myfile.WriteStartElement("CustomerData");

                myfile.WriteStartElement("Customer");
                myfile.WriteElementString("Name", this.Full_name.ToString());
                myfile.WriteElementString("Gender", this.Gender.ToString());
                myfile.WriteElementString("ID_No", this.id_num.ToString() );
                myfile.WriteElementString("Balance", this.balance.ToString());
                myfile.WriteElementString("ReserveDays", this.reserve_day.ToString());
                myfile.WriteElementString("FloorNo", this.floorno.ToString());
                myfile.WriteElementString("RoomType", this.roomtype.ToString() );
                myfile.WriteElementString("RoomNo", this.room_no.ToString());
                myfile.WriteElementString("CheckIn", this.check_in.ToString());
                myfile.WriteElementString("CheckOut", this.check_out.ToString());
                myfile.WriteElementString("TimeRemain", this.time_remain.ToString());
                myfile.WriteEndElement();

                myfile.WriteEndDocument();
                myfile.Flush();
                myfile.Close();
            }
            else
            {
                XDocument temp = new XDocument();
                temp = XDocument.Load("Customers.xml");
                temp.Element("CustomerData").Add(new XElement("Customer",
                                        new XElement("Name", new XText(this.Full_name.ToString())),
                                        new XElement("Gender", new XText(this.Gender.ToString())),
                                        new XElement("ID_No", new XText(this.id_num.ToString())),
                                        new XElement("Balance", new XText(this.balance.ToString())),
                                        new XElement("ReserveDays", new XText(this.reserve_day.ToString())),
                                        new XElement("FloorNo", new XText(this.floorno.ToString())),
                                        new XElement("RoomType", new XText(this.room_type.ToString())),
                                        new XElement("RoomNo", new XText(this.room_no.ToString())),
                                        new XElement("CheckIn", new XText(this.check_in.ToString())),
                                        new XElement("CheckOut", new XText(this.check_out.ToString())),
                                        new XElement("TimeRemain", new XText(this.time_remain.ToString()))));
                temp.Save("Customers.xml");


            }
        }

        public void giveRoom(string id, string type, string fno, string rno)
        {
            Console.WriteLine("inside giveroom" +id+ "  " + type + "  " + rno);
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
        C: \Users\daany\Desktop\Semester 6\WEB\ass1\HotelManagement\bin\Debug
         XmlNodeList list = doc.SelectNodes("CustomerData/Customer");
            foreach (XmlNode nd in list)
            {
                string idno = nd["ID_No"].InnerText;
                if (idno == id)
                {
                    //nd["Balance"].InnerText =
                    nd["ReserveDays"].InnerText = rno;
                    nd["FloorNo"].InnerText = fno;
                    nd["RoomType"].InnerText = type;
                }
                else
                {
                    Console.WriteLine("Customer Not Found!");
                    break;
                }
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            
           
        }

        public void updateroom(string rno, string staus)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Rooms.xml");

            XmlNodeList list = doc.SelectNodes("Hotel/Room");
            foreach (XmlNode nd in list)
            {
                string temp = nd["yes"].InnerText;
                if (temp == rno)
                {
                    
                    nd["Available"].InnerText = staus;
                    
                }
                else
                {
                    Console.WriteLine("Room Not Found!");
                    break;
                }
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Rooms.xml");
        }

        public void checkout(string id)
        {
            String roomno=null;
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            
            XmlNodeList list = doc.SelectNodes("CustomerData/Customer");
            foreach (XmlNode nd in list)
            {
                string idno = nd["ID_No"].InnerText;
                roomno = nd["RoomNo"].InnerText;
                if (idno == id)
                {

                    nd["Balance"].InnerText = "";
                    nd["ReserveDays"].InnerText = "";
                    nd["FloorNo"].InnerText = "";
                    nd["RoomType"].InnerText = "";
                    nd["RoomNo"].InnerText = "";
                    nd["CheckIn"].InnerText = "";
                    nd["CheckOut"].InnerText = "";
                    nd["TimeRemain"].InnerText = "";
                }
                else
                {
                    Console.WriteLine("Customer Not Found!");
                    break;
                }
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            this.updateroom(roomno, "yes");
        }
        public string Full_name
        {
            get
            {
                return full_name;
            }

            set
            {
                full_name = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string Id_num
        {
            get
            {
                return id_num;
            }

            set
            {
                id_num = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        

        
       

        public int Room_no
        {
            get
            {
                return room_no;
            }

            set
            {
                room_no = value;
            }
        }

        public int Reserve_day
        {
            get
            {
                return reserve_day;
            }

            set
            {
                reserve_day = value;
            }
        }

        public int Floorno
        {
            get
            {
                return floorno;
            }

            set
            {
                floorno = value;
            }
        }

        public DateTime Check_in
        {
            get
            {
                return check_in;
            }

            set
            {
                check_in = value;
            }
        }

        public DateTime Check_out
        {
            get
            {
                return check_out;
            }

            set
            {
                check_out = value;
            }
        }

        public double Time_remain
        {
            get
            {
                return time_remain;
            }

            set
            {
                time_remain = value;
            }
        }

       
    }


}
