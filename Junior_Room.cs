using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    class JuniorRoom : Room
    {
        public JuniorRoom()
        {
            this.set_type("junior");
            this.set_price(2000);
            this.set_totalno(50);
            this.set_no_per_flr(10);
        }
        public override int get_no_per_flr()
        {
            return base.no_per_flr;
        }

        public override int get_price()
        {
            return base.price;
        }

        public override int get_totalno()
        {
            return base.total_no;
        }

        public override string get_type()
        {
            return base.type;
        }

        public override void set_no_per_flr(int s)
        {
            base.no_per_flr = s;
        }

        public override void set_price(int s)
        {
            base.price = s;
        }

        public override void set_totalno(int s)
        {
            base.total_no = s;
        }

        public override void set_type(string s)
        {
            base.type = s;
        }

        public override void set_roomNo(int s)
        {
            this.room_no = s;
        }

        public override int get_roomNo()
        {
            return this.room_no;
        }

        public override string get_reserv()
        {
            return this.reserved;
        }

        public override void set_reserv(string s)
        {
            this.reserved = s;
        }
    }
}
