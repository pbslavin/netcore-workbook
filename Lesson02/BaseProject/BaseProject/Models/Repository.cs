using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Models
{
    public static class Repository
    {
        private static List<FormDataModel> formDataObjects = new List<FormDataModel>();

        public static IEnumerable<FormDataModel> FormDataObjects
        {
            get
            {
                return formDataObjects;
            }
        }

        public static void AddFormDataObject(FormDataModel formDataObject)
        {
            formDataObjects.Add(formDataObject);
        }
    }
}
