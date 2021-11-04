using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MemeGame.Storage
{
    public class Tools
    {
        public static byte[] ReadStream(Stream responseStream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static decimal GetKilobyteSize(long size)
        {
            decimal result = Decimal.Divide(size, 1024);
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}
