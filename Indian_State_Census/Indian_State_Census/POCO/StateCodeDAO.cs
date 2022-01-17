using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census.POCO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateCode = v2;
            this.tin = Convert.ToInt32(v4);
            this.stateCode = v4;
        }
    }
}
