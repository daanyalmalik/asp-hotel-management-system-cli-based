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
    class Search
    {

        public int total_checkin()
        {
            ;
            int total = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");

            XmlNodeList list = doc.SelectNodes("CustomerData/Customer");
            DateTime datet = DateTime.Today;
            Console.WriteLine("lalala1: " + datet);
            foreach (XmlNode nd in list)
            {
                string date = nd["CheckIn"].InnerText;
                DateTime d = Convert.ToDateTime(date);
                Console.WriteLine("lalala2: " + d);
                if (d >= datet)
                {
                    total++;
                }
                
                
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            return total;

        }

        public int total_checkout()
        {

            int total = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");

            XmlNodeList list = doc.SelectNodes("CustomerData/Customer");
            foreach (XmlNode nd in list)
            {
                string date = nd["CheckOut"].InnerText;
                DateTime d = Convert.ToDateTime(date);
                if (d == DateTime.Now.Date)
                {
                    total++;
                }


            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            return total;

        }

        public int[] get_rooms()
        {
            int []arr= new int[5];
            
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Rooms.xml");

            XmlNodeList list = doc.SelectNodes("Hotel/Room");
            foreach (XmlNode nd in list)
            {
                string avail = nd["Available"].InnerText;
                string type = nd["Type"].InnerText;
                if (type == "suite" && avail == "no" )
                {
                    arr[0]++;
                }
                else if (type == "junior" && avail == "no")
                {
                    arr[1]++;
                }
                else if (type == "superior" && avail == "no")
                {
                    arr[2]++;
                }
                else if (type == "moderate" && avail == "no")
                {
                    arr[3]++;
                }
                else if (type == "standard" && avail == "no")
                {
                    arr[4]++;
                }
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            return arr;
        }

        public int[] get_empty_rooms()
        {
            int[] arr = new int[5];
            
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Rooms.xml");

            XmlNodeList list = doc.SelectNodes("Hotel/Room");
            foreach (XmlNode nd in list)
            {
                string avail = nd["Available"].InnerText;
                string type = nd["Type"].InnerText;
                if (type == "suite" && avail == "yes")
                {
                    arr[0]++;
                }
                else if (type == "junior" && avail == "yes")
                {
                    arr[1]++;
                }
                else if (type == "superior" && avail == "yes")
                {
                    arr[2]++;
                }
                else if (type == "moderate" && avail == "yes")
                {
                    arr[3]++;
                }
                else if (type == "standard" && avail == "yes")
                {
                    arr[4]++;
                }
            }
            doc.Save("C:\\Users\\daany\\Documents\\visual studio 2015\\Projects\\HotelManagement\\HotelManagement\\bin\\Debug\\Customers.xml");
            return arr;
        }


    }
}
