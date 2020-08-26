using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class InputCoilDAL:BaseDAL
    {
        public IEnumerable<FPL_INPUT_COIL> GetAllCoils()
        {
            var result = db.FPL_INPUT_COIL;
            return result;
        }

        public IQueryable<INPUT_COIL_FIELDS> GetCoilsForTable(int size, int count)
        {
            var result = db.FPL_INPUT_COIL.Select(x => new INPUT_COIL_FIELDS
            {
                COIL_NO = x.COIL_NO,
                COIL_ID=x.COIL_ID,
                COIL_SEQ =x.COIL_SEQ,
                MATERIAL_GRADE_ID=x.MATERIAL_GRADE_ID,
                WIDTH=x.WIDTH,
                LENGTH=x.LENGTH,
                WEIGHT=x.WEIGHT,
                THICKNESS=x.THICKNESS,
                INTERNAL_DIAMETER=x.INTERNAL_DIAMETER,
                STATUS=x.STATUS,
                CREATION_DATE=x.CREATION_DATE
            }).OrderByDescending(x => x.COIL_ID).Skip(size * count).Take(size);
            return result;
        }
    }
}
