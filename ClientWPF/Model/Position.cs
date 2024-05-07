using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    public class Position : IDataErrorInfo
    {
        public int Id { get; set; }
        public string PositionName { get; set; }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "PositionName":
                        if (string.IsNullOrWhiteSpace(PositionName))
                            error = "Позиция не может быть пустой";
                        break;
                }
                return error;
            }
        }
        public string Error => null;
    }
}
