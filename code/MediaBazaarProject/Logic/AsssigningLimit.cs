using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class AsssigningLimit
    {
        private int humanresources=1;
        private int pr = 1;
        private int salesFloor1=1;
        private int salesFloor2 = 1;
        private int salesFloor3 = 1;
        private int salesFloor4 = 1;
        private int depot=1;

        public int HR_Limit
        {
            get { return this.humanresources; }
            set { this.humanresources = value; }
        }
        public int PR_Limit
        {
            get { return this.pr; }
            set { this.pr = value; }
        }
        public int SALES_F1_Limit
        {
            get { return this.salesFloor1; }
            set { this.salesFloor1 = value; }
        }
        public int SALES_F2_Limit
        {
            get { return this.salesFloor2; }
            set { this.salesFloor2 = value; }
        }
        public int SALES_F3_Limit
        {
            get { return this.salesFloor3; }
            set { this.salesFloor3 = value; }
        }
        public int SALES_F4_Limit
        {
            get { return this.salesFloor4; }
            set { this.salesFloor4 = value; }
        }
        public int DEPOT_Limit
        {
            get { return this.depot; }
            set { this.depot = value; }
        }
        public AsssigningLimit(int hr, int pr, int slf1, int slf2, int slf3, int slf4, int dp)
        {
            if (hr == 0 || pr == 0 || slf1 == 0 || slf2 == 0 || slf3 == 0 || slf4 == 0 || dp == 0) { }
            else
            {
                this.depot = dp;
                this.salesFloor1 = slf1;
                this.salesFloor2 = slf2;
                this.salesFloor3 = slf3;
                this.salesFloor4 = slf4;
                this.pr = pr;
                this.humanresources = hr;
            }
        }
    }
}
