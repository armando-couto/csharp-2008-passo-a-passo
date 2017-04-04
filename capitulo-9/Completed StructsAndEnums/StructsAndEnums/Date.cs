using System;

namespace StructsAndEnums
{
    struct Date
    {
        public Date(int ccyy, Month mm, int dd)
        {
            this.year = ccyy - 1900;
            this.month = mm;
            this.day = dd - 1;
        }

        public override string ToString()
        {
            return this.month + " " + (this.day + 1) + " " + (this.year + 1900);
        }

        private int year;
        private Month month;
        private int day;
    }
}