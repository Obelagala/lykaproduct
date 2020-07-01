using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LPEntities
{
   public class Cities
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public List<Cities>Citylist { get; set; }
    }
}
