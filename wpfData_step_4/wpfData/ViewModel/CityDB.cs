using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel 
{
    public class CityDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new City() as BaseEntity; //יצירת עצם חדש מסוג
        }

        //Reader-מילוי העצם בערכים מה
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = (City)entity;
            city.Id = (int)this.reader["ID"];
            city.CityName = (string)this.reader["CityName"];
            return city;
        }

        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblCity";
            CityList cityList = new CityList(base.ExecuteCommand());
            return cityList;
        }

        public City SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM TblCity WHERE ID={0}", id);
            CityList cityList = new CityList(base.ExecuteCommand());
            if(cityList.Count==0)
                return null;
            return cityList[0];
        }
    }
}
