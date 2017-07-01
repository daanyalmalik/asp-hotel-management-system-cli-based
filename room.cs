using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    public abstract class Room
    {
        protected string type;
        protected int price;
        protected int total_no;
        public int room_no;
        public string reserved;
        protected int no_per_flr;

        public abstract void set_type(string s);
        public abstract void set_price(int s);
        public abstract void set_totalno(int s);
        public abstract void set_no_per_flr(int s);
        public abstract void set_roomNo(int s);

        public abstract void set_reserv(string s);

        public abstract string get_type();
        public abstract int get_price();
        public abstract int get_totalno();
        public abstract int get_no_per_flr();
        public abstract int get_roomNo();

        public abstract string get_reserv();

        public void make_rooms(int flr)
        {
            for(int i=1; i<=flr; i++)
            {
                for(int r=1; r<50; r++)
                {
                    int rnum = (i * 100) + 1;
                    if( (rnum>=100 && rnum<=110) || (rnum >= 200 && rnum <= 210) || (rnum >= 300 && rnum <= 310) || (rnum >= 400 && rnum <= 410) || (rnum >= 500 && rnum <= 510))
                    {
                        Room room = new StandardRoom();
                        room.room_no = rnum;
                        //write to file
                    }
                    else if ((rnum >= 111 && rnum <= 120) || (rnum >= 211 && rnum <= 220) || (rnum >= 311 && rnum <= 320) || (rnum >= 411 && rnum <= 420) || (rnum >= 511 && rnum <= 520))
                    {
                        Room room = new ModerateRoom();
                        room.room_no = rnum;
                    }
                    else if ((rnum >= 121 && rnum <= 130) || (rnum >= 221 && rnum <= 230) || (rnum >= 321 && rnum <= 330) || (rnum >= 421 && rnum <= 430) || (rnum >= 521 && rnum <= 530))
                    {
                        Room room = new SuperiorRoom();
                        room.room_no = rnum;
                    }
                    else if ((rnum >= 131 && rnum <= 140) || (rnum >= 231 && rnum <= 240) || (rnum >= 331 && rnum <= 340) || (rnum >= 431 && rnum <= 440) || (rnum >= 531 && rnum <= 540))
                    {
                        Room room = new JuniorRoom();
                        room.room_no = rnum;
                    }
                    else if ((rnum >= 141 && rnum <= 150) || (rnum >= 241 && rnum <= 250) || (rnum >= 341 && rnum <= 350) || (rnum >= 441 && rnum <= 450) || (rnum >= 541 && rnum <= 550))
                    {
                        Room room = new SuiteRoom();
                        room.room_no = rnum;
                    }




                }
            }
        }
    }
}
