using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class SnackDB: BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Snack() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Snack snak = (Snack)entity;
            snak.Id = int.Parse(reader["Id"].ToString());
            snak.SnackName = reader["SnackName"].ToString();
            snak.Calories = int.Parse(reader["Calories"].ToString());
            snak.IsSalty = bool.Parse(reader["IsSalty"].ToString());

            return snak;
        }

        public SnackList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM TblSnacks";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }

        public Snack SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM TblSnacks WHERE (Id = {0})", id);
            SnackList list = new SnackList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public SnackList SelectByUser(User user)
        {
            this.command.CommandText = "SELECT * FROM (TblUserSnack INNER JOIN TblSnacks " +
                $"ON TblUserSnack.SnackID = TblSnacks.Id) WHERE UserID = {user.Id}";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }


    }
}
