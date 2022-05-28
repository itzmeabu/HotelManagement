using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.CommonUtils
{
    class JsonReader
    {
        internal static object ReadInputs(string inputFileName, Type type)
        {
            try
            {
                using (Stream str = File.OpenRead(inputFileName))
                {
                    DataContractJsonSerializer deSerialize = new DataContractJsonSerializer(type);

                    return deSerialize.ReadObject(str);
                    
                }
            }
            catch (SerializationException ex)
            {
                Base.LogMessage(ex.Message);
                throw ex;
            }
            
        }
    }
}
