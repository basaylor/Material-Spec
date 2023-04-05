using System;
using System.Collections.Generic;
using System.Text;

namespace UNSPractice
{
    //represents the Attributes of the Material Properties
    public class data
    {
        public string matnr { get; set; }
        public string? coiln { get; set; }
        public string? oem { get; set; }
        public string? spec_grade { get; set; }
        public string? grade_name { get; set; }
        public string? datin { get; set; }
        public string? name1 { get; set; }
        public string? name2 { get; set; }
        public double? width { get; set; }
        public string? width_uom { get; set; }
        public double? thickness { get; set; }
        public string? thickness_uom { get; set; }
        public double? weight { get; set; }
        public string? weight_uom { get; set; }
        public double? yield_strength { get; set; }
        public string? yield_strength_uom { get; set; }
        public double? tensile_strength { get; set; }
        public string? tensile_strength_uom { get; set; }
        public double? elongation { get; set; }
        public string? elongation_uom { get; set; }
        public double? nvalue { get; set; }
        public string? nvalue_uom { get; set; }
        public double? rvalue { get; set; }
        public string? rvalue_uom { get; set; }
    }
}