﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class MSG_PROD_COIL_FIELDS
    {
        public MSG_PROD_COIL_FIELDS()
        {

        }
        public int MSG_COUNTER { get; set; }
        public string EX_COIL_ID { get; set; }
        public string SCHEDULE_ID { get; set; }
        //public int L3_OUTPUT_CNT { get; set; }
        //public int LAST_COIL_FLAG { get; set; }
        //public Nullable<System.DateTime> PRODUCTION_BEGIN_DATE { get; set; }
        public Nullable<System.DateTime> PRODUCTION_END_DATE { get; set; }
        //public int PRODUCTION_SHIFT { get; set; }
        //public string PRODUCTION_CREW { get; set; }
        public decimal WIDTH { get; set; }
        public decimal THICKNESS { get; set; }
        //public decimal MEASURED_LENGTH { get; set; }
        public decimal MEASURED_WEIGHT { get; set; }
        //public decimal EX_EXT_DIAMETER { get; set; }
        //public decimal EX_INT_DIAMETER { get; set; }
        //public int EX_SPOOL_MODE { get; set; }
        //public string EN_STEEL_GRADE_ID { get; set; }
        public string EX_STEEL_GRADE_ID { get; set; }
        //public int WELD_INSIDE_FLAG { get; set; }
        //public decimal EX_HEAD_SCRAP_LENGTH { get; set; }
        //public decimal EX_TAIL_SCRAP_LENGTH { get; set; }
        public decimal EN_THICKNESS_AVG { get; set; }
        //public decimal EN_THICKNESS_MIN { get; set; }
        //public decimal EN_THICKNESS_MAX { get; set; }
        //public decimal EN_THICKNESS_SDD { get; set; }
        //public int PUNCHING_MODE { get; set; }
        //public int THERMAL_CYCLE { get; set; }
        //public decimal UPCOAT_WEIGHT { get; set; }
        //public decimal UPCOAT_WEIGHT_AVG { get; set; }
        //public decimal UPCOAT_WEIGHT_MIN { get; set; }
        //public decimal UPCOAT_WEIGHT_MAX { get; set; }
        //public decimal UPCOAT_WEIGHT_SDD { get; set; }
        //public decimal LOCOAT_WEIGHT { get; set; }
        //public decimal LOCOAT_WEIGHT_AVG { get; set; }
        //public decimal LOCOAT_WEIGHT_MIN { get; set; }
        //public decimal LOCOAT_WEIGHT_MAX { get; set; }
        //public decimal LOCOAT_WEIGHT_SDD { get; set; }
        //public int SKINPASS_MODE { get; set; }
        //public decimal SKINPASS_ELONG { get; set; }
        //public int LEVELER_MODE { get; set; }
        //public decimal LEVELER_ELONG { get; set; }
        //public int PASSIVATION_MODE { get; set; }
        //public int OILER_OIL_MODE { get; set; }
        //public decimal OILER_OIL_AMOUNT { get; set; }
        //public decimal COILING_TENSION_AVG { get; set; }
        //public decimal COILING_TENSION_MIN { get; set; }
        //public decimal COILING_TENSION_MAX { get; set; }
        //public decimal COILING_TENSION_SDD { get; set; }
        //public int STAGGERING_MODE { get; set; }
        //public string DESTINATION { get; set; }
        //public string REMARK { get; set; }
        //public int UNEXPECTED_CUT_FLAG { get; set; }
        //public string UNEXPECTED_CUT_REMARK { get; set; }
        //public string OPERATOR { get; set; }
        //public Nullable<System.DateTime> REVISION { get; set; }
        //public decimal EX_HEAD_SCRAP_WEIGHT { get; set; }
        //public decimal EX_TAIL_SCRAP_WEIGHT { get; set; }
        //public int ELECTRICAL_ENERGY { get; set; }
        //public decimal ACT_COIL_SPEED_RATIO { get; set; }
        //public decimal ACT_SHIFT_SPEED_RATIO { get; set; }
        public decimal CALC_WEIGHT { get; set; }
    }
}
