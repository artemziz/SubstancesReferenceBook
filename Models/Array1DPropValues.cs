using System;
using System.Collections.Generic;

namespace SubstancesReferenceBook
{
    public class Array1DPropValues:Value
    {
        /// <summary>
        /// public int Id;
        /// public int PropSubId;
        /// public DateTime VersionDate;
        /// </summary>
        public StateVariables StateVar;
        public List<double> Values = new List<double>(); 
    }
     
}