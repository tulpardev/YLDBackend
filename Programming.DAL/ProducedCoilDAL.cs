using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using Programming.DAL.Utilities;

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

        public IQueryable<MSG_PROD_COIL_FIELDS> GetProducedCoilFieldsById(int Id)
        {
            var fieldsTable = db.MSG_PROD_COIL.Where(x =>  x.MSG_COUNTER==Id).Select(q => new MSG_PROD_COIL_FIELDS
            {
                UPCOAT_WEIGHT_AVG=q.UPCOAT_WEIGHT_AVG,
                UPCOAT_WEIGHT_MIN=q.UPCOAT_WEIGHT_MIN,
                UPCOAT_WEIGHT_MAX=q.UPCOAT_WEIGHT_MAX,
                REMARK= q.REMARK
            });
            return fieldsTable;
        }

        public bool UpdateProducedCoilsFields(int id, MSG_PROD_COIL mSG_PROD_COIL)
        {
           
            try
            {
                var dbModel = db.MSG_PROD_COIL.Where(q => q.EX_COIL_ID == mSG_PROD_COIL.EX_COIL_ID).OrderByDescending(q => q.MSG_COUNTER).FirstOrDefault();
                dbModel.UPCOAT_WEIGHT_AVG = mSG_PROD_COIL.UPCOAT_WEIGHT_AVG;
                dbModel.UPCOAT_WEIGHT_MIN = mSG_PROD_COIL.UPCOAT_WEIGHT_MIN;
                dbModel.UPCOAT_WEIGHT_MAX = mSG_PROD_COIL.UPCOAT_WEIGHT_MAX;
                dbModel.REMARK = mSG_PROD_COIL.REMARK;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool IsThereAnyMsgCounter(int id)
        {
            return db.MSG_PROD_COIL.Any(x => x.MSG_COUNTER == id);
        }

        private static readonly List<MSG_PROD_COIL_FIELDS> userData = UserDataSeed();
   

        public IEnumerable<MSG_PROD_COIL> GetProducedCoilWithFilter(string filterQuery)
        {
            var ef = new ExpressionFilter();
            var query = ef.GetDynamicQueryWithExpresionTrees<MSG_PROD_COIL>(filterQuery);
            var table = db.MSG_PROD_COIL.ToList().Where(query);
            return table;
        }


        private static List<MSG_PROD_COIL_FIELDS> UserDataSeed()
        {
            return new List<MSG_PROD_COIL_FIELDS>
            {
                new MSG_PROD_COIL_FIELDS{ EX_COIL_ID = "20080093GA", SCHEDULE_ID = "TESTJOB", EN_STEEL_GRADE_ID = "10"},
                new MSG_PROD_COIL_FIELDS{ EX_COIL_ID = "20080093GA", SCHEDULE_ID = "TESTJOB", EN_STEEL_GRADE_ID = "20"},
                new MSG_PROD_COIL_FIELDS{ EX_COIL_ID = "20080093GA", SCHEDULE_ID = "TESTJOB", EN_STEEL_GRADE_ID = "30"},
                new MSG_PROD_COIL_FIELDS{ EX_COIL_ID = "20080093GA", SCHEDULE_ID = "TESTJOB", EN_STEEL_GRADE_ID = "40"},
                new MSG_PROD_COIL_FIELDS{ EX_COIL_ID = "20080093GA", SCHEDULE_ID = "TESTJOB", EN_STEEL_GRADE_ID = "50"}
            };
        }
    }
}