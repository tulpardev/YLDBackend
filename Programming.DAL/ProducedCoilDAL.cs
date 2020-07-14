using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class ProducedCoilDAL : BaseDAL
    {
        public IEnumerable<MSG_PROD_COIL> GetProducedCoils()
        {
            var result = db.MSG_PROD_COIL;
            return result;
        }

        public MSG_PROD_COIL GetProducedCoilsById(int id)
        {
            return db.MSG_PROD_COIL.Find(id);
        }

        public IQueryable<MSG_PROD_COIL_FIELDS> GetProducedCoilForTable(int size, int count)
        {
            var result = db.MSG_PROD_COIL.Select(x => new MSG_PROD_COIL_FIELDS
            {
                MSG_COUNTER = x.MSG_COUNTER,
                EX_COIL_ID=x.EX_COIL_ID,
                SCHEDULE_ID=x.SCHEDULE_ID,
                EX_STEEL_GRADE_ID=x.EX_STEEL_GRADE_ID,
                WIDTH=x.WIDTH,
                THICKNESS = x.THICKNESS,
                CALC_WEIGHT =x.CALC_WEIGHT,
                MEASURED_WEIGHT=x.MEASURED_WEIGHT,
                PRODUCTION_END_DATE=x.PRODUCTION_END_DATE
            }).OrderByDescending(x => x.MSG_COUNTER).Skip(size * count).Take(size);
            return result;
        }
    }   
}